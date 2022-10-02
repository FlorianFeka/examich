using AutoMapper;
using ExamichService.DTO.Exam;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Configuration.EntityProfiles
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
