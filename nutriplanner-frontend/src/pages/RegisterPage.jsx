import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import RegisterForm from "../components/RegisterForm";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function RegisterPage() {
    const [error, setError] = useState(null);
    const navigate = useNavigate();


    function onRegister(email, password, name, lastName, birthDate ) {
        fetch(`${API_URL}/auth/register`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password, name, lastName, birthDate }),
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
            <RegisterForm onRegister={onRegister} error={error} />
        </div>
    );
}

export default RegisterPage;