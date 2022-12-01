using AutoMapper;
using Core.Entities;
using UnitDTO = Core.DTO.UnitDTO.UnitDTO;

namespace Core.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDTO>();
        }
    }
}