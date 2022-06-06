using System;
using AutoMapper;
using Examich.DTO;
using Examich.DTO.User;
using Examich.Entity.Data.User;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

        public Guid CreateUser(CreateUserDto user)
        {
            switch(UserExists(user.Email, user.Username))
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
            var result = userStore.CreateAsync(userEntity);
            result.Wait();

            _context.SaveChanges();
            
            return userEntity.Id;
        }

        public GetUserDto GetUserByEmailAndPassword(string email, string password)
        {
            var user = _context.ApplicationUsers.AsNoTracking().FirstOrDefault(
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

        public IEnumerable<GetUserDto> GetUserByUsername(string username)
        {
            var userDtos = _context.ApplicationUsers.AsNoTracking().Where(
                x => x.UserName.ToLower().Contains(username.ToLower()))
                .Select(x => _mapper.Map<GetUserDto>(x));
            return userDtos;
        }

        public GetUserDto GetUserById(Guid id)
        {
            var user = _context.ApplicationUsers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (user == null) return null;
            return new GetUserDto()
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
            };
        }

        private int UserExists(string email, string username)
        {
            int count = 0;
            count += _context.ApplicationUsers.AsNoTracking().Where(x => x.Email == email ).Any() ? 1 : 0;
            count += _context.ApplicationUsers.AsNoTracking().Where(x => x.UserName == username).Any() ? 2 : 0;
            return count;
        }

        public bool UserExists(Guid userId)
        {
            return _context.ApplicationUsers.Any(x => x.Id == userId);
        }
    }
}
