using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProjectServer.Services.Interfaces
{
    public interface IPositionRepository
    {
        // Lecturer position
        Task<List<Position>> GetLecturers();
        Task<Position> GetLecturerById(int id);
        Task<Position> CreateLecturer(Position position);
        Task<Position> UpdateLecturer(int id, Position position);
        Task RemoveLecturer(int id);

        // Tutor position
        Task<List<Position>> GetAssistants();
        Task<Position> GetAssistantById(int id);
        Task<Position> CreateAssistant(Position position);
        Task<Position> UpdateAssistant(int id, Position position);
        Task RemoveAssistant(int id);

        // Chair position
        Task<List<Position>> GetChairs();
        Task<Position> GetChairById(int id);
        Task<Position> CreateChair(Position position);
        Task<Position> UpdateChair(int id, Position position);
        Task RemoveChair(int id);
    }
}