using System;
using System.Collections.Generic;
using System.Linq;
using Examich.Entity.Data.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Examich.Entity.Seed.Seeder
{
    public static class UserSeeder
    {
        public static async void Seed(ExamichDbContext dbContext)
        {
            if (dbContext.Users.Any()) return;

            var users = new List<UserEntity>()
            {
                new ()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    UserName = "user",
                    Email = "user@gmail.com",
                },
                new ()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    UserName = "max",
                    Email = "max@gmail.com",
                },
                new ()
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    UserName = "admin",
                    Email = "admin@gmail.com",
                },
            };
            
            var passwordHasher = new PasswordHasher<UserEntity>();
            var userStore = new UserStore<UserEntity, IdentityRole<Guid>, ExamichDbContext, Guid>(dbContext);
            
            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "password");
                var result = userStore.CreateAsync(user);
                result.Wait();
            }

            await dbContext.SaveChangesAsync();
        }
    }
}