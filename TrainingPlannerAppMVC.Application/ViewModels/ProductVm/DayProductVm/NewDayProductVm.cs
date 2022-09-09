using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;

public class NewDayProductVm : IMapFrom<DayProduct>
{
    public int Id { get; init; }
    public Guid DayId { get; init; }
    public DayProductDetailsVm ProductDetails { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewDayProductVm, DayProduct>().ReverseMap();
        profile.CreateMap<DayProductDetailsVm, DayProductDetails>()
            .ReverseMap()
            .ForMember(x => x.Kcal,
                opt => opt.MapFrom(s => s.Calories.ToDecimal() * decimal.Multiply(s.Weight, (decimal)0.01)));
        profile.CreateMap<ProductCaloriesVm, ProductCalories>().ReverseMap();
    }
}

public class NewDayProductValidation : AbstractValidator<NewDayProductVm>
{
    public NewDayProductValidation()
    {
        RuleFor(x => x.ProductDetails).SetValidator(new DayProductDetailsValidation());
    }
}