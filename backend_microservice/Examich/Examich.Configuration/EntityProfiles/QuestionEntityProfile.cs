using AutoMapper;
using Examich.DTO.Question;
using Examich.Entity.Data.Exam;

namespace Examich.Configuration.EntityProfiles
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