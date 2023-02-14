using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorProjectServer.Models;
using System.Collections.Generic;

namespace BlazorProjectServer.Services.Interfaces
{

    public class UserService : IUserRepository
    {
        private MainDbContext _context;

        public UserService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(IUser user)
        {
            User newUser;
            switch (user)
            {
                case Student:
                    newUser = new Student();
                    break;

                case PartTime:
                    newUser = new PartTime();
                    break;

                case FullTime:
                    newUser = new FullTime();
                    break;

                case Contract:
                    newUser = new Contract();
                    break;

                default:
                    return null;
            }

            newUser.UserCopy(user);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Where(i => i.UserId == id).FirstOrDefaultAsync();
        }

        public async Task RemoveUser(int id)
        {
            var user = GetUserById(id);

            _context.Entry(user).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(int id, IUser user)
        {
            User newUser;
            var targetUser = GetUserById(id);
            if(user.GetType() != targetUser.GetType())
            {
                return null;
            }
            
            switch (user)
            {
                case Student:
                    newUser = new Student();
                    break;

                case PartTime:
                    newUser = new PartTime();
                    break;

                case FullTime:
                    newUser = new FullTime();
                    break;

                case Contract:
                    newUser = new Contract();
                    break;

                default:
                    return null;
            }

            newUser.UserCopy(user);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}