using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;

namespace BlazorProjectServer.Services
{
    public class PgDatabaseService : IDatabaseService
    {
        private MainDbContext _context;

        public PgDatabaseService(MainDbContext context)
        {
            _context = context;
        }
        //Get specific assignment
        public async Task<Assignments> GetAssignment(int id)
        {
            return await _context.Assignments.Where(e => e.AssignmentId == id).FirstOrDefaultAsync();
        }

        //Get assignments related to specific subject 
        public async Task<List<Assignments>> GetRelatedAssignments(int id)
        {
            System.Console.WriteLine("Test");
            return await _context.Assignments
                .FromSqlRaw($"SELECT s.\"SubjectId\", a.\"AssignmentId\", a.\"Name\", a.\"Description\", a.\"StartDate\", a.\"EndDate\", a.\"MaxPoints\", a.\"Points\" FROM \"Assignment\" as a INNER JOIN \"Subject\" as s on a.\"SubjectId\" = s.\"SubjectId\" Where s.\"SubjectId\" = {id}")
                .ToListAsync();
        }
        // Get specific course
        public  async Task<Course> GetCourse(int id)
        {
            return  await _context.Courses.Where(e => e.CourseId == id).FirstOrDefaultAsync();
        }
        //Get all courses
        public  async Task<List<Course>> GetCourses()
        {
            return await  _context.Courses.OrderBy(m => m.CourseTag).ToListAsync();
        }
        //Get specific assignment
        public async Task<Subject> GetSubject(int id)
        {
            return await _context.Subjects.Where(e => e.SubjectId == id).FirstOrDefaultAsync();
        }

        //Get subjects related to specific course 
        public async Task<List<Subject>> GetRelatedSubjects(int id)
        {

            // return  query;
            return await _context.Subjects
                .FromSqlRaw($"SELECT s.\"SubjectId\", s.\"Name\", s.\"Type\", s.\"Topics\" FROM \"Subject\" as s INNER JOIN \"Schedule\" as sh on s.\"SubjectId\" = sh.\"SubjectId\" INNER JOIN \"Course\" as c ON sh.\"CourseId\" = c.\"CourseId\" Where c.\"CourseId\" = {id}")
                .ToListAsync();
        }

        public async Task<List<Assignments>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }
        // Create new course
        public async Task CreateCourse(Course course)
        {
            var newCourse = new Course
            {
                CourseTag = course.CourseTag,
                CourseDescription = course.CourseDescription,
                CourseProgram = course.CourseProgram,

            };
            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
        }

        // Remove specific course
        public async Task DeleteCourse(int id)
        {
            var course = new Course
            {
                CourseId = id
            };

            _context.Courses.Attach(course);
            _context.Entry(course).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task CreateSubject(Subject course)
        {
            var newSubject = new Subject
            {
                Name = course.Name,
                Type = course.Type,
                Topics = course.Topics,

            };
            await _context.Subjects.AddAsync(newSubject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubject(int id)
        {
            var subject = new Subject
            {
                SubjectId = id
            };

            _context.Subjects.Attach(subject);
            _context.Entry(subject).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        // Create new assignment
        public async Task CreateAssignment(Assignments assignments)
        {
            var newAssignment = new Assignments
            {
                Name = assignments.Name,
                Description = assignments.Description,
                StartDate = assignments.StartDate,
                EndDate = assignments.EndDate,
                MaxPoints = assignments.MaxPoints,
                Points = assignments.Points
            };
            await _context.Assignments.AddAsync(newAssignment);
            await _context.SaveChangesAsync();
        }
        // Delete assignment
        public async Task DeleteAssignment(int id)
        {
            var assignment = new Assignments
            {
                AssignmentId = id
            };

            _context.Assignments.Attach(assignment);
            _context.Entry(assignment).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // Edit specific Assignemt(ex. set points)
        public async Task EditAssignment(Assignments newAssignment)
        {
            var assignment = _context.Assignments.Where(d => d.AssignmentId == newAssignment.AssignmentId).First();
            assignment.Points = newAssignment.Points;
            await _context.SaveChangesAsync();
        }
        public async Task EditCourse(Course newCourse)
        {
            var course = _context.Courses.Where(d => d.CourseId == newCourse.CourseId).First();
            course.CourseTag = newCourse.CourseTag;
            await _context.SaveChangesAsync();
        }
        public async Task EditSubject(Subject newSubject)
        {
            var subject = _context.Subjects.Where(d => d.SubjectId == newSubject.SubjectId).First();
            subject.Name = newSubject.Name;
            await _context.SaveChangesAsync();
        }
        // Check for the existence of assignments, subjects, course in database 
        public async Task<bool> IsExisctingAssignement(int id)
        {
            return await _context.Assignments.AnyAsync(e => e.AssignmentId == id);
        }
        public async Task<bool> IsExisctingSubject(int id)
        {
            return await _context.Subjects.AnyAsync(e => e.SubjectId == id);
        }
        public async Task<bool> IsExisctingCourse(int id)
        {
            return await _context.Courses.AnyAsync(e => e.CourseId == id);
        }
    }
}

