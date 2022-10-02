using AutoMapper;
using ExamichService.DTO.Question.Answer;
using ExamichService.Entity.Data.Exam;

namespace ExamichService.Configuration.DtoProfiles
{
    public class AnswerDtoProfile : Profile
    {
        public AnswerDtoProfile()
        {
            CreateMap<AnswerEntity, GetAnswerDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text))
                .ForMember(x => x.IsRight, opt => opt.MapFrom(x => x.IsRight));
        }
    }
}