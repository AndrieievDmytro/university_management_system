using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BlazorProjectServer.Services.Interfaces
{

    public class AttandanceService : IAttendanceRepository
    {
        private MainDbContext _context;

        public AttandanceService(MainDbContext context)
        {
            _context = context;
        }

        public async Task Create(Attendanse at)
        {
            var newAttend = new Attendanse
            {
                StartDate = at.StartDate,
                EndDate = at.EndDate,
            };
            await _context.Attendanses.AddAsync(newAttend);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var attend = new Attendanse
            {
                AttendanseId = id
            };

            _context.Attendanses.Attach(attend);
            _context.Entry(attend).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Attendanse> GetAttendanse(int id)
        {
            return await _context.Attendanses
                .FirstOrDefaultAsync(m => m.AttendanseId == id);
        }

        public async Task<List<Attendanse>> GetAttendanses()
        {
            return await _context.Attendanses.ToListAsync();
        }

        public async Task Edit(Attendanse newAttendanse)
        {
            var attendanse = _context.Attendanses.Where(d => d.AttendanseId == newAttendanse.AttendanseId).First();
            attendanse.StartDate = newAttendanse.StartDate;
            attendanse.EndDate = newAttendanse.EndDate;

            await _context.SaveChangesAsync();
        }

    }
}