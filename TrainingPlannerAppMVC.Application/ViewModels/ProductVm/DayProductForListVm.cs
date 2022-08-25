using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class DayProductForListVm : IMapFrom<DayProduct>
{
    public int Id { get; init; }
    public string Name { get; set; }
    public decimal Fat { get; set; }
    public decimal Carbs { get; set; }
    public decimal Proteins { get; set; }
    public decimal Kcal { get; set; }
    public decimal Weight { get; set; }
    public ProductDetailsVm Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayProduct, DayProductForListVm>()
            .ForMember(x => x.Name, opt => opt.MapFrom(s => s.ProductDetails.Name))
            .ForMember(x => x.Fat, opt => opt.MapFrom(s => s.ProductDetails.Calories.Fat))
            .ForMember(x => x.Carbs, opt => opt.MapFrom(s => s.ProductDetails.Calories.Carbs))
            .ForMember(x => x.Proteins, opt => opt.MapFrom(s => s.ProductDetails.Calories.Proteins))
            .ForMember(x => x.Kcal, opt => opt.MapFrom(s => s.ProductDetails.Calories.ToDecimal()))
            .ForMember(x => x.Weight, opt => opt.MapFrom(s => s.ProductDetails.Weight));
        profile.CreateMap<ProductDetails, ProductDetailsVm>();
        profile.CreateMap<ProductCalories, ProductCaloriesVm>();
    }
}