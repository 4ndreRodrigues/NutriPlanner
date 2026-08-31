import { useState } from "react";

function RegisterForm({ onRegister, error }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [name, setName] = useState("");
    const [lastName, setLastName] = useState("");
    const [birthDate, setBirthDate] = useState("");

    const isPasswordMatch = confirmPassword.length === 0 || confirmPassword === password;
    const isFormValid = email && password && name && birthDate && (password === confirmPassword);

    return (
        <div className="auth-card">
            <div className="auth-header">
                <h2>Criar conta</h2>
                <p>Comece a planear a sua nutrição de forma inteligente</p>
            </div>

            <div className="auth-form">
                <div className="form-row">
                    <div className="form-group">
                        <label>Primeiro nome</label>
                        <input
                            type="text"
                            placeholder="Ex: Joaquim"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                        />
                    </div>

                    <div className="form-group">
                        <label>Último nome</label>
                        <input
                            type="text"
                            placeholder="Ex: Fernandes"
                            value={lastName}
                            onChange={(e) => setLastName(e.target.value)}
                        />
                    </div>
                </div>

                <div className="form-group">
                    <label>Data de nascimento</label>
                    <input
                        type="date"
                        value={birthDate}
                        onChange={(e) => setBirthDate(e.target.value)}
                    />
                </div>

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
                        placeholder="Mínimo 6 caracteres"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>

                <div className="form-group">
                    <label>Confirmar palavra-passe</label>
                    <input
                        type="password"
                        placeholder="Repita a palavra-passe"
                        value={confirmPassword}
                        onChange={(e) => setConfirmPassword(e.target.value)}
                    />
                    {!isPasswordMatch && (
                        <p className="field-error">As palavras-passe não coincidem</p>
                    )}
                </div>

                {error && (
                    <div className="auth-error-banner">
                        ⚠️ {error}
                    </div>
                )}

                <button
                    className={`btn-solid btn-full ${!isFormValid ? 'btn-disabled' : ''}`}
                    disabled={!isFormValid}
                    onClick={() => {
                        console.log("A enviar dados:", { email, password, name, lastName, birthDate });
                        onRegister(email, password, name, lastName, birthDate)
                    }}
                >
                    Criar Conta
                </button>
            </div>
        </div>
    );
}

export default RegisterForm;