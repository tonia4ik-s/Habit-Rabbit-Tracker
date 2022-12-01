using AutoMapper;
using Core.DTO.FrequencyDTO;
using Core.Entities;

namespace Core.Profiles
{
    public class FrequencyProfile : Profile
    {
        public FrequencyProfile()
        {
            CreateMap<Frequency, FrequencyDTO>();
        }
    }
}
