import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import DietList from "../components/DietList";
import FoodListByDiet from "../components/FoodListByDiet";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function DietPage({ token }) {
    const [diets, setDiets] = useState([]);
    const [selectedDietId, setSelectedDietId] = useState(null);
    const [foods, setFoods] = useState([]);
    const [loadingDiets, setLoadingDiets] = useState(true);
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

    // corre sempre que "selectedDietId" muda — vai buscar os alimentos dessa dieta
    useEffect(() => {
        if (selectedDietId === null) return; // ainda não escolheu nenhuma dieta

        setLoadingFoods(true);
        fetch(`${API_URL}/diets/${selectedDietId}/foods`)
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            setFoods(data);
            setLoadingFoods(false);
        });
    }, [selectedDietId]); // <- este array diz "corre outra vez sempre que isto mudar"

    return (
        <div className="container">
            <h2>Escolhe a tua dieta</h2>
            {loadingDiets ? (
                <p>A carregar...</p>
            ) : (
                <DietList diets={diets} onSelectDiet={setSelectedDietId} />
            )}

            {selectedDietId !== null && (
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

export default DietPage;