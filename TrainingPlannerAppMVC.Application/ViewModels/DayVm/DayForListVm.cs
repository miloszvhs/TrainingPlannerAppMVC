using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.DayVm;

public class DayForListVm : IMapFrom<Day>
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Day, DayForListVm>()
            .ForMember(x => x.Date, opt => opt.MapFrom(s => s.CreatedOn));
    }
}