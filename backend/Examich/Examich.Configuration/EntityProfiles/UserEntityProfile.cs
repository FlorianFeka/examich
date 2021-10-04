using AutoMapper;
using Examich.DTO;
using Examich.Entity.Data.User;
using System.Security.Cryptography;
using System.Text;

namespace Examich.Configuration.EntityProfiles
{
    public class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<CreateUserDto, UserEntity>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => CreateHash(x.Password)))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForAllOtherMembers(x => x.Ignore());
        }

        private string CreateHash(string text)
        {
            using var sha256 = SHA256.Create();
            return Encoding.UTF8.GetString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text)));
        }
    }
}
