import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import HealthConditionList from "../components/HealthConditionList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function ProfilePage({ token, handleDietSelection }) {
    const [profile, setProfile] = useState(null);
    const [selectedConditions, setSelectedConditions] = useState([]);
    const [healthConditions, setHealthConditions] = useState([]);
    const [diets, setDiets] = useState([]);
    const [loadingHealthConditions, setLoadingHealthConditions] = useState(true);


    useEffect(() => {
        fetch(`${API_URL}/users/me`, { headers: { Authorization: `Bearer ${token}` } })
            .then((res) => res.json())
            .then(setProfile);

        fetch(`${API_URL}/UserHealthConditions`, { headers: { Authorization: `Bearer ${token}` } })
            .then((res) => res.json())
            .then((data) => {
                const conditionIds = data.map((s) => s.healthConditionId);
                setSelectedConditions(conditionIds);
            })
            .catch((err) => console.error("Erro ao ir buscar seleções de saúde:", err));

        fetch(`${API_URL}/healthconditions`)
            .then(response => {
                if (!response.ok) throw new Error("Error fetching health conditions");
                return response.json();
            })
            .then(data => {
                setHealthConditions(data);
                setLoadingHealthConditions(false);
            })
            .catch((err) => {
                console.error("Erro ao ir buscar condições de saúde:", err);
                setLoadingHealthConditions(false);
            });

        fetch(`${API_URL}/diets`)
            .then((response) => response.json())
            .then((data) => setDiets(data))
            .catch((err) => console.error("Erro ao ir buscar dietas:", err));

    }, [token]);

    function handleSelectionAdded(healthConditionId) {
        setSelectedConditions((prev) => {
            if (prev.includes(healthConditionId)) {
                return prev;
            }

            return [...prev, healthConditionId];
        });
    }

    function handleSelectionRemoved(healthConditionId) {
        setSelectedConditions((prev) =>
            prev.filter((id) => id !== healthConditionId)
        );
    }

    function handleDietChange(newDietId) {
        if (newDietId === profile.dietId) {
            return;
        }
        const endpoint = newDietId === null
            ? `${API_URL}/users/me/diet`
            : `${API_URL}/users/me/diet/${newDietId}`;

        const method = newDietId === null ? "DELETE" : "PUT";
   
        fetch(endpoint, {
            method: method,
            headers: {
                Authorization: `Bearer ${token}`
            }
            })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao selecionar dieta");
                const selectedDiet = diets.find((d) => d.id === newDietId);
                setProfile((prev) => ({
                    ...prev,
                    dietId: newDietId,
                    dietName: selectedDiet ? selectedDiet.name : prev.dietName
                }));
                handleDietSelection(newDietId);
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao selecionar dieta");
            });
    }

    if (!profile) return <p>A carregar...</p>;

    return (
        <div className="page-content">
            <div className="profile-card">
                {/* Cabeçalho do Utilizador */}
                <div className="profile-user-main">
                    <div className="profile-avatar">{profile.email[0].toUpperCase()}</div>
                    <div className="profile-user-info">
                        <h3>{profile.name} {profile.lastName}</h3>
                        <p className="profile-email">{profile.email}</p>
                        <p className="profile-birthdate">
                            📅 Nascido a {profile.birthDate ? new Date(profile.birthDate).toLocaleDateString() : "Não especificada"}
                        </p>
                    </div>
                </div>

                <div className="profile-divider"></div>

                { }
                <div className="profile-section">
                    <h2>Dieta atual</h2>
                    <select
                        value={profile.dietId || ""}
                        onChange={(e) => {
                            const val = e.target.value;
                            handleDietChange(val === "" ? null : Number(val));
                        }}
                    >
                        <option value="">--- Sem dieta ---</option>
                        {diets.map((diet) => (
                            <option key={diet.id} value={diet.id}>
                                {diet.name}
                            </option>
                        ))}
                    </select>
                </div>

                <div className="profile-divider"></div>

                {/* Secção de Condições */}
                <div className="profile-section">
                    <h2>Condições de Saúde</h2>
                    {loadingHealthConditions ? (
                        <p>A carregar...</p>
                    ) : (
                        <HealthConditionList
                            healthConditions={healthConditions}
                            token={token}
                            selectedConditions={selectedConditions}
                            onSelectionAdded={handleSelectionAdded}
                            onSelectionRemoved={handleSelectionRemoved}
                        />
                    )}
                </div>
            </div>
        </div>
    );
}

export default ProfilePage;