using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;

namespace BlazorProjectServer.Services
{
    public interface IDatabaseService
    {
        Task<List<Course>> GetCourses();
        Task<List<Subject>> GetRelatedSubjects(int id);
        Task<List<Assignments>> GetRelatedAssignments(int id);
        Task<Assignments> GetAssignment(int id);
        Task<Course> GetCourse(int id);
        Task<Subject> GetSubject(int id);
        Task<List<Assignments>> GetAssignments();
        Task<List<Subject>> GetSubjects();
        Task CreateCourse(Course course);
        Task DeleteCourse(int id);
        Task CreateSubject(Subject course);
        Task DeleteSubject(int id);
        Task CreateAssignment(Assignments assignments);
        Task DeleteAssignment(int id);
        Task EditCourse(Course course);
        Task EditSubject(Subject subject);
        Task EditAssignment(Assignments assignments);
        Task<bool> IsExisctingAssignement(int id);
        Task<bool> IsExisctingSubject(int id);
        Task<bool> IsExisctingCourse(int id);

    }
}