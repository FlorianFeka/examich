using AutoMapper;
using ExamichService.DTO.Question.Answer;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Configuration.EntityProfiles
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