import { useState } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Layout from "./components/Layout";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import DietPage from "./pages/DietPage";
import DietFoodsPage from "./pages/DietFoodsPage";
import UserSelectionPage from "./pages/UserSelectionPage";
import FoodPage from "./pages/FoodPage";
import HealthConditionFoodsPage from "./pages/HealthConditionFoodsPage";
import HealthConditionsPage from "./pages/HealthConditionsPage";
import ProfilePage from "./pages/ProfilePage";
import "./App.css";

function App() {
    const [token, setToken] = useState(() => localStorage.getItem("token"));
    const [lastDietId, setLastDietId] = useState(() => localStorage.getItem("dietId"));

    function handleSetToken(newToken) {
        if (newToken) {
            localStorage.setItem("token", newToken);
        } else {
            localStorage.removeItem("token");
        }
        setToken(newToken);
    }

    function handleSetDietId(newDietId) {
        if (newDietId) {
            localStorage.setItem("dietId", newDietId);
        } else {
            localStorage.removeItem("dietId");
        }
        setLastDietId(newDietId);
    }


    return (
        <Routes>
            <Route element={<Layout token={token} lastDietId={lastDietId} onLogout={() => handleSetToken(null)} />}>
                <Route path="/" element={<HomePage token={token} />} />
                <Route path="/login" element={<LoginPage onLoginSuccess={handleSetToken} onDietIdSuccess={handleSetDietId} />} />
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/diets" element={token ? <DietPage token={token} handleDietSelection={handleSetDietId} /> : <Navigate to="/login" />} />
                <Route path="/diets/:dietId" element={token ? <DietFoodsPage token={token} /> : <Navigate to="/login" />} />
                <Route path="/healthconditionfoods" element={token ? <HealthConditionFoodsPage token={token} /> : <Navigate to="/login" />} />
                <Route path="/healthconditions" element={token ? <HealthConditionsPage token={token} /> : <Navigate to="/login" />} />
                <Route path="/selections" element={token ? <UserSelectionPage token={token} /> : <Navigate to="/login" />} />
                <Route path="/foods" element={token ? <FoodPage token={token} /> : <Navigate to="/login" />} />
                <Route path="/profile" element={token ? <ProfilePage token={token} handleDietSelection={handleSetDietId} /> : <Navigate to="/login" />} />
            </Route>
        </Routes>
    );
}

export default App;