package ca.sheridancollege.java3.classes;

import java.time.LocalDate;

/**
 * Models any kind of evaluation that someone wants
 * to keep track of.
 * 
 * @author Wendi Jollymore
 *
 */
public class Evaluation implements java.io.Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private int id = 0;
	private Course course = null;
	private String evalName = "";
	private LocalDate dueDate = null;  
	private boolean submitted = false;
	
	/**
	 * Constructs a default evaluation with default values.
	 */
	public Evaluation() {}
	
	/**
	 * Constructs an evaluation with programmer-specified values.
	 * 
	 * @param course the course this evaluation is for
	 * @param name the name of this evaluation
	 * @param date the date the item is due
	 * @param submitted whether or not this item has been submitted
	 */
	public Evaluation(Course course, String name, LocalDate date, 
			boolean submitted) {
		init(course, name, date, submitted);
	}
	
	/**
	 * Constructs an evaluation with programmer-specified values.
	 * 
	 * @param id the unique record ID for this eval
	 * @param course the course this evaluation is for
	 * @param name the name of this evaluation
	 * @param date the date the item is due
	 * @param submitted whether or not this item has been submitted
	 */
	public Evaluation(int id, Course course, String name, LocalDate date, 
			boolean submitted) {
		init(id, course, name, date, submitted);
	}
	
	// initializes an evaluation object
	private void init(Course course, String name, LocalDate date, 
			boolean submitted) {
		setCourse(course);
		setEvalName(name);
		setDueDate(date);
		setSubmitted(submitted);
	}
	
	// initializes an evaluation object
	private void init(int id, Course course, String name, LocalDate date, 
			boolean submitted) {
		setId(id);
		init(course, name, date, submitted);
	}
	
	/**
	 * Places a valid ID into the ID member.  ID must be a positive whole 
	 * number, otherwise an exception is thrown.
	 * 
	 * @param id the programmer-specified ID
	 * @throws IllegalArgumentException if the ID is invalid
	 */
	public void setId(int id) {
		
		// make sure ID is valid
		if (id > 0)
			this.id = id;
		else
			throw new IllegalArgumentException("ID must be a positive "
					+ "whole number.");
	}
	
	/**
	 * Places a course object into this evaluation's course member.
	 * 
	 * @param course the course for this evaluation
	 */
	public void setCourse(Course course) {
		
		// place a copy of the course in the course member
		this.course = new Course(course.getCode(), course.getTitle());
	}
	
	/**
	 * Places a name in the evaluation's name field.
	 * 
	 * @param name the programmer-specified name
	 * @throws IllegalArgumentException if the name is empty
	 */
	public void setEvalName(String name) {
		
		// problems if name is empty
		if (name == null || name.trim().isEmpty())
			throw new IllegalArgumentException("Evaluation name can't be "
					+ "empty.");
		else
			evalName = name;
	}
	
	/**
	 * Places a date into the due date member.
	 * 
	 * @param date the date this evaluation is due
	 */
	public void setDueDate(LocalDate date) {
		
		// TODO: validate date!!
		dueDate = LocalDate.of(date.getYear(), date.getMonth(), 
				date.getDayOfMonth());
	}
	
	/**
	 * Places the programmer-specified value into this evaluation's
	 * submitted member.  Use true if the evaluation has been submitted
	 * and false if it hasn't been submitted.
	 * 
	 * @param submitted whether or not this eval has been submitted
	 */
	public void setSubmitted(boolean submitted) {
		this.submitted = submitted;
	}
	
	/**
	 * Retrieves this evaluation's ID value.
	 * 
	 * @return this evaluation's record ID
	 */
	public int getId() {
		return id;
	}
	
	/**
	 * Retrieves this evaluation's course object.
	 * 
	 * @return the course this evaluation belongs to
	 */
	public Course getCourse() {
		
		// return a copy of the course
		return new Course(course.getCode(), course.getTitle());
	}
	
	/**
	 * Retrieves the name of this evaluation.
	 * 
	 * @return this evaluation's name
	 */
	public String getEvalName() {
		return evalName;
	}
	
	/**
	 * Retrieves the due date for this evaluation.
	 * 
	 * @return this evaluation's due date
	 */
	public LocalDate getDueDate() {
		
		// return a copy of the date
		return LocalDate.of(dueDate.getYear(), dueDate.getMonth(), 
				dueDate.getDayOfMonth());
	}
	
	/**
	 * Indicates whether or not this evaluation has been
	 * submitted (true) or not (false).
	 * 
	 * @return true if this eval has been submitted, false otherwise
	 */
	public boolean isSubmitted() {
		return submitted;
	}

}
