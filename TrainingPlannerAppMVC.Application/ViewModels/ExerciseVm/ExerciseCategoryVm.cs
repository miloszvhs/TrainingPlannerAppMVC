using FluentValidation;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

public class ExerciseCategoryVm
{
    public string CategoryName { get; set; }
}

public class ExerciseCategoryValidation : AbstractValidator<ExerciseCategoryVm>
{
    public ExerciseCategoryValidation()
    {
        RuleFor(x => x.CategoryName).NotEmpty();
    }
}