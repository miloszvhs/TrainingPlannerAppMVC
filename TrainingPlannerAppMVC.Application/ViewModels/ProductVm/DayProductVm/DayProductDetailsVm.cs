using FluentValidation;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;

public class DayProductDetailsVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProductCaloriesVm Calories { get; set; }
    public decimal Weight { get; set; }
    public decimal Kcal { get; set; }
}

public class DayProductDetailsValidation : AbstractValidator<DayProductDetailsVm>
{
    public DayProductDetailsValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Weight).GreaterThanOrEqualTo(0).NotEmpty();
        RuleFor(x => x.Calories).SetValidator(new ProductCaloriesValidation());
    }
}