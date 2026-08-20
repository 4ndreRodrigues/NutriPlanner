import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import DietList from "../components/DietList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function DietPage({ token, handleDietSelection}) {
    const [diets, setDiets] = useState([]);
    const [selectedDietId, setSelectedDietId] = useState(null);
    const [foods, setFoods] = useState([]);
    const [loadingDiets, setLoadingDiets] = useState(true);
    const [loadingFoods, setLoadingFoods] = useState(false);
    const [userSelectionIds, setUserSelectionIds] = useState(new Set());
    const navigate = useNavigate();

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


    return (
        <div className="page-content">
            <h2>Escolhe a tua dieta</h2>
            {loadingDiets ? (
                <p>A carregar...</p>
            ) : (
                    <DietList
                        diets={diets}
                        token={token}
                        onSelectDiet={handleDietSelection}
                    />
            )}

        </div>
    );
}

export default DietPage;