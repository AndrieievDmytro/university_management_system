using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BlazorProjectServer.Services.Interfaces
{

    public class PositionService : IPositionRepository
    {
        private MainDbContext _context;

        public PositionService(MainDbContext context)
        {
            _context = context;
        }

        // Create Chair 
        public async Task<Position> CreateChair(Position position)
        {
            var newPosition = new Position();
            newPosition.InChairFrom = position.InChairFrom;
            newPosition.InChairTo = position.InChairTo;
            newPosition.PositionTypes = new() { PositionType.Chair };

            _context.Positions.Add(newPosition);
            await _context.SaveChangesAsync();
            return newPosition;
        }

        // Create Lecturer

        public async Task<Position> CreateLecturer(Position position)
        {
            var newPosition = new Position();
            newPosition.HoursOfLecture = position.HoursOfLecture;
            newPosition.Courses = position.Courses;
            newPosition.PositionTypes = new() { PositionType.Lecturer };

            _context.Positions.Add(newPosition);
            await _context.SaveChangesAsync();
            return newPosition;
        }

        // Create Tutor

        public async Task<Position> CreateAssistant(Position position)
        {
            var newPosition = new Position();
            newPosition.HoursOfTutorials = position.HoursOfTutorials;
            newPosition.Courses = position.Courses;
            newPosition.PositionTypes = new() { PositionType.Assistant };

            _context.Positions.Add(newPosition);
            await _context.SaveChangesAsync();
            return newPosition;
        }

        // Get Chair(s)

        public async Task<Position> GetChairById(int id)
        {
            var position = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();
            if (!position.PositionTypes.Contains(PositionType.Chair))
            {
                return null;
            }
            return position;
        }

        public async Task<List<Position>> GetChairs()
        {
            return await _context.Positions.Where(p => p.PositionTypes.Contains(PositionType.Chair)).ToListAsync();
        }

        // Get Lecturer(s)

        public async Task<Position> GetLecturerById(int id)
        {
            var position = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();
            if (!position.PositionTypes.Contains(PositionType.Lecturer))
            {
                return null;
            }
            return position;
        }

        public async Task<List<Position>> GetLecturers()
        {
            return await _context.Positions.Where(p => p.PositionTypes.Contains(PositionType.Lecturer)).ToListAsync();
        }

        // Get Tutor(s)

        public async Task<Position> GetAssistantById(int id)
        {
            var position = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();
            if (!position.PositionTypes.Contains(PositionType.Assistant))
            {
                return null;
            }
            return position;
        }

        public async Task<List<Position>> GetAssistants()
        {
            return await _context.Positions.Where(p => p.PositionTypes.Contains(PositionType.Assistant)).ToListAsync();
        }

        // Remove Chair, Lecturer, Tutor

        public async Task RemoveChair(int id)
        {
            var chair = GetChairById(id);

            _context.Remove(chair);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveLecturer(int id)
        {
            var lecturer = GetLecturerById(id);

            _context.Remove(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAssistant(int id)
        {
            var assistant = GetAssistantById(id);

            _context.Remove(assistant);
            await _context.SaveChangesAsync();
        }

        // Update Chair, Lecturer, Tutor

        public async Task<Position> UpdateChair(int id, Position position)
        {
            var newChair = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();
            if (!position.PositionTypes.Contains(PositionType.Chair))
            {
                return null;
            }
            if (newChair is null)
            {
                return null;
            }

            newChair.InChairFrom = position.InChairFrom;
            newChair.InChairTo = position.InChairTo;

            await _context.SaveChangesAsync();
            return newChair;
        }

        public async Task<Position> UpdateLecturer(int id, Position position)
        {
            var newLecturer = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();
            if (!position.PositionTypes.Contains(PositionType.Lecturer))
            {
                return null;
            }
            if (newLecturer is null)
            {
                return null;
            }

            newLecturer.HoursOfLecture = position.HoursOfLecture;
            newLecturer.Courses = position.Courses;

            await _context.SaveChangesAsync();
            return newLecturer;
        }

        public async Task<Position> UpdateAssistant(int id, Position position)
        {
            var newAssistant = await _context.Positions.Where(p => p.PositionId == id).FirstOrDefaultAsync();
            if (!position.PositionTypes.Contains(PositionType.Assistant))
            {
                return null;
            }
            if (newAssistant is null)
            {
                return null;
            }

            newAssistant.HoursOfLecture = position.HoursOfLecture;
            newAssistant.HoursOfTutorials = position.HoursOfTutorials;

            await _context.SaveChangesAsync();
            return newAssistant;
        }
    }
}