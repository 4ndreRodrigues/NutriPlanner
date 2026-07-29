import { useState } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Layout from "./components/Layout";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import DietPage from "./pages/DietPage";
import UserSelectionPage from "./pages/UserSelectionPage";
import "./App.css";

function App() {
    const [token, setToken] = useState(() => localStorage.getItem("token"));

    function handleSetToken(newToken) {
        if (newToken) {
            localStorage.setItem("token", newToken);
        } else {
            localStorage.removeItem("token");
        }
        setToken(newToken);
    }

    return (
        <Routes>
            <Route element={<Layout token={token} onLogout={() => handleSetToken(null)} />}>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage onLoginSuccess={handleSetToken} />} />
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/diets" element={token ? <DietPage token={token} /> : <Navigate to="/login" />} />
                <Route path="/selections" element={token ? <UserSelectionPage token={token} /> : <Navigate to="/login" />} />
            </Route>
        </Routes>
    );
}

export default App;