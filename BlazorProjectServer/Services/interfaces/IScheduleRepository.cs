using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProjectServer.Services.Interfaces
{
    public interface IScheduleRepository
    {   
        Task<List<Schedule>> GetSchedules();
        Task<Schedule> GetSchedule(int id);
        Task Create(Schedule schedule);
        Task Delete(int id);
        Task Edit(Schedule schedule);
    }   
}