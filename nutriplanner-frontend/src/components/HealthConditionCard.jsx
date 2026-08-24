import { useState } from "react";

const API_URL = "https://localhost:7250/api";

function HealthConditionCard({ healthCondition, token, isActive, onSelectionAdded, onSelectionRemoved }) {
    const [error, setError] = useState(null);

    function handleSelect() {
        fetch(`${API_URL}/UserHealthCondition`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify({ healthConditionId: healthCondition.id })
        })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao selecionar condição de saúde");
                return res.json();
            })
            .then(() => {
                onSelectionAdded(healthCondition.id);
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao selecionar condição de saúde");
            });
    }

    function handleDeselect() {
        fetch(`${API_URL}/UserHealthCondition/${healthCondition.id}`, {
            method: "DELETE",
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
            .then((res) => {
                if (!res.ok) throw new Error("Erro ao remover condição de saúde");
                onSelectionRemoved(healthCondition.id);
            })
            .catch((err) => {
                console.error(err);
                setError("Erro ao remover condição de saúde");
            });
    }
    return (
        <li
            className={`healthcondition-card ${isActive ? "active" : ""}`}
            onClick={isActive ? handleDeselect : handleSelect}
            style={{ cursor: "pointer" }}
        >
            {healthCondition.name}

            {error && <span style={{ color: "red", fontSize: "0.8rem" }}>({error})</span>}

            <div className="healthcondition-tooltip">
                {healthCondition.description}
            </div>
        </li>
    );
}

export default HealthConditionCard;