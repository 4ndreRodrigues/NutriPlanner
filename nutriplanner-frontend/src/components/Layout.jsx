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
                <Link className="navbar-brand" to="/">
                    NutriPlanner
                </Link>
                <div className="navbar-links">
                    {token ? (
                        <>
                            <Link to="/profile">Perfil</Link>
                            <button onClick={handleLogout}>Sair</button>
                        </>
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
                        <Link to="/foods">Alimentos</Link>
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