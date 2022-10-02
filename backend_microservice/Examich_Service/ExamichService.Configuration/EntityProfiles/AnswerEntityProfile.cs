using AutoMapper;
using Examich.DTO.Question.Answer;
using Examich.Entity.Data.Exam;

namespace Examich.Configuration.EntityProfiles
{
    public class AnswerEntityProfile : Profile
    {
        public AnswerEntityProfile()
        {
            CreateMap<CreateAnswerDTO, AnswerEntity>()
                .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text))
                .ForMember(x => x.IsRight, opt => opt.MapFrom(x => x.IsRight));
        }
    }
}