using AutoMapper;
using Examich.DTO.User;
using Examich.Entity.Data.User;

namespace Examich.Configuration.DtoProfiles
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserEntity, GetUserDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
