using Examich.DTO;
using Examich.DTO.User;
using Examich.Entity.Data.User;
using System.Collections.Generic;

namespace Examich.Entity.Repository
{
    public interface IUserRepository
    {
        GetUserDto GetUserById(string id);
        UserEntity GetUserByEmailAndPassword(string email, string password);
        string CreateUser(CreateUserDto user);
        IEnumerable<UserEntity> GetUserByUsername(string username);
    }
}
