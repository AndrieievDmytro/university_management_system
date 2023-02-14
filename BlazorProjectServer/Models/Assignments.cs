using System;

namespace BlazorProjectServer.Models
{
    public class Assignments
    {
        public int AssignmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxPoints { get; set; }
        public int? Points { get; set; }

        private Subject _subject;     
        public Subject Subject 
        { 
            get { return _subject;}
            set 
            {
                if(_subject is not null){
                    throw new ArgumentException("Composition constraine violation");
                }
                _subject = value;
            } 
         }
        public int SubjectId { get; set; }
    }
}