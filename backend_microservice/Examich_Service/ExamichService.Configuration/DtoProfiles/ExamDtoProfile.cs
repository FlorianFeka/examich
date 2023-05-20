using AutoMapper;
using ExamichService.DTO.Exam;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Configuration.DtoProfiles
{
    public class ExamDtoProfile : Profile
    {
        public ExamDtoProfile()
        {
            CreateMap<ExamEntity, GetExamInfoDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForAllOtherMembers(x => x.Ignore());
            
            CreateMap<ExamEntity, GetExamDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.CreatorId, opt => opt.MapFrom(x => x.CreatorId))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.Questions, opt => opt.MapFrom(x => x.Questions))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
