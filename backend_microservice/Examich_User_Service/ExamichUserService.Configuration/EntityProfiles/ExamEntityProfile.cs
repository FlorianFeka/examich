using AutoMapper;
using ExamichUserService.DTO.Exam;
using ExamichUserService.Entity.Data.Exam;

namespace ExamichUserService.Configuration.EntityProfiles
{
    public class ExamEntityProfile : Profile
    {
        public ExamEntityProfile()
        {
            CreateMap<CreateExamDto, ExamEntity>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdateExamDto, ExamEntity>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
