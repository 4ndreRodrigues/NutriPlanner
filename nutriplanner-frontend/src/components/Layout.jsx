import { Outlet, Link, NavLink, useNavigate } from "react-router-dom";

function Layout({ token, lastDietId, onLogout }) {
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
                        <NavLink to={lastDietId ? `/diets/${lastDietId}` : "/diets"}>Dietas</NavLink>
                        <NavLink to="/selections">A minha seleção</NavLink>
                        <NavLink to="/foods">Alimentos</NavLink>
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