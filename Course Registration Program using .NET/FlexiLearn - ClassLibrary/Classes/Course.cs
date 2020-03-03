/*
 * Name: Ivan Pavlov 991540069
 * Assignment 3: Course Class
 * December 5, 2019
*/

using System;

namespace FlexiLearn___ClassLibrary
{
    public class Course
    {
        //Setting up readonly properties for a Course object
        public string Id { get; }
        public string Subject { get; }
        public DateTime StartDate { get; }
        public int DurationInWeeks { get; }
        public float Fee { get; }

        /// <summary>
        /// Constructor for a Course object
        /// </summary>
        /// <param name="id">course id</param>
        /// <param name="subject">course description</param>
        /// <param name="startDate">start date</param>
        /// <param name="durationInWeeks">duration of course</param>
        /// <param name="fee">course fee</param>
        public Course(string id, string subject, DateTime startDate, int durationInWeeks, float fee)
        {
            Id = id;
            Subject = subject;
            StartDate = startDate;
            DurationInWeeks = durationInWeeks;
            Fee = fee;
        }
    }
}
