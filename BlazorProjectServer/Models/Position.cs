using System;
using System.Collections.Generic;

namespace BlazorProjectServer.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        // Only for Chair
        public DateTime InChairFrom { get; set; }
        public DateTime? InChairTo { get; set; }
        //

        //Only for Assistant
        public int HoursOfTutorials { get; set; }
        //

        // Only for Assistant and Lecturer
        public ICollection<Course> Courses { get; set; }
        //

        //Only for Lecturer
        public int HoursOfLecture { get; set; }

        //Constraine with tutor

        private Tutor _tutor;
        public Tutor Tutor
        {
            get { return _tutor; }
            set
            {
                if (_tutor is not null)
                {
                    throw new ArgumentException("Composition constraine violation");
                }
                _tutor = value;
            }
        }

        public int TutorId { get; set; }

        private HashSet<PositionType> _positionTypes;
        public HashSet<PositionType> PositionTypes
        {
            get { return _positionTypes; }
            set
            {
                if (value.Count < 1)
                {
                    throw new ArgumentException("PositionType set cannot have length less than 1");
                }
                _positionTypes = value;
            }
        }

        public void AddRole(PositionType type, Position position)
        {
            if (PositionTypes.Contains(type))
            {
                throw new ArgumentException("The type is already set!");
            }

            PositionTypes.Add(type);
            if (position is null)
            {
                return;
            }
            if (type is PositionType.Lecturer)
            {
                HoursOfLecture = position.HoursOfLecture;
                Courses = position.Courses;
            }
            if (type is PositionType.Assistant)
            {
                HoursOfTutorials = position.HoursOfTutorials;
                Courses = position.Courses;
            }
            else if (type is PositionType.Chair)
            {
                InChairFrom = position.InChairFrom;
                InChairTo = position.InChairTo;
            }
        }

        public void RemoveRole(PositionType type)
        {
            if (PositionTypes.Count == 1)
            {
                throw new ArgumentException("A type cannot be removed. Person has to have at least one type");
            }

            PositionTypes.Remove(type);
        }
    }
}