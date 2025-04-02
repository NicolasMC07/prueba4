using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Seeders
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User 1", Email = "user1@example.com", Password = "password1" },
                new User { Id = 2, Name = "User 2", Email = "user2@example.com", Password = "password2" },
                new User { Id = 3, Name = "User 3", Email = "user3@example.com", Password = "password3" }

            );
        }
    }
}