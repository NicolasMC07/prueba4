using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Interface;
using Test.Models;

namespace Test.Service
{
    public class UserService(IUserRepository userRepository) : IUserServices
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
        }

        public async Task DeleteUser(User user)
        {
            await _userRepository.DeleteUser(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public Task UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}