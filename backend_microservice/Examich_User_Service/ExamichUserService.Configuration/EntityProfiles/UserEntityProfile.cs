using AutoMapper;
using ExamichUserService.DTO;
using ExamichUserService.Entity.Data.User;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ExamichUserService.Configuration.EntityProfiles
{
    public class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<CreateUserDto, UserEntity>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .AfterMap((src, dst) => dst.PasswordHash = CreateHash(dst, src.Password))
                .ForAllOtherMembers(x => x.Ignore());
        }

        private string CreateHash(UserEntity userEntity, string password)
        {
            var passwordHasher = new PasswordHasher<UserEntity>();
            return passwordHasher.HashPassword(userEntity, password);
        }
    }
}
