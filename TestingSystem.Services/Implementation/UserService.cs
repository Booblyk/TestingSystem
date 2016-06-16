using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations.Extension;

namespace TestingSystem.Services.Implementation
{
    public class UserService : Interfaces.IUserService
    {
        IRepository<User> _userRepository;
        IUnitOfWork _unitOfWork;
        public UserService(IRepository<User> userRepos, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepos;
            _unitOfWork = unitOfWork;
        }
        
        public User CreateUser(string email, string password)
        {
            var existingUser = _userRepository.GetById(email); //має бути GetBeEmail

            if (existingUser != null)
            {
                throw new Exception("Email is already in use");
            }

            var user = new User()   //тут змінити треба!!!
            {
                FirstName = "1",
                LastName = "2",
                GroupId = 1,
                IsActive = false,
                PasswordSalt = "",
                Email = email,
               PasswordHash=password
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            return user;

        }

        public User GetUser(int UserId)
        {
            return _userRepository.GetSingle(UserId);
        }
    }
}
