import { useState, useEffect } from "react";
import FoodList from "../components/FoodList";
import UserSelectionList from "../components/UserSelectionList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function UserSelectionPage({ token }) {
    const [userSelections, setUserSelections] = useState([]);
    const [loadingFoods, setLoadingFoods] = useState(false);

    function handleSelectionAdded(foodId) {
        setUserSelectionIds((prev) => new Set(prev).add(foodId));
    }

    function handleSelectionRemoved(foodId) {
        setUserSelections((prev) => prev.filter((s) => s.foodId !== foodId));
    }

    useEffect(() => {
        if (!token) return;
        setLoadingFoods(true);
        fetch(`${API_URL}/UserSelections`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        .then((res) => res.json())
        .then((data) => {
            setUserSelections(data);
            setLoadingFoods(false);
        })
        .catch ((err) => {
            console.error("Erro ao ir buscar seleções do utilizador:", err);
            setLoadingFoods(false);
        });
    }, [token]);

    return (
        <div className="container">
            <h1>NutriPlanner</h1>
            <h2>My Selections</h2>
            {loadingFoods ? (
                <p>Carregando seleções...</p>
            ) : (
                <FoodList
                    foods={userSelections}
                    token={token}
                    userSelectionIds={new Set(userSelections.map((s) => s.foodId))}
                    onSelectionRemoved={handleSelectionRemoved}
                />
            )}
        </div>
    );
}

export default UserSelectionPage;