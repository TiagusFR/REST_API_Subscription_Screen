using System;
using System.Collections.Generic;
using System.Linq;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Persistence;

namespace SubscriptionScreen.API.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context) 
        {
          _context = context;
        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User>GetAll()
        {
            return _context.Users.Where(x => !x.IsDeleted).ToList();
        }

        public User Add(User user) 
        {
            _context.Users.Add(user);
            return user;
        }

        public void Update (Guid id, UpdateUserRequestDTO request)
        {
            User? userFound = GetById(id);

            if (userFound == null) 
            {
                throw new ArgumentException($"Cannot find the user with the Id:`{id}");
            }

            userFound.Name = request.Name;
            userFound.Email = request.Email;
            userFound.Document = request.Document;
            userFound.Birthday = request.Birthday;
            userFound.Password = request.Password;
        }

        public void Delete(Guid id) 
        {
            User? user = GetById(id);

            if (user == null)
            {
                throw new ArgumentException($"Cannot find the User with the Id: {id}");
            }

            user.IsDeleted = true;
            _context.Users.Remove(user);
        }
    }
}
