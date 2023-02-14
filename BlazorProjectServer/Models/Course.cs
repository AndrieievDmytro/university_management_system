using System.Collections.Generic;

namespace BlazorProjectServer.Models
{

    public class Course {
        public int CourseId { get; set; }
        public string CourseTag { get; set; }
        public string CourseDescription { get; set; }
        public string CourseProgram { get; set; }
        public ICollection<Attendanse> Attendanses { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public Position Position { get; set; }
        public int IdPosition { get; set; }
    }
}