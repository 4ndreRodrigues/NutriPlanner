import { Outlet, Link, useNavigate } from "react-router-dom";

function Layout({ token, onLogout }) {
    const navigate = useNavigate();

    function handleLogout() {
        onLogout();
        navigate("/");
    }

    return (
        <div className="app-shell">
            <nav className="navbar">
                <span className="navbar-brand">NutriPlanner</span>
                <div className="navbar-links">
                    {token ? (
                        <button onClick={handleLogout}>Sair</button>
                    ) : (
                        <>
                            <Link to="/login">Entrar</Link>
                            <Link to="/register">Registar</Link>
                        </>
                    )}
                </div>
            </nav>

            <div className="app-body">
                {token && (
                    <aside className="sidebar">
                        <Link to="/diets">Dietas</Link>
                        <Link to="/selections">A minha seleção</Link>
                    </aside>
                )}

                <main className="main-content">
                    <Outlet />
                </main>
            </div>
        </div>
    );
}


export default Layout;