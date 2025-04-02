using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Interface;
using Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Test.Repository
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
           return await _context.Users.FindAsync(id);
        }

        public Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChangesAsync();
        }
    }
}