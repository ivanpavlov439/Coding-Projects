package ca.sheridancollege.java3.servlets;

/* Name: Ivan Pavlov
 * Assignment: Assignment 3
 * Program: Computer Programmer
 * Course: PROG32758
 
 * This is a servlet that takes info from a form and 
 * creates an Evaluation object and than inserts that
 * object into the evaluations database.
 */

import java.io.IOException;
import java.sql.SQLException;
import java.time.LocalDate;

import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import ca.sheridancollege.java3.classes.Course;
import ca.sheridancollege.java3.classes.Evaluation;
import ca.sheridancollege.java3.db.DaoEvaluations;

/**
 * Servlet implementation class AddEvaluation
 */
@WebServlet("/AddEvaluation")
public class AddEvaluation extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public AddEvaluation() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		// Creating a session and removing errors from the session scope
		HttpSession session = request.getSession();
		session.removeAttribute("errors");

		// Declaring all variables needed
		String courseCode = request.getParameter("selectCourse");
		String evalName = request.getParameter("evalName");
		String year = request.getParameter("year");
		String month = request.getParameter("month");
		String day = request.getParameter("day");
		String submitted = request.getParameter("submit");
		String errors = "";

		// Setting all session attributes for form to remember input
		setSessionAttributes(session, courseCode, evalName, year, month, day, submitted);

		// Checking eval field if its empty
		if (evalName == null || evalName.trim().isEmpty()) {
			errors += "Evaluation name can't be empty!<br>";
		}

		// Checking year field if its empty
		if (year == null || year.trim().isEmpty()) {
			errors += "Year field can't be empty!<br>";
		}

		// Checking year field if its an actual year
		if (!year.matches("^-?[0-9]+$") || year.length() != 4) {
			errors += "Year format is incorrect! Input only 4 digits!<br>";
		}

		// Checking submitted field if its empty
		if (submitted == null || submitted.trim().isEmpty()) {
			errors += "Submitted field can't be empty!<br>";
		}

		try {

			// Checking to see if their are any errors
			if (!errors.isEmpty()) {

				// Setting a session attribue for errors than
				// throwing a servlet exception
				session.setAttribute("errors", errors);
				throw new ServletException((String) session.getAttribute("errors"));
			} else {

				// Removing all session attributes relating to the form
				removeSessionAttributes(session);

				// Converting my string date to LocalDate
				LocalDate d = LocalDate.of(Integer.parseInt(year), Integer.parseInt(month), Integer.parseInt(day));

				// Retrieving the database from application scope and
				// creating the course using the method in the DAO
				ServletContext sc = request.getServletContext();
				DaoEvaluations db = (DaoEvaluations) sc.getAttribute("database");
				Course course = db.createCourse(courseCode);

				// Creating an Evaluation object and inserting into the
				// database than redirect to the ListEvaluations servlet
				Boolean submit = Boolean.valueOf(submitted);
				Evaluation eval = new Evaluation(course, evalName, d, submit);
				db.insertEvaluationQuery(eval);
				response.sendRedirect("ListEvaluations");

			}
		} catch (IllegalArgumentException e) {

			// Appends the exception message to errors, sets session attribute,
			// than throws new servlet exception back to the index page
			errors += e.getLocalizedMessage();
			session.setAttribute("errors", errors);
			throw new ServletException((String) session.getAttribute("errors"));
		} catch (SQLException e) {

			// Appends the exception message to errors, sets session attribute,
			// than throws new servlet exception back to the index page
			errors += e.getLocalizedMessage();
			session.setAttribute("errors", errors);
			throw new ServletException((String) session.getAttribute("errors"));
		}
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

	// Method that removes the session attributes
	private void removeSessionAttributes(HttpSession session) {
		session.removeAttribute("course");
		session.removeAttribute("eval");
		session.removeAttribute("year");
		session.removeAttribute("month");
		session.removeAttribute("day");
		session.removeAttribute("submitted");
	}

	// Method that sets all the required session attributes
	private void setSessionAttributes(HttpSession session, String courseCode, String evalName, String year,
			String month, String day, String submitted) {
		session.setAttribute("course", courseCode);
		session.setAttribute("eval", evalName);
		session.setAttribute("year", year);
		session.setAttribute("month", month);
		session.setAttribute("day", day);
		session.setAttribute("submitted", submitted);
	}

}
