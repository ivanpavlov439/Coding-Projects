<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    
<!-- Adding tablibs into jsp page -->
<%@ taglib prefix="sql" uri="http://java.sun.com/jsp/jstl/sql"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>

<!DOCTYPE html>

<!-- 
Name: Ivan Pavlov
Assignment 3
The jsp page that contains displays all data from the 
evaluations database.
-->

<html lang="en">
<head>
<meta charset="utf-8">
<meta name="author" content="Ivan Pavlov">
<meta name="description" content="Assignment 3 List Evaluation Page for PROG32758">
<title>List Evaluation Page</title>

<!--Getting the css for this jsp page to format table-->
<link type="text/css" rel="stylesheet" href="css/a3.css">
</head>
<body>
	<h1>Evaluation Tracker</h1>
	
	<!--Using a tag to link to main index page-->
	<a href="index.jsp">Add An Evaluation</a>
	
	<!--Creating a table for all my evaluations-->
	<table>
		<tr>
			<th>Course</th>
			<th>Evaluation</th>
			<th>Due Date</th>
			<th>Submitted?</th>
		</tr>
		
		<!--Using taglibs to display all info needed in the table-->
		<c:forEach var="eval" items="${sessionScope.evals}">
			<tr>
				<td>${eval.course.code} <br> ${eval.course.title}</td>
				<td>${eval.evalName}</td>
				<td>${eval.dueDate}</td>
				<td>${eval.submitted}</td>
			</tr>
		</c:forEach>
	</table>
</body>
</html>