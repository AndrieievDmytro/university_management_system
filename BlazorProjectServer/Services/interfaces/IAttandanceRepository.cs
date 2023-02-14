using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProjectServer.Services.Interfaces
{
    public interface IAttendanceRepository
    {   
        Task<List<Attendanse>> GetAttendanses();
        Task<Attendanse> GetAttendanse(int id);
        Task Create(Attendanse attendanse);
        Task Delete(int id);
        Task Edit(Attendanse attendanse);
    }   
}