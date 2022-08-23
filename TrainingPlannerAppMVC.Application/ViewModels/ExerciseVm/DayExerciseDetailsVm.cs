using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

public class DayExerciseDetailsVm : IMapFrom<DayExerciseDetails>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DayExerciseSetVm Sets { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayExerciseDetails, DayExerciseDetailsVm>();
    }
}