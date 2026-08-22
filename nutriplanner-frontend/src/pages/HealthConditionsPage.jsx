import { useState, useEffect } from "react";
import HealthConditionList from "../components/HealthConditionList";
import FoodListByHealthCondition from "../components/FoodListByHealthCondition";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function HealthConditionsPage({ token }) {
    const [healthConditions, setHealthConditions] = useState([]);
    const [selectedHealthConditionId, setSelectedHealthConditionId] = useState(null);
    const [foods, setFoods] = useState([]);
    const [loadingHealthConditions, setLoadingHealthConditions] = useState(true);
    const [loadingFoods, setLoadingFoods] = useState(false);
    const [userSelectionIds, setUserSelectionIds] = useState(new Set());

    function handleSelectionAdded(foodId) {
        setUserSelectionIds((prev) => new Set(prev).add(foodId));
    }

    function handleSelectionRemoved(foodId) {
        setUserSelectionIds((prev) => {
            const updated = new Set(prev);
            updated.delete(foodId);
            return updated;
        });
    }

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
            .catch ((err) => {
                console.error("Erro ao ir buscar condições de saúde:", err);
                setLoadingHealthConditions(false);
            });
    }, []);

    useEffect(() => {
        if (!token) return;
        fetch(`${API_URL}/UserFoods`, {
            headers: { Authorization: `Bearer ${token}` },
        })
            .then((res) => res.json())
            .then((data) => {
                setUserSelectionIds(new Set(data.map((s) => s.foodId)));
            })
            .catch((err) => console.error("Erro ao ir buscar seleções:", err));
    }, [token]);

    useEffect(() => {
        if (selectedHealthConditionId === null) return;

        setLoadingFoods(true);
        fetch(`${API_URL}/healthconditions/${selectedHealthConditionId}/foods`)
            .then((response) => response.json())
            .then((data) => {
                setFoods(data);
                setLoadingFoods(false);
            });
    }, [selectedHealthConditionId]);


    return (
        <div className="page-content">
            <h2>Condições de saúde</h2>
            {loadingHealthConditions ? (
                <p>A carregar...</p>
            ) : (
                    <HealthConditionList
                        healthConditions={healthConditions}
                        selectedId={selectedHealthConditionId}
                        onSelect={setSelectedHealthConditionId}
                    />
            )}

            {selectedHealthConditionId && (
                <>
                    <h2>Alimentos a evitar/moderar</h2>
                    {loadingFoods ? (
                        <p>A carregar...</p>
                    ) : (
                            <FoodListByHealthCondition
                                foods={foods}
                                token={token}
                                userSelectionIds={userSelectionIds}
                                onSelectionAdded={handleSelectionAdded}
                                onSelectionRemoved={handleSelectionRemoved}
                            />
                    )}
                </>
            )}
        </div>
    );
}

export default HealthConditionsPage;