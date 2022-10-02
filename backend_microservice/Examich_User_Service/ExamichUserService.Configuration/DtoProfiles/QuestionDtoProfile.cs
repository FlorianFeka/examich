using AutoMapper;
using ExamichUserService.DTO.Question;
using ExamichUserService.Entity.Data.Exam;

namespace ExamichUserService.Configuration.DtoProfiles
{
    public class QuestionDtoProfile : Profile
    {
        public QuestionDtoProfile()
        {
            CreateMap<QuestionEntity, GetQuestionDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text))
                .ForMember(x => x.Answers, opt => opt.MapFrom(x => x.Answers));
        }
    }
}