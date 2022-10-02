using AutoMapper;
using ExamichUserService.DTO.Question;
using ExamichUserService.Entity.Data.Exam;

namespace ExamichUserService.Configuration.EntityProfiles
{
    public class QuestionEntityProfile : Profile
    {
        public QuestionEntityProfile()
        {
            CreateMap<CreateQuestionDTO, QuestionEntity>()
                .ForMember(x => x.Text, opt => opt.MapFrom(x=> x.Text));
        }
    }
}