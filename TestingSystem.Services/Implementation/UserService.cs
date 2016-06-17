﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations.Extension;
using TestingSystem.DataBaseConfigurations;
using System.Data.Entity;


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
        
        public User CreateUser(User user1)
        {
            var existingUser = _userRepository.GetById(user1.Email); //має бути GetBeEmail

            if (existingUser != null)
            {
                throw new Exception("Email is already in use");
            }

            var user = new User()   //тут змінити треба!!!
            {
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                Email = user1.Email,
               Password= user1.Password
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            return user;

        }
        public User EditUser(User user1)
        {
            var existingUser = _userRepository.GetSingle(user1.Id); //має бути GetBeEmail

            if (existingUser == null)
            {
                throw new Exception("Email is already in use");
            }


            existingUser.Email = user1.Email;
            existingUser.FirstName = user1.FirstName;

            //  _userRepository.Edit(user);
            //  _userRepository.Edit(existingUser);
            var context = new TestingSystemContext();
            context.Entry(existingUser).State = EntityState.Modified;
            context.SaveChanges();
              //  _unitOfWork.Commit();
            

            return existingUser;
        }
        public void DeleteUser(int UserId)
        {
            var existingUser = _userRepository.GetSingle(UserId); //має бути GetBeEmail
            if (existingUser == null)
            {
                throw new Exception("Email is already in use");
            }           

            _userRepository.Delete(existingUser);

            _unitOfWork.Commit();
        }
        public User GetUser(int UserId)
        {
            return _userRepository.GetSingle(UserId);
        }
    }
}
