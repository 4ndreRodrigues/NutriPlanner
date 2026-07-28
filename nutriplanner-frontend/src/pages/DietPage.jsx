import { useState, useEffect } from "react";
import DietList from "../components/DietList";
import FoodList from "../components/FoodList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function DietPage() {
    const [diets, setDiets] = useState([]);
    const [selectedDietId, setSelectedDietId] = useState(null);
    const [foods, setFoods] = useState([]);
    const [loadingDiets, setLoadingDiets] = useState(true);
    const [loadingFoods, setLoadingFoods] = useState(false);

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
            <h1>NutriPlanner</h1>

            <h2>Escolhe a tua dieta</h2>
            {loadingDiets ? (
                <p>A carregar...</p>
            ) : (
                <DietList diets={diets} onSelectDiet={setSelectedDietId} />
            )}

            {selectedDietId !== null && (
                <>
                    <h2>Alimentos</h2>
                    {loadingFoods ? <p>A carregar alimentos...</p> : <FoodList foods={foods} />}
                </>
            )}
        </div>
    );
}

export default DietPage;