import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import LoginForm from "../components/LoginForm";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function LoginPage({ onLoginSuccess }) {
    const [error, setError] = useState(null);
    const navigate = useNavigate();


    function onLogin(email, password) {
        fetch(`${API_URL}/auth/login`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password }),
        })
        .then(response => response.json())
        .then(data => {
            onLoginSuccess(data.token);
            navigate("/diets");
        })
        .catch((err) => {
            console.error("Erro ao fazer login:", err);
        });
     }


    return (
        <div className="container">
            <h1>NutriPlanner</h1>
            <LoginForm onLogin={onLogin} />
        </div>
    );
}

export default LoginPage;