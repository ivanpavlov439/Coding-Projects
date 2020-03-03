<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
	
<!DOCTYPE html>

<!-- 
Name: Ivan Pavlov
Assignment 3
The login jsp page checks for a correct user login
-->

<html lang="en">
<head>
<meta charset="utf-8">
<meta name="author" content="Ivan Pavlov">
<meta name="description" content="Assignment 3 Login Page for PROG32758">
<title>Login Page</title>
</head>
<body>
	<form method="post" action="j_security_check">

		<label for="username">User Name: <input type="text"
			id="username" name="j_username">
		</label> <br>
		
		<label for="passwd">Password: <input type="password"
			id="passwd" name="j_password">
		</label> <br>
		
		<button type="submit">Log In</button>
	</form>
</body>
</html>