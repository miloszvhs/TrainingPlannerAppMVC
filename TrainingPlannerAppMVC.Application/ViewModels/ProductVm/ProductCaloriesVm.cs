using FluentValidation;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class ProductCaloriesVm
{
    public decimal Fat { get; set; }
    public decimal Carbs { get; set; }
    public decimal Proteins { get; set; }
}

public class ProductCaloriesValidation : AbstractValidator<ProductCaloriesVm>
{
    public ProductCaloriesValidation()
    {
        RuleFor(x => x.Fat).ScalePrecision(2, 4).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Carbs).ScalePrecision(2, 4).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Proteins).ScalePrecision(2, 4).GreaterThanOrEqualTo(0);
    }
}