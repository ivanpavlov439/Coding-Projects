package ca.sheridancollege.java3.classes;

/**
 * Models a course for the Evaluation.
 * 
 * @see Evaluation
 * @author Wendi Jollymore
 *
 */
public class Course implements java.io.Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String code = "";
	private String title = "";
	
	/**
	 * Constructs a default course with no code or title.
	 */
	public Course() {}
	
	/**
	 * Constructs a course with a specific code and title.
	 * The course code must follow the format XXXXNNNNN where X is a letter
	 * and N is a digit, otherwise an exception is thrown.
	 * 
	 * @param code the programmer-specified course code
	 * @param title the programmer-specified title
	 */
	public Course(String code, String title) {
		init(code, title);
	}
	
	// initializer this course object
	private void init(String code, String title) {
		setCode(code);
		setTitle(title);
	}
	
	/**
	 * Places a valid course code in to the code member.  A course code
	 * is comprised of 4 letters and 5 digits.  If the course code doesn't
	 * meet this criteria, an exception is thrown.
	 * 
	 * @param code the programmer-specified course code
	 * @throws IllegalArgumentException if the course code is invalid
	 */
	public void setCode(String code) {
		
		// code must match XXXXNNNNN
		if (code.matches("^[a-zA-Z]{4}\\d{5}$")) {
			this.code = code;
		} else {
			throw new IllegalArgumentException("Course code is invalid: must "
					+ "be 4 letters followed by 5 digits.");
		}
	}
	
	/**
	 * Retrieves this course's course code.
	 * 
	 * @return this course's course code
	 */
	public String getCode() {
		return code;
	}
	
	/**
	 * Puts the title of this course into the title member.
	 * 
	 * @param title the programmer-specified course title
	 */
	public void setTitle(String title) {
		this.title = title;
	}
	
	/**
	 * Retrieves this course's title.
	 * 
	 * @return this course's title
	 */
	public String getTitle() {
		return title;
	}
	
	/**
	 * Gets a String representation of this course object, in the format
	 * <pre>CRSE12345: Course Title</pre>
	 * 
	 * @return this Course as a String
	 */
	public String toString() {
		return code + " " + title;
	}
}
