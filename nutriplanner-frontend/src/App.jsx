import { useState, useEffect } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import DietPage from "./pages/DietPage";
import "./App.css";

function App() {

    const [token, setToken] = useState(null);

    return (
        <Routes>
            <Route path="/" element={<Navigate to="/login" />} />
            <Route path="/login" element={<LoginPage onLoginSuccess={setToken} />} />
            <Route path="/diets" element={token ? <DietPage token={token} /> : <Navigate to="/login" />} />
        </Routes>
    );
}

export default App;