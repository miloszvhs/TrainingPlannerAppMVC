using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class ProductDetailsVm : IMapFrom<ProductDetails>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProductCaloriesVm Calories { get; set; }
    public int ProductId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductDetails, ProductDetailsVm>().ReverseMap();
    }
}

public class ProductDetailsValidation : AbstractValidator<ProductDetailsVm>
{
    public ProductDetailsValidation()
    {
        RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Calories).NotNull().SetValidator(new ProductCaloriesValidation());
    }
}