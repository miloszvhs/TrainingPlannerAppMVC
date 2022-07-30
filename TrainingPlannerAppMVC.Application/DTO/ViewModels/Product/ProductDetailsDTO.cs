using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Calories;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Product
{
    public class ProductDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CaloriesDetailsDTO Calories { get; set; }
    }
}
