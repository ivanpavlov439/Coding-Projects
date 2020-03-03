/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: Registration Request Class
 * December 5, 2019
*/

using System;

namespace FlexiLearn___ClassLibrary
{
    public class RegistrationRequest
    {
        //Setting up readonly properties for RegistrationRequest object
        public string UserName { get; } 
        public string CourseTitle { get; }
        public string CourseSubject { get; }
        public DateTime RegisteredDate { get; }
        public string Status { get; }

        /// <summary>
        /// Constructor for RegistrationRequest object
        /// </summary>
        /// <param name="userName">users name</param>
        /// <param name="courseTitle">course Id</param>
        /// <param name="courseSubject">course description</param>
        /// <param name="registeredDate">registered date</param>
        /// <param name="status">status of request</param>
        public RegistrationRequest(string userName, string courseTitle, string courseSubject, DateTime registeredDate, string status = "New")
        {
            UserName = userName;
            CourseTitle = courseTitle;
            CourseSubject = courseSubject;
            RegisteredDate = registeredDate;
            Status = status;
        }


    }
}
