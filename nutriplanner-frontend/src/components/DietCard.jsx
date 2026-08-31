import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const API_URL = "https://localhost:7250/api";

function DietCard({ diet, token, onSelect }) {
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    function handleSelect() {
        fetch(`${API_URL}/users/me/diet/${diet.id}`, {
            method: "PUT",
            headers: {
                Authorization: `Bearer ${token}`
            }
            })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao selecionar dieta");

                onSelect(diet.id);
                navigate(`/healthconditions`);
            })      
            .catch((err) => {
                console.error(err);
                setError("Erro ao selecionar dieta");
            });
    }
    return (
        <li className="diet-card" onClick={handleSelect}>
            {diet.name}
            <div className="diet-tooltip">
                {diet.description}
            </div>
        </li> 
        )
}

export default DietCard;