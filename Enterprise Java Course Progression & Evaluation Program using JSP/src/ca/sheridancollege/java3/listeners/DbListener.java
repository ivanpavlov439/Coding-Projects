package ca.sheridancollege.java3.listeners;

/* Name: Ivan Pavlov
 * Assignment: Assignment 3
 * Program: Computer Programmer
 * Course: PROG32758
 
 * This is a ServletContextListener which creates a DAO
 * when the application starts and deletes it from the scope 
 * when the application terminates.
 */

import javax.servlet.ServletContext;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;
import javax.servlet.annotation.WebListener;

import ca.sheridancollege.java3.db.DaoEvaluations;

/**
 * Application Lifecycle Listener implementation class DbListener
 *
 */
@WebListener
public class DbListener implements ServletContextListener {

	/**
	 * Default constructor.
	 */
	public DbListener() {
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see ServletContextListener#contextDestroyed(ServletContextEvent)
	 */
	public void contextDestroyed(ServletContextEvent sce) {
		
	}

	/**
	 * @see ServletContextListener#contextInitialized(ServletContextEvent)
	 */
	public void contextInitialized(ServletContextEvent sce) {
		
		//Getting the context params and creating a new DAO Object
		ServletContext sc = sce.getServletContext();
		String dbUrl = sc.getInitParameter("dbUrl");
		String dbName = sc.getInitParameter("dbName");
		String username = sc.getInitParameter("user");
		String password = sc.getInitParameter("passwd");
		
		//Setting the database to the application scope
		try {
			DaoEvaluations db = new DaoEvaluations(dbUrl, dbName, username, password);
			sc.setAttribute("database", db);
		} catch (Exception e) {
			e.getLocalizedMessage();
		}
	}

}
