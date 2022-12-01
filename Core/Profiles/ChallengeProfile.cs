using AutoMapper;
using Core.Entities;
using ChallengeDTO = Core.DTO.ChallengeDTO.ChallengeDTO;
using CreateChallengeDTO = Core.DTO.ChallengeDTO.CreateChallengeDTO;
using UpdateChallengeDTO = Core.DTO.ChallengeDTO.UpdateChallengeDTO;

namespace Core.Profiles
{
    public class ChallengeProfile : Profile
    {
        public ChallengeProfile()
        {
            CreateMap<Challenge, ChallengeDTO>()
                .ForMember(d => d.AuthorId,
                    opt => opt
                        .MapFrom(ch => ch.CreatedById))
                .ForMember(d => d.FrequencyTitle,
                    opt => opt
                        .MapFrom(ch => ch.Frequency.Type))
                .ForMember(d => d.UnitShortTitle,
                    opt => opt
                        .MapFrom(ch => ch.Unit.ShortType))
                .ForMember(d => d.UnitTitle,
                    opt => opt
                        .MapFrom(ch => ch.Unit.Type))
                .ReverseMap();
            CreateMap<CreateChallengeDTO, Challenge>()
                .ForMember(d => d.CreatedById,
                    opt => opt.Ignore());
            CreateMap<UpdateChallengeDTO, Challenge>()
                .ForMember(d => d.CreatedById,
                    opt => opt.Ignore());
        }
    }
}