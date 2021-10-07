using Examich.DTO;
using Examich.DTO.User;
using System.Collections.Generic;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IUserRepository
    {
        GetUserDto GetUserById(string id);
        GetUserDto GetUserByEmailAndPassword(string email, string password);
        string CreateUser(CreateUserDto user);
        IEnumerable<GetUserDto> GetUserByUsername(string username);
        bool UserExists(string userId);
    }
}
