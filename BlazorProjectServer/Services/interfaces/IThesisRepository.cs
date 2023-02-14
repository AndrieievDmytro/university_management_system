using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProjectServer.Services.Interfaces
{
    public interface IThesisRepository
    {   
        Task<List<Thesis>> GetThesis();
        Task<Thesis> GetThesis(int id);
        Task Create(Thesis student);
        Task Delete(int id);
        Task Edit(Thesis thesis);
    }   
}