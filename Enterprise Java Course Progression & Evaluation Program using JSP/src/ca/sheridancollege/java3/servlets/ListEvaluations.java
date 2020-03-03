package ca.sheridancollege.java3.servlets;

/* Name: Ivan Pavlov
 * Assignment: Assignment 3
 * Program: Computer Programmer
 * Course: PROG32758
 
 * This is a servlet that gets all evaluations from the 
 * database and redirects to the listEvals.jsp page to
 * display all the rows in the database.
 */

import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;

import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import ca.sheridancollege.java3.classes.Evaluation;
import ca.sheridancollege.java3.db.DaoEvaluations;

/**
 * Servlet implementation class ListEvaluations
 */
@WebServlet("/ListEvaluations")
public class ListEvaluations extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public ListEvaluations() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		// Retrieving the database from application scope and
		// creating an empty ArrayList of Evaluation objects
		ServletContext sc = request.getServletContext();
		DaoEvaluations db = (DaoEvaluations) sc.getAttribute("database");
		ArrayList<Evaluation> evals = null;
		try {
			
			//Calling the DAO method to populate the ArrayList
			evals = db.getEvaluations();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		//Stores ArrayList into the session scope and redirects the user
		//to the listEvals.jsp page
		HttpSession session = request.getSession();
		session.removeAttribute("errors");
		session.setAttribute("evals", evals);
		response.sendRedirect("listEvals.jsp");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
