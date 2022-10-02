using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Examich.Entity.Data.User
{
    public class UserEntity : IdentityUser<Guid>
    {
        public UserEntity()
        {
            Id = Guid.NewGuid();
            SecurityStamp = Guid.NewGuid().ToString();
        }

        public UserEntity(string userName) : this()
        {
            UserName = userName;
        }


        public static void OnModelBuilding(ModelBuilder builder)
        {
        }
    }
}
