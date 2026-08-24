import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import HealthConditionList from "../components/HealthConditionList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function HealthConditionsPage({ token}) {
    const [healthConditions, setHealthConditions] = useState([]);
    const [selectedHealthConditionId, setSelectedHealthConditionId] = useState(null);
    const [foods, setFoods] = useState([]);
    const [loadingHealthConditions, setLoadingHealthConditions] = useState(true);
    const [userSelectionIds, setUserSelectionIds] = useState(new Set());
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
    }, []);


    return (
        <div className="page-content">
            <h2>Condições de Saúde</h2>
            {loadingHealthConditions ? (
                <p>A carregar...</p>
            ) : (
                    <HealthConditionList
                        healthConditions={healthConditions}
                        token={token}
                    />
            )}

        </div>
    );
}

export default HealthConditionsPage;