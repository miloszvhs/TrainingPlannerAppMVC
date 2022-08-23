using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

public class NewExerciseVm : IMapFrom<Exercise>
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string ExerciseName { get; set; }
    public ExerciseCategoryVm Category { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewExerciseVm, Exercise>().ReverseMap();
        profile.CreateMap<ExerciseCategoryVm, ExerciseCategory>().ReverseMap();
    }
}

public class NewExerciseValidation : AbstractValidator<NewExerciseVm>
{
    public NewExerciseValidation()
    {
        RuleFor(x => x.Category).SetValidator(new ExerciseCategoryValidation());
        RuleFor(x => x.ExerciseName).NotEmpty().MaximumLength(50).MinimumLength(1);
    }
}