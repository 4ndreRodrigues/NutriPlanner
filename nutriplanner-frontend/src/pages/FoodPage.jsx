import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import DietList from "../components/DietList";
import FoodList from "../components/FoodList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function FoodPage({ token }) {
    const [foods, setFoods] = useState([]);
    const [loadingFoods, setLoadingFoods] = useState(false);
    const [userSelectionIds, setUserSelectionIds] = useState(new Set());
    const navigate = useNavigate();

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
        if (!token) return;

        fetch(`${API_URL}/UserSelections`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
        .then(response => {
            if (!response.ok) throw new Error("Error fetching user selections");
            return response.json();
        })
        .then(data => {
            setUserSelectionIds(new Set(data.map(selection => selection.foodId)));
        })
        .catch (err => {
            console.error("Erro ao ir buscar seleções do utilizador:", err);
        });
    }, [token]);

    useEffect(() => {
        setLoadingFoods(true);
        fetch(`${API_URL}/foods`)
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            setFoods(data);
            setLoadingFoods(false);
        });
    }, []);

    return (
        <div className="container">
            <h2>Alimentos</h2>
            {loadingFoods ? (
                <p>A carregar alimentos...</p>
            ) : (
                <FoodList
                    foods={foods}
                    token={token}
                    userSelectionIds={userSelectionIds}
                    onSelectionAdded={handleSelectionAdded}
                    onSelectionRemoved={handleSelectionRemoved}
                />

            )}
        </div>
    );
}

export default FoodPage;