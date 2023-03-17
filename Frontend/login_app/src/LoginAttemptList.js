import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttemptList = (props) => {
	
	let attempts = props.attempts;
	let attemptList = attempts.map((attempt) =>  <li key={attempt}>{attempt}</li>);

return(
	<div className="Attempt-List-Main">
	 	<p>Recent activity</p>
	  	<input type="input" placeholder="Filter..." />
		<ul className="Attempt-List">{attemptList}</ul>
	</div>
	)
}

export default LoginAttemptList;