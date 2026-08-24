import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import DietList from "../components/DietList";
import FoodListByDiet from "../components/FoodListByDiet";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function DietFoodsPage({ token }) {
    const [diets, setDiets] = useState([]);
    const [foods, setFoods] = useState([]);
    const [loadingDiets, setLoadingDiets] = useState(true);
    const [loadingFoods, setLoadingFoods] = useState(false);
    const [userSelectionIds, setUserSelectionIds] = useState(new Set());
    const { dietId } = useParams();
    const navigate = useNavigate();
    const currentDiet = diets.find((diet) => diet.id === Number(dietId));

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
        fetch(`${API_URL}/diets`)
        .then(response => {
            if (!response.ok) throw new Error("Error fetching diets");
            return response.json();
        })
        .then(data => {
            setDiets(data);
            setLoadingDiets(false);
        })
        .catch ((err) => {
            console.error("Erro ao ir buscar dietas:", err);
            setLoadingDiets(false);
        });
    }, []);

    useEffect(() => {
        if (!token) return;

        fetch(`${API_URL}/UserFoods`, {
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

    // corre sempre que "dietId" muda — vai buscar os alimentos dessa dieta
    useEffect(() => {
        setLoadingFoods(true);
        fetch(`${API_URL}/diets/${dietId}/foods`)
        .then((response) => response.json())
        .then((data) => {
            setFoods(data);
            setLoadingFoods(false);
        });
    }, [dietId]);

    return (
        <div className="page-content">
            <div className="diet-switcher">
                <h2>Dieta</h2>
                <select value={dietId} onChange={(e) => navigate(`/diets/${e.target.value}`)}>
                    {diets.map((diet) => (
                        <option key={diet.id} value={diet.id}>
                            {diet.name}
                        </option>
                    ))}
                </select>
                <p className="diet-description">{currentDiet?.description}</p>
            </div>

            {dietId !== null && (
                <>
                    <h2>Alimentos</h2>
                    {loadingFoods ? (
                        <p>A carregar alimentos...</p>
                    ) : (
                        <FoodListByDiet
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

export default DietFoodsPage;