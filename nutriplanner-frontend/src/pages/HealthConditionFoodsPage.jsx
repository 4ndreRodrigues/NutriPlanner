import { useState, useEffect } from "react";
import HealthConditionList from "../components/HealthConditionList";
import FoodListByHealthCondition from "../components/FoodListByHealthCondition";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function HealthConditionFoodsPage({ token }) {
    const [healthConditions, setHealthConditions] = useState([]);
    const [selectedHealthConditionId, setSelectedHealthConditionId] = useState("");
    const [foods, setFoods] = useState([]);
    const [loadingHealthConditions, setLoadingHealthConditions] = useState(true);
    const [loadingFoods, setLoadingFoods] = useState(false);
    const [userSelectionIds, setUserSelectionIds] = useState(new Set());

    // Encontra a condição de saúde atual com base no ID selecionado
    const currentCondition = healthConditions.find((c) => c.id === Number(selectedHealthConditionId));

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
                if (data.length > 0) {
                    setSelectedHealthConditionId(data[0].id);
                }
            })
            .catch((err) => {
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
        if (!selectedHealthConditionId) return;

        setLoadingFoods(true);
        fetch(`${API_URL}/healthconditions/${selectedHealthConditionId}/foods`)
            .then((response) => response.json())
            .then((data) => {
                setFoods(data);
                setLoadingFoods(false);
            })
            .catch((err) => {
                console.error("Erro ao ir buscar alimentos:", err);
                setLoadingFoods(false);
            });
    }, [selectedHealthConditionId]);

    return (
        <div className="page-content">
            <div className="diet-switcher">
                <h2>Condições de Saúde</h2>

                {loadingHealthConditions ? (
                    <p>A carregar condições...</p>
                ) : (
                    <>
                        <select
                            value={selectedHealthConditionId}
                            onChange={(e) => setSelectedHealthConditionId(Number(e.target.value))}
                        >
                            <option value="" disabled>Selecione uma condição</option>
                            {healthConditions.map((condition) => (
                                <option key={condition.id} value={condition.id}>
                                    {condition.name}
                                </option>
                            ))}
                        </select>
                        {/* Usamos agora a variável correta: currentCondition */}
                        <p className="diet-description">{currentCondition?.description}</p>
                    </>
                )}
            </div>

            {selectedHealthConditionId && (
                <>
                    <h2>Alimentos a evitar/moderar</h2>
                    {loadingFoods ? (
                        <p>A carregar alimentos...</p>
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

export default HealthConditionFoodsPage;