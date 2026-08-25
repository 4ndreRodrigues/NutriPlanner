import { useState } from "react";

function LoginForm({ onLogin }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    return (
        <div className="auth-card">
            <h2>Login</h2>
            <div className="auth-form">
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <button className="btn-solid" onClick={() => onLogin(email, password)}>Entrar</button>
            </div>
        </div>
    );
}

export default LoginForm;