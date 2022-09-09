using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;

public class DayExerciseDetailsVm : IMapFrom<DayExerciseDetails>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<DayExerciseSetVm> Sets { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayExerciseDetails, DayExerciseDetailsVm>().ReverseMap();
    }
}

public class DayExerciseDetailsValidation : AbstractValidator<DayExerciseDetailsVm>
{
    public DayExerciseDetailsValidation()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Description).MaximumLength(100);
        RuleForEach(x => x.Sets).SetValidator(new DayExerciseSetValidation());
    }
}