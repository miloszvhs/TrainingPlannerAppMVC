using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class ProductForListVm : IMapFrom<Product>
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public ProductDetailsVm Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductForListVm>();
        profile.CreateMap<ProductDetails, ProductDetailsVm>();
        profile.CreateMap<ProductCalories, ProductCaloriesVm>();
    }
}