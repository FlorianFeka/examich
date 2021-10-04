using AutoMapper;
using Examich.DTO;
using Examich.DTO.User;
using Examich.Entity.Data.User;
using Examich.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        public string CreateUser(CreateUserDto user)
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
            using var sha256 = SHA256.Create();

            var userEntity = _mapper.Map<UserEntity>(user);

            _context.Users.Add(userEntity);
            _context.SaveChanges();
            return userEntity.Id;
        }

        public UserEntity GetUserByEmailAndPassword(string email, string password)
        {
            using var sha256 = SHA256.Create();
            return _context.ApplicationUsers.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.PasswordHash == Encoding.UTF8.GetString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password))));
        }

        public IEnumerable<UserEntity> GetUserByUsername(string username)
        {
            return _context.ApplicationUsers.Where(x => x.UserName.ToLower().Contains(username.ToLower()));
        }

        public GetUserDto GetUserById(string id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
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
            count += _context.ApplicationUsers.Where(x => x.Email == email ).Any() ? 1 : 0;
            count += _context.ApplicationUsers.Where(x => x.UserName == username).Any() ? 2 : 0;
            return count;
        }
    }
}
