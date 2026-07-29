import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import RegisterForm from "../components/RegisterForm";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function RegisterPage() {
    const [error, setError] = useState(null);
    const navigate = useNavigate();


    function onRegister(email, password) {
        fetch(`${API_URL}/auth/register`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password }),
        })
        .then(res => res.json())
        .then(data => {
            if (data.succeeded == false) {
                setError(data.errors[0].description);
            } else {
                navigate("/login");
            }
        })
        .catch((err) => {
            console.error("Erro ao fazer registro:", err);
        });
     }


    return (
        <div className="container">
            <h1>NutriPlanner</h1>
            {error && <p className="food-error">{error}</p>}
            <RegisterForm onRegister={onRegister} />
        </div>
    );
}

export default RegisterPage;