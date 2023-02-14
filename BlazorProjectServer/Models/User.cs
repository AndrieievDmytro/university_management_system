using System;
using System.Collections.Generic;

namespace BlazorProjectServer.Models
{

    public abstract class User : IUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public void Register(string email, string password)
        {
        }

        public void Login(string email, string password)
        {

        }

        public void LogOut()
        {

        }

        public void ChangePaswword(string password)
        {

        }

        public void SendApplication()
        {

        }

        public virtual void UserCopy(IUser person)
        {
            var user = (User)person;
            Name = user.Name;
            Surname = user.Surname;
            DateOfBirth = user.DateOfBirth;
            Email = user.Email;
        }
    }
}