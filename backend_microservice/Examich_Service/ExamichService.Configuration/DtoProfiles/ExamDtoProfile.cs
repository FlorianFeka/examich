using AutoMapper;
using ExamichService.DTO.Exam;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Configuration.DtoProfiles
{
    public class ExamDtoProfile : Profile
    {
        public ExamDtoProfile()
        {
            CreateMap<ExamEntity, GetExamDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
