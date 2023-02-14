using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BlazorProjectServer.Services.Interfaces
{

    public class ScheduleService : IScheduleRepository
    {
        private MainDbContext _context;

        public ScheduleService(MainDbContext context)
        {
            _context = context;
        }

        public async Task Create(Schedule schedule)
        {
            var newSchedule = new Schedule
            {
                Date = schedule.Date,
                Room = schedule.Room,
            };
            await _context.Schedules.AddAsync(newSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var schedule = new Schedule
            {
                ScheduleId = id
            };

            _context.Schedules.Attach(schedule);
            _context.Entry(schedule).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Schedule> GetSchedule(int id)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
        }

        public async Task<List<Schedule>> GetSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }
        public async Task Edit(Schedule newSchedule)
        {
            var schedule = _context.Schedules.Where(d => d.ScheduleId == newSchedule.ScheduleId).First();
            schedule.Room = newSchedule.Room;
            await _context.SaveChangesAsync();
        }
    }
}