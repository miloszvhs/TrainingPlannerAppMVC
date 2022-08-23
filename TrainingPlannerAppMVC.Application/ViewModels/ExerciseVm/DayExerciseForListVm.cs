using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

public class DayExerciseForListVm : IMapFrom<DayExercise>
{
    public int Id { get; init; }
    public DayExerciseDetailsVm ExerciseDetails { get; set; }
    public string ExerciseCategory { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayExercise, DayExerciseForListVm>()
            .ForMember(x => x.ExerciseCategory, opt => opt.MapFrom(s => s.ExerciseCategory.Name));
        profile.CreateMap<DayExerciseDetails, DayExerciseDetailsVm>();
    }
}