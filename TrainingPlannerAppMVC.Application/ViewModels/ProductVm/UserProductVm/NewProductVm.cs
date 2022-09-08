using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class NewProductVm : IMapFrom<Product>
{
    public int Id { get; set; }
    public Guid UserId { get; init; }
    public ProductDetailsVm Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewProductVm, Product>().ReverseMap();
        profile.CreateMap<ProductDetailsVm, ProductDetails>().ReverseMap();
        profile.CreateMap<ProductCaloriesVm, ProductCalories>().ReverseMap();
    }
}

public class NewProductValidation : AbstractValidator<NewProductVm>
{
    public NewProductValidation()
    {
        RuleFor(x => x.Details).NotNull().SetValidator(new ProductDetailsValidation());
    }
}