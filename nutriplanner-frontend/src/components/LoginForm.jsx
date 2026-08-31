import { useState } from "react";

function LoginForm({ onLogin }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    return (
        <div className="auth-card">
            <div className="auth-header">
                <h2>Entrar</h2>
                <p>Entre na sua conta para continuar</p>
            </div>

            <div className="auth-form">

                <div className="form-group">
                    <label>Email</label>
                    <input
                        type="email"
                        placeholder="nome@exemplo.com"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>

                <div className="form-group">
                    <label>Palavra-passe</label>
                    <input
                        type="password"
                        placeholder="************"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button className="btn-solid" onClick={() => onLogin(email, password)}>Entrar</button>
            </div>
        </div>
    );
}

export default LoginForm;