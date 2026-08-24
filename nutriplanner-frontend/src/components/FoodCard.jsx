import { useState } from "react";

const API_URL = "https://localhost:7250/api";

const categoryIcons = {
    "Proteínas": "🥩",
    "Hidratos": "🍞",
    "Gorduras": "🥑",
    "Vegetais": "🥦",
    "Frutas": "🍎"
};

function FoodCard({ food, token, isSelected, onSelectionAdded, onSelectionRemoved }) {
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
        fetch(`${API_URL}/foods/${food.id}/nutrition`)
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

    function handleSelect() {
        fetch(`${API_URL}/UserFoods`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify({ foodId: food.id })
        })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao selecionar alimento");
                return res.json();
            })
            .then(() => {
                onSelectionAdded(food.id);
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao selecionar alimento");
            });
    }

    function handleDeselect() {
        fetch(`${API_URL}/UserFoods/${food.id}`, {
            method: "DELETE",
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao remover seleção");
                onSelectionRemoved(food.id);
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao remover seleção");
            });
    }

    return (
        <li className="food-card">
            <div className="food-card-header">
                <div className="food-card-identity">
                    <span className="food-icon">{categoryIcons[food.category] || "🍽️"}</span>
                    <span>{food.name}</span>
                </div>
                <div className="food-card-actions">
                    {!isSelected && (
                        <button className="btn-solid" onClick={handleSelect}>
                            Adicionar
                        </button>
                    )}
                    {isSelected && (
                        <button className="btn-danger" onClick={handleDeselect}>
                            Remover
                        </button>
                    )}
                    <button className="btn-outline" onClick={handleToggle}>
                        {showNutrition ? "Ocultar" : "Ver macros"}
                    </button>
                </div>
            </div>

            {loading && <p className="food-loading">A carregar...</p>}
            {error && <p className="food-error">{error}</p>}

            {showNutrition && nutrition && (
                <ul className="food-macros">
                    <li>Calorias: {nutrition.calories} kcal</li>
                    <li>Proteína: {nutrition.protein} g</li>
                    <li>Hidratos: {nutrition.carbs} g</li>
                    <li>Gordura: {nutrition.fat} g</li>
                </ul>
            )}
        </li>
    );
}

export default FoodCard;    