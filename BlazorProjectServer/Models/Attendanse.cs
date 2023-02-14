using System;

namespace BlazorProjectServer.Models
{
    public class Attendanse
    {
        public int AttendanseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsPassed { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}