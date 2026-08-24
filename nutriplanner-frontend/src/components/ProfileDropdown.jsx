import { useState, useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";

function ProfileDropdown({ onLogout }) {
    const [isOpen, setIsOpen] = useState(false);
    const dropdownRef = useRef(null);
    const navigate = useNavigate();

    // fecha o dropdown se clicares fora dele
    useEffect(() => {
        function handleClickOutside(event) {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
                setIsOpen(false);
            }
        }

        document.addEventListener("mousedown", handleClickOutside);
        return () => document.removeEventListener("mousedown", handleClickOutside);
    }, []);

    function handleLogout() {
        setIsOpen(false);
        onLogout();
        navigate("/");
    }

    return (
        <div className="profile-dropdown" ref={dropdownRef}>
            <button className="profile-trigger" onClick={() => setIsOpen((prev) => !prev)}>
                Perfil ▾
            </button>

            {isOpen && (
                <div className="profile-menu">
                    <Link to="/profile" onClick={() => setIsOpen(false)}>O meu perfil</Link>
                    <Link to="/selections" onClick={() => setIsOpen(false)}>A minha seleção</Link>
                    <button onClick={handleLogout}>Sair</button>
                </div>
            )}
        </div>
    );
}

export default ProfileDropdown;