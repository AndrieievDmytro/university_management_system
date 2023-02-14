using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProjectServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProjectServer.Services.Interfaces
{
    public interface IUserRepository
    {   
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, IUser user);
        Task<User> CreateUser(IUser user);
        Task RemoveUser(int id);       
    }   
}