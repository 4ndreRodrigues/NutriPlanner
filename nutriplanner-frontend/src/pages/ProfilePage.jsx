import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import HealthConditionList from "../components/HealthConditionList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function ProfilePage({ token }) {
    const [profile, setProfile] = useState(null);
    const [selectedConditions, setSelectedConditions] = useState([]);
    const [healthConditions, setHealthConditions] = useState([]);
    const [diets, setDiets] = useState([]);
    const [loadingHealthConditions, setLoadingHealthConditions] = useState(true);


    useEffect(() => {
        fetch(`${API_URL}/users/me`, { headers: { Authorization: `Bearer ${token}` } })
            .then((res) => res.json())
            .then(setProfile);

        fetch(`${API_URL}/UserHealthCondition`, { headers: { Authorization: `Bearer ${token}` } })
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
        fetch(`${API_URL}/users/me/diet/${newDietId}`, {
            method: "PUT",
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
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao selecionar dieta");
            });
    }

    if (!profile) return <p>A carregar...</p>;

    return (
        <div className="page-content">
            <div className="profile-header">
                {/* Cabeçalho do Utilizador Organizado */}
                <div className="profile-user-main">
                    <div className="profile-avatar">{profile.email[0].toUpperCase()}</div>
                    <div className="profile-user-info">
                        <h4>{profile.email}</h4>
                        
                    </div>
                </div>

                {/* Secção de Seleção da Dieta */}
                <div className="profile-conditions-container">
                    <h2>Dieta atual</h2>
                    <select value={profile.dietId || ""} onChange={(e) => handleDietChange(Number(e.target.value))}>
                        <option value="" disabled>Selecione uma dieta...</option>
                        {diets.map((diet) => (
                            <option key={diet.id} value={diet.id}>
                                {diet.name}
                            </option>
                        ))}
                    </select>
                </div>

                {/* Secção de Condições */}
                <div className="profile-conditions-container">
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