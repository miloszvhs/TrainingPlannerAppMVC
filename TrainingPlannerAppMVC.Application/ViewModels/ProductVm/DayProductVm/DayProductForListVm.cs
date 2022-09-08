using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class DayProductForListVm : IMapFrom<DayProduct>
{
    public int Id { get; init; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public DayProductDetailsVm Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayProduct, DayProductForListVm>();
        profile.CreateMap<DayProductDetails, DayProductDetailsVm>()
            .ForMember(x => x.Kcal, opt => opt.MapFrom(s => s.Calories.ToDecimal()));
        profile.CreateMap<ProductCalories, ProductCaloriesVm>();
    }
}