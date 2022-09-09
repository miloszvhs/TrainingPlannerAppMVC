using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;

public class DayExerciseSetVm : IMapFrom<DayExerciseSet>
{
    public int Id { get; init; }
    public int BreakTimeInSeconds { get; set; }
    public int Reps { get; set; }
    public decimal Weight { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayExerciseSet, DayExerciseSetVm>().ReverseMap();
    }
}

public class DayExerciseSetValidation : AbstractValidator<DayExerciseSetVm>
{
    public DayExerciseSetValidation()
    {
        RuleFor(x => x.Reps).GreaterThan(0).LessThanOrEqualTo(100);
        RuleFor(x => x.Weight).InclusiveBetween(0, 1000);
        RuleFor(x => x.BreakTimeInSeconds).InclusiveBetween(0, 3000);
    }
}