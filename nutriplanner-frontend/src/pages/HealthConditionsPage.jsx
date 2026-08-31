import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import HealthConditionList from "../components/HealthConditionList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function HealthConditionsPage({ token }) {
    const [healthConditions, setHealthConditions] = useState([]);
    const [selectedConditions, setSelectedConditions] = useState([]);
    const [loadingHealthConditions, setLoadingHealthConditions] = useState(true);
    const navigate = useNavigate();

    useEffect(() => {
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

        fetch(`${API_URL}/UserHealthConditions`, { headers: { Authorization: `Bearer ${token}` } })
            .then((res) => res.json())
            .then((data) => {
                const conditionIds = data.map((s) => s.healthConditionId);
                setSelectedConditions(conditionIds);
            })
            .catch((err) => console.error("Erro ao ir buscar seleções de saúde:", err));
    }, []);

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


    return (
        <div className="page-content">
                    <h2>Condições de Saúde</h2>
                    {loadingHealthConditions ? (
                        <p>A carregar...</p>
                    ) : (
                        <div className="diet-selection-container">
                            <HealthConditionList
                                healthConditions={healthConditions}
                                token={token}
                                selectedConditions={selectedConditions}
                                onSelectionAdded={handleSelectionAdded}
                                onSelectionRemoved={handleSelectionRemoved}
                            />
                            <div>
                                <button className="btn-skip" onClick={() => navigate("/")}>Guardar</button>
                            </div>
                        </div>

                    )}
                </div>
    );
}

export default HealthConditionsPage;