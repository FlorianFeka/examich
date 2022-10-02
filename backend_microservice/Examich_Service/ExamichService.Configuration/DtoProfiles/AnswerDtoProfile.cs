using AutoMapper;
using Examich.DTO.Question.Answer;
using Examich.Entity.Data.Exam;

namespace Examich.Configuration.DtoProfiles
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