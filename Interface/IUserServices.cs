using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Interface
{
    public interface IUserServices
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
    }
}