import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = (props) => {

	const [name, setName] = useState('');

	const handleSubmit = (event) =>{
		event.preventDefault();

		props.onSubmit({
			login: name,
			password: '',
		});
	}

	return (
		<form className="form">
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" id="name" value={name} onChange={(e) => setName(e.target.value)} />
			<label htmlFor="password">Password</label>
			<input type="password" id="password" />
			<button type="submit" onClick={handleSubmit}>Continue</button>
		</form>
	)
}

export default LoginForm;