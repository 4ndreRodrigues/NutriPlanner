import { useState, useEffect } from "react";
import UserSelectionList from "../components/UserSelectionList";
import "../App.css";

const API_URL = "https://localhost:7250/api";

function UserSelectionPage({ token }) {
    const [userSelections, setUserSelections] = useState([]);
    const [loadingFoods, setLoadingFoods] = useState(false);

    function handleSelectionRemoved(foodId) {
        setUserSelections((prev) => prev.filter((s) => s.foodId !== foodId));
    }

    useEffect(() => {
        if (!token) return;
        setLoadingFoods(true);
        fetch(`${API_URL}/UserFoods`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        .then((res) => res.json())
        .then((data) => {
            setUserSelections(data);
            setLoadingFoods(false);
        })
        .catch ((err) => {
            console.error("Erro ao ir buscar seleções do utilizador:", err);
            setLoadingFoods(false);
        });
    }, [token]);

    return (
        <div className="page-content">
            <h2>Minha Seleção</h2>
            {loadingFoods ? (
                <p>Carregando seleções...</p>
            ) : (
                <UserSelectionList
                    userSelections={userSelections}
                    token={token}
                    onSelectionRemoved={handleSelectionRemoved}
                />
            )}
        </div>
    );
}

export default UserSelectionPage;