using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm
{
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
}
