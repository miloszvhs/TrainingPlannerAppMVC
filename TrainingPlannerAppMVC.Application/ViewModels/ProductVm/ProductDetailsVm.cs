using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm
{
    public class ProductDetailsVm : IMapFrom<ProductDetails>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCaloriesVm Calories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductDetails, ProductDetailsVm>();
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
}
