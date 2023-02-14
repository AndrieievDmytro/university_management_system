using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BlazorProjectServer.Services.Interfaces
{

    public class ThesisService : IThesisRepository
    {
        private MainDbContext _context;

        public ThesisService(MainDbContext context)
        {
            _context = context;
        }

        public async Task Create(Thesis user)
        {
            var newThesis = new Thesis
            {
                Title = user.Title,
            };
            await _context.Theses.AddAsync(newThesis);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var thesis = new Thesis
            {
                ThesisId = id
            };

            _context.Theses.Attach(thesis);
            _context.Entry(thesis).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Thesis> GetThesis(int id)
        {
            return await _context.Theses
                .FirstOrDefaultAsync(m => m.ThesisId == id);
        }

        public async Task<List<Thesis>> GetThesis()
        {
            return await _context.Theses.ToListAsync();
        }
        public async Task Edit(Thesis newThesis)
        {
            var thesis = _context.Theses.Where(d => d.ThesisId == newThesis.ThesisId).First();
            thesis.Title = newThesis.Title;
            await _context.SaveChangesAsync();
        }
    }
}