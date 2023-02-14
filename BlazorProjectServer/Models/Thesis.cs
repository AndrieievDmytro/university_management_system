using System;

namespace BlazorProjectServer.Models
{
    public class Thesis
    {
        public int ThesisId { get; set; }
        public string Title { get; set; }
        public static int MaxDuration = 4;
        private Student _student; 
        public int StudentId { get; set; }

        public Student Student 
        { 
            get { return _student;}
            set 
            {
                if(_student is not null){
                    throw new ArgumentException("Composition constraine violation");
                }
                _student = value;
            } 
         }
    }
}