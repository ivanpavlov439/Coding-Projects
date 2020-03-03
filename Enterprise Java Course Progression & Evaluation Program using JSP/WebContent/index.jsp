<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8" isErrorPage="true"%>
	
<!-- Adding tablibs into jsp page -->
<%@ taglib prefix="sql" uri="http://java.sun.com/jsp/jstl/sql"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>

<!DOCTYPE html>

<!-- 
Name: Ivan Pavlov
Assignment 3
The jsp page that contains all form info and
calls the AddEvaluation servlet to process the form data.
-->

<html lang="en">
<head>
<meta charset="utf-8">
<meta name="author" content="Ivan Pavlov">
<meta name="description" content="Assignment 3 Index Page for PROG32758">
<title>Add New Evaluation Page</title>
<link type="text/css" rel="stylesheet" href="css/a2.css">
</head>
<body>
	<h1>Add New Evaluations</h1>
	
	<!--Using a tag to link to the ListEvaluations Servlet-->
	<a href="ListEvaluations">List All Evaluations</a>
	
	<!--Display error page if there are any errors-->
	<c:if test="${!empty sessionScope.errors}">
		<div class="errors">${pageContext.exception.message}</div>
	</c:if>

	<!--Accessing the tracker database-->
	<sql:setDataSource var="courseData" driver="com.mysql.cj.jdbc.Driver"
		url="${initParam.dbUrl}${initParam.dbName}?serverTimezone=UTC"
		user="${initParam.user}" password="${initParam.passwd}" />
	<sql:query var="results" dataSource="${courseData}"
		sql="SELECT * FROM courses;" />
		
	<form>
		<label for="selectCourse">Course:
		
			<!--Displaying all the courses within the courses database-->
			<select name="selectCourse">
				<c:forEach var="course" items="${results.rows}">
					<option value="${course.code}" 
					<c:if test="${sessionScope.course == course.code}">selected
					</c:if>>${course.code}: ${course.title}</option>
				</c:forEach>
			</select>
		</label> <br>
		
		<!--Displaying Evaluation Name input-->
		<label for="evalName">Evaluation Name:
			<input type="text" name="evalName" value="${sessionScope.eval}">
		</label> <br>
		
		<!--Displaying year input-->
		<label>Due Date (yyyy/mm/dd)</label>
		<label for="year">Year:
			<input type="text" name="year" value="${sessionScope.year}">
		</label>
		
		<label for="month">Month:
			
			<!--Using taglibs to display the month dropdown-->
			<select name="month">
				<c:forEach var="counter" begin="1" end="12" step="1">
					<option value="${counter}"
					<c:if test="${sessionScope.month == counter}">selected
					</c:if>>${counter}</option>
				</c:forEach>
			</select>
		</label>
		
		<label for="day">Day:
		
			<!--Using taglibs to display the day dropdown-->
			<select name="day">
				<c:forEach var="counter" begin="1" end="31" step="1">
					<option value="${counter}"
					<c:if test="${sessionScope.day == counter}">selected
					</c:if>>${counter}</option>
				</c:forEach>
			</select>
		</label> <br>
		
		<!--Using taglib to display the chosen submission option-->
		<fieldset>
			<legend>Submitted</legend>
			<label for="submit">
				<input type="radio" name="submit" value="true"
				<c:if test="${sessionScope.submitted == true}">checked
				</c:if>>Submitted
				<input type="radio" name="submit" value="false"
				<c:if test="${sessionScope.submitted == false}">checked
				</c:if>>Not Submitted
			</label>
		</fieldset> <br>
		
		<!--Button that when pressed, goes to AddEvaluation servlet-->
		<button formaction="AddEvaluation">Calculate</button>
			
		<button type="reset">Clear</button>
	</form>
</body>
</html>