using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm
{
    public class NewProductVm : IMapFrom<Product>
    {
        public int Id { get; set; }
        public Guid UserId { get; init; }
        public ProductDetailsVm Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewProductVm, Product>();
            profile.CreateMap<ProductDetailsVm, ProductDetails>();
            profile.CreateMap<ProductCaloriesVm, ProductCalories>();

        }
    }

    public class NewProductValidation : AbstractValidator<NewProductVm>
    {
        public NewProductValidation()
        {
            RuleFor(x => x.Details).NotNull().SetValidator(new ProductDetailsValidation());
        }
    }
}
