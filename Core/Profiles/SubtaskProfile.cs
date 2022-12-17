using AutoMapper;
using Core.DTO.SubtaskDTO;
using Core.Entities;

namespace Core.Profiles;

public class SubtaskProfile : Profile
{
    public SubtaskProfile()
    {
        CreateMap<SubtaskCreateDTO, Subtask>().ReverseMap();
    }
}