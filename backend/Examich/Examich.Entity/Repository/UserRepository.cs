using AutoMapper;
using Examich.DTO;
using Examich.DTO.User;
using Examich.Entity.Data.User;
using Examich.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examich.Entity.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ExamichDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ExamichDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateUserAsync(CreateUserDto user)
        {
            switch(await UserExistsAsync(user.Email, user.Username))
            {
                case 1:
                    throw new ExamichDbException($"User with email '{user.Email}' already exists.");
                case 2:
                    throw new ExamichDbException($"User with username '{user.Username}'");
                case 3:
                    throw new ExamichDbException($"User with email '{user.Email}' and username '{user.Username}' already exists.");
            }

            var userEntity = _mapper.Map<UserEntity>(user);

                       
            var userStore = new UserStore<UserEntity, IdentityRole<Guid>, ExamichDbContext, Guid>(_context);
            await userStore.CreateAsync(userEntity);

            await _context.SaveChangesAsync();
            
            return userEntity.Id;
        }

        public async Task<GetUserDto> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _context.ApplicationUsers.AsNoTracking().FirstOrDefaultAsync(
                x => x.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<UserEntity>();
                var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
                switch (result)
                {
                    case PasswordVerificationResult.Failed:
                        return null;
                    case PasswordVerificationResult.SuccessRehashNeeded:
                        // TODO: Log or Log and rehash password
                        break;
                }
            }
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<List<GetUserDto>> GetUserByUsernameAsync(string username)
        {
            var userDtos = await _context.ApplicationUsers.AsNoTracking().Where(
                x => x.UserName.ToLower().Contains(username.ToLower()))
                .Select(x => _mapper.Map<GetUserDto>(x))
                .ToListAsync();
            return userDtos;
        }

        public async Task<GetUserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _context.ApplicationUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;
            return new GetUserDto()
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
            };
        }

        private async Task<int> UserExistsAsync(string email, string username)
        {
            int count = 0;
            count += await _context.ApplicationUsers.AsNoTracking().Where(x => x.Email == email ).AnyAsync() ? 1 : 0;
            count += await _context.ApplicationUsers.AsNoTracking().Where(x => x.UserName == username).AnyAsync() ? 2 : 0;
            return count;
        }

        public async Task<bool> UserExistsAsync(Guid userId)
        {
            return await _context.ApplicationUsers.AnyAsync(x => x.Id == userId);
        }
    }
}
