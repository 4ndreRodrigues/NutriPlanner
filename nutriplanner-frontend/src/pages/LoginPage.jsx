import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import LoginForm from "../components/LoginForm";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function LoginPage({ onLoginSuccess, onDietIdSuccess }) {
    const [error, setError] = useState(null);
    const [conditions, setConditions] = useState([]);
    const navigate = useNavigate();

    function healthConditionCheck() {
        fetch(`${API_URL}/UserHealthCondition`, { headers: { Authorization: `Bearer ${token}` } })
            .then((res) => res.json())
            .then(setConditions);
    }


    function onLogin(email, password) {
        fetch(`${API_URL}/auth/login`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password }),
        })
        .then(res => res.json())
        .then(data => {
            onLoginSuccess(data.token);
            healthConditionCheck();
            if (data.dietId == null) {
                navigate("/diets");
            }
            else {
                onDietIdSuccess(data.dietId);
                navigate("/");
            }
        })
        .catch((err) => {
            console.error("Erro ao fazer login:", err);
        });
     }


    return (
        <div className="container">
            <LoginForm onLogin={onLogin} />
        </div>
    );
}

export default LoginPage;