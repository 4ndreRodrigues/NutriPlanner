import { useState } from "react";

const API_URL = "https://localhost:7250/api";

function UserSelectionCard({ userSelection, token, onSelectionRemoved }) {
    const [nutrition, setNutrition] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [showNutrition, setShowNutrition] = useState(false);

    function handleToggle() {
        // já está aberto -> só fecha
        if (showNutrition) {
            setShowNutrition(false);
            return;
        }

        // já temos os dados de uma vez anterior -> não repete o fetch
        if (nutrition) {
            setShowNutrition(true);
            return;
        }

        // primeira vez -> vai buscar à API
        setLoading(true);
        setError(null);
        fetch(`${API_URL}/foods/${userSelection.foodId}/nutrition`)
        .then((res) => {
            if (!res.ok) throw new Error("Sem dados nutricionais");
            return res.json();
        })
        .then((data) => {
            setNutrition(data);
            setShowNutrition(true);
            setLoading(false);
        })
        .catch((err) => {
            setError(err.message);
            setLoading(false);
        });
    }

    function handleDeselect() {
        fetch(`${API_URL}/userfoods/${userSelection.foodId}`, {
            method: "DELETE",
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao remover seleção");
                onSelectionRemoved(userSelection.foodId);
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao remover seleção");
            });
    }

    return (
        <li className="food-card">
            <div className="food-card-header">
                <span>{userSelection.foodName}</span>
                <button className="btn-outline" onClick={handleToggle}>
                    {showNutrition ? "Ocultar" : "Ver macros"}
                </button>
                <button className="btn-danger" onClick={handleDeselect}>
                    Remover
                </button>
            </div>

            {loading && <p className="food-loading">A carregar...</p>}
            {error && <p className="food-error">{error}</p>}

            {showNutrition && nutrition && (
                <ul className="nutrition-details">
                    <li>Calorias: {nutrition.calories} kcal</li>
                    <li>Proteína: {nutrition.protein} g</li>
                    <li>Hidratos: {nutrition.carbs} g</li>
                    <li>Gordura: {nutrition.fat} g</li>
                </ul>
            )}
        </li>
    );
}

export default UserSelectionCard;    