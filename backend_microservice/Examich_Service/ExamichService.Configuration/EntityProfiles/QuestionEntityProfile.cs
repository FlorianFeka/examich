using AutoMapper;
using ExamichService.DTO.Question;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Configuration.EntityProfiles
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