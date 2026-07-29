import { useState } from "react";

function RegisterForm({ onRegister }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    return (
        <div>
            <h1 >Register</h1>
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
            <input 
                type="password"
                placeholder="Confirm Password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
            />
            {confirmPassword !== password && (
                <p style={{ color: 'red' }}>As passwords não coincidem</p>
            )}

            <button
                disabled={confirmPassword !== password}
                onClick={() => onRegister(email, password)}
            >
                Register
            </button>
        </div>
    );
}

export default RegisterForm;