package ca.sheridancollege.java3.db;

/* Name: Ivan Pavlov
 * Assignment: Assignment 3
 * Program: Computer Programmer
 * Course: PROG32758
 
 * This is a DAO object that manages both the 
 * courses and evaluation databases.
 */

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.time.LocalDate;
import java.util.ArrayList;

import ca.sheridancollege.java3.classes.Course;
import ca.sheridancollege.java3.classes.Evaluation;

public class DaoEvaluations {
	
	//Declaring all instance variables
	private String DB_URL;
	private String dbName;
	private String user;
	private String pass;

	//Default Constructor
	public DaoEvaluations() throws ClassNotFoundException {
		Class.forName("com.mysql.cj.jdbc.Driver");
	}

	//Main Constructor that sets all the instance variables
	public DaoEvaluations(String url, String name, String user, String pass) throws ClassNotFoundException {
		this.DB_URL = url;
		this.dbName = name;
		this.user = user;
		this.pass = pass;
		Class.forName("com.mysql.cj.jdbc.Driver");
	}

	//Method to connect to the databases
	private Connection getConnection() throws SQLException {
		return DriverManager.getConnection(DB_URL + dbName + "?serverTimezone=UTC", user, pass);
	}
	
	//Method to insert evaluations into database
	public int insertEvaluationQuery(Evaluation eval) throws SQLException {
		
		//Start the connection
		Connection con = getConnection();
		
		//SQL string
		String sql = "INSERT INTO evaluations "
				+ "(course_code, eval_name, due_date, submitted ) "
				+ "VALUES (?,?,?,?);";

		//Using a prepared statement to set all the values
		PreparedStatement stmt = con.prepareStatement(sql);
		stmt.setString(1, eval.getCourse().getCode());
		stmt.setString(2, eval.getEvalName());
		stmt.setDate(3, Date.valueOf(eval.getDueDate()));
		stmt.setBoolean(4, eval.isSubmitted());
		int results = stmt.executeUpdate();

		//Close the connection and return results
		con.close();

		return results;

	}
	
	//Method to return ArrayList of all evaluations
	public ArrayList<Evaluation> getEvaluations() throws SQLException {
		
		//Start the connection
		Connection con = getConnection();
		
		//SQL String
		String sql = "SELECT evaluations.*, courses.title " + 
				"FROM evaluations " + 
				"INNER JOIN courses ON "
				+ "evaluations.course_code = courses.code " + 
				"ORDER BY due_date;";
		
		//Executing statement and creating ArrayList
		ArrayList<Evaluation> evals = new ArrayList<Evaluation>();
		Statement stmt = con.createStatement();
		ResultSet results = stmt.executeQuery(sql);

		//While loop to go through each record and add evaluation object to ArrayList
		while (results.next()) {
			Course course = createCourse(results.getString("course_code"));
			String evalName = results.getString("eval_name");
			LocalDate date = results.getDate("due_date").toLocalDate();
			Boolean submitted = results.getBoolean("submitted");
			Evaluation e = new Evaluation(course, evalName, date, submitted);
			evals.add(e);
		}

		//Close connection and return ArrayList
		con.close();

		return evals;
	}
	
	//Method that returns a Course Object based on the code given
	public Course createCourse(String code) throws SQLException {
		
		//Open connection and create an empty course
		Connection con = getConnection();
		Course c = new Course();
		
		//SQL String
		String sql = "SELECT * FROM courses;";

		//Executing Query
		Statement stmt = con.createStatement();
		ResultSet results = stmt.executeQuery(sql);
		
		//setting course title and code
		while (results.next()) {
			String checkCode = results.getString("code");
			if (code.equalsIgnoreCase(checkCode)) {
				String title = results.getString("title");
				c.setCode(code);
				c.setTitle(title);
			}
		}
		
		//Close Connection and return the course
		con.close();
		return c;
	}
}
