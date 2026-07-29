import { Link } from "react-router-dom";

function HomePage() {

    return (
        <div className="home-hero">
            <h1>NutriPlanner</h1>
            <p>Escolhe a tua dieta, encontra os alimentos certos, e acompanha os teus macros.</p>
            <div className="home-actions">
                <Link to="/login" className="btn-primary">Entrar</Link>
                <Link to="/register" className="btn-secondary">Criar conta</Link>
            </div>
        </div>
    );
}

export default HomePage;