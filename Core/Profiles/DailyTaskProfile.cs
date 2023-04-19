using AutoMapper;
using Core.DTO.DailyTaskDTO;
using Core.DTO.SubtaskDTO;
using Core.Entities;

namespace Core.Profiles;

public class DailyTaskProfile : Profile
{
    public DailyTaskProfile()
    {
        // CreateMap<DailyTask, DailyTaskDTO>()
        //     .ForMember(d => d.UnitShortName,
        //         opt => opt
        //             .MapFrom(task => task.Challenge.Unit.ShortType))
        //     .ForMember(d => d.CountOfUnits,
        //         opt => opt
        //             .MapFrom(task => task.Challenge.CountOfUnits))
        //     .ForMember(d => d.UnitName,
        //         opt => opt
        //             .MapFrom(task => task.Challenge.Unit.Type))
        //     .ForMember(d => d.Description,
        //         opt => opt
        //             .MapFrom(task => task.Challenge.Description));
        
        CreateMap<DailyTask, GetDailyTaskDTO>()
            .ForMember(d => d.UnitShortName,
                opt => opt
                    .MapFrom(task => task.Challenge.Unit.ShortType))
            .ForMember(d => d.CountOfUnits,
                opt => opt
                    .MapFrom(task => task.Challenge.CountOfUnits))
            .ForMember(d => d.UnitName,
                opt => opt
                    .MapFrom(task => task.Challenge.Unit.Type))
            .ForMember(d => d.Description,
                opt => opt
                    .MapFrom(task => task.Challenge.Description))
            .ForMember(d => d.IconName,
                opt => opt
                    .MapFrom(task => task.Challenge.IconName))
            .ForMember(d => d.Date,
                opt => opt
                    .MapFrom(task => task.AssignedDate));
           
        CreateMap<DailyTask, GetSubtaskDTO>()
            .ForMember(d => d.Title,
                opt => opt
                    .MapFrom(task => task.Subtask!.Title))
            .ForMember(d => d.UnitShortName,
                opt => opt
                    .MapFrom(task => task.Subtask!.Unit.ShortType))
            .ForMember(d => d.CountOfUnits,
                opt => opt
                    .MapFrom(task => task.Subtask!.CountOfUnits))
            .ForMember(d => d.UnitName,
                opt => opt
                    .MapFrom(task => task.Subtask!.Unit.Type));
    }
}
