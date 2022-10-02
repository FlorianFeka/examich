using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamichUserService.Entity.Data.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ExamichUserService.Entity.Seed.Seeder
{
    public static class UserSeeder
    {
        public static string GUID_ZEROS = "00000000-0000-0000-0000-00000000000";
        public static readonly List<UserEntity> users = new ()
        {
            new ()
            {
                Id = Guid.Parse($"{GUID_ZEROS}1"),
                UserName = "user",
                Email = "user@gmail.com",
            },
            new ()
            {
                Id = Guid.Parse($"{GUID_ZEROS}2"),
                UserName = "max",
                Email = "max@gmail.com",
            },
            new ()
            {
                Id = Guid.Parse($"{GUID_ZEROS}3"),
                UserName = "admin",
                Email = "admin@gmail.com",
            },
        };
        
        public static async void Seed(ExamichUserServiceDbContext dbContext)
        {
            if (dbContext.Users.Any()) return;
            
            var passwordHasher = new PasswordHasher<UserEntity>();
            var userStore = new UserStore<UserEntity, IdentityRole<Guid>, ExamichUserServiceDbContext, Guid>(dbContext);
            
            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "password");
                var result = userStore.CreateAsync(user);
                result.Wait();
            }

            await dbContext.SaveChangesAsync();
        }

        public static List<UserEntity> GetTestUsers(ExamichUserServiceDbContext dbContext)
        {
            return dbContext.Users.Where(u =>
                new List<String> { $"{GUID_ZEROS}1", $"{GUID_ZEROS}2", $"{GUID_ZEROS}3" }
                .Contains(u.Id.ToString())).ToList();
        }
    }
}