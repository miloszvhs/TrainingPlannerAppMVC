using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.DayVm;

public class NewDayVm : IMapFrom<Day>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewDayVm, Day>();
    }
}