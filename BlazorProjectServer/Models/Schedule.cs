using System;

namespace BlazorProjectServer.Models
{
    public class Schedule {
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; }
        public Course Course { get; set; }
        public Subject Subject { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
    }
}