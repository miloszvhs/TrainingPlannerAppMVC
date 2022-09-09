using AutoMapper;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.DayVm;

public class DayDetailsVm
{
    public Guid Id { get; init; }
    public ListDayProductForListVm Products { get; set; }
    public ListDayExerciseForListVm Exercises { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Day, DayDetailsVm>();
    }
}