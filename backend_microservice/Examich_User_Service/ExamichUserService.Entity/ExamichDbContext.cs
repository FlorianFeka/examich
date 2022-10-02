using System;
using ExamichUserService.Entity.Data.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamichUserService.Entity
{
    public class ExamichUserServiceDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
    {
        public DbSet<UserEntity> ApplicationUsers { get; set; }

        public ExamichUserServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            UserEntity.OnModelBuilding(modelBuilder);
        }
    }
}
