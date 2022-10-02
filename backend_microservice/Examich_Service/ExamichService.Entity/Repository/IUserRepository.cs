using System;
using Examich.DTO;
using Examich.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examich.Entity.Repository
{
    public interface IUserRepository
    {
        Task<GetUserDto> GetUserByIdAsync(Guid id);
        Task<GetUserDto> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<Guid> CreateUserAsync(CreateUserDto user);
        Task<List<GetUserDto>> GetUserByUsernameAsync(string username);
        Task<bool> UserExistsAsync(Guid userId);
    }
}
