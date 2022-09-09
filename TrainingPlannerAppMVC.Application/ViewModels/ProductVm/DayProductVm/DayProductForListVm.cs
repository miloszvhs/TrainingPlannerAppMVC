using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;

public class DayProductForListVm : IMapFrom<DayProduct>
{
    public int Id { get; init; }
    public Guid DayId { get; init; }
    public DayProductDetailsVm ProductDetails { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DayProduct, DayProductForListVm>();
        profile.CreateMap<DayProductDetails, DayProductDetailsVm>()
            .ForMember(x => x.Kcal, opt => opt.MapFrom(s => s.Calories.ToDecimal()));
        profile.CreateMap<ProductCalories, ProductCaloriesVm>();
    }
}