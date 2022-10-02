using AutoMapper;
using ExamichUserService.DTO.Question.Answer;
using ExamichUserService.Entity.Data.Exam;

namespace ExamichUserService.Configuration.EntityProfiles
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