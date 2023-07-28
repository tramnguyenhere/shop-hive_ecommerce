import React, { useState } from "react";

import useAppDispatch from "../../hooks/useAppDispatch";
import { login } from "../../redux/reducers/usersReducer";

const LoginForm = () => {
  const dispatch = useAppDispatch();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = (e: React.FormEvent) => {
    e.preventDefault();
    dispatch(login({ email, password }));
    setEmail("");
    setPassword("");
  };
  return (
    <form className="form">
      <div className="form__section">
        <label>Email</label>
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <div className="form__section">
        <label>Password</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>
      <button
        className="full-width-button__primary"
        type="button"
        onClick={handleLogin}
      >
        Login
      </button>
    </form>
  );
};

export default LoginForm;
