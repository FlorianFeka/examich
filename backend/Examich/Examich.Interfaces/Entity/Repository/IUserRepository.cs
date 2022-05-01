using System;
using Examich.DTO;
using Examich.DTO.User;
using System.Collections.Generic;

namespace Examich.Interfaces.Entity.Repository
{
    public interface IUserRepository
    {
        GetUserDto GetUserById(Guid id);
        GetUserDto GetUserByEmailAndPassword(string email, string password);
        Guid CreateUser(CreateUserDto user);
        IEnumerable<GetUserDto> GetUserByUsername(string username);
        bool UserExists(Guid userId);
    }
}
