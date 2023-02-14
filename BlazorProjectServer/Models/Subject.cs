using System.Collections.Generic;


namespace BlazorProjectServer.Models
{

    public enum SubjectType
    {
        Lecture,
        Tutorial
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public SubjectType Type { get; set; }
        public string Topics { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Assignments> Assignments { get; set; }
    }
}