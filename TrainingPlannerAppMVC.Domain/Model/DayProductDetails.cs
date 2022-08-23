using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class DayProductDetails
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public ProductCalories Calories { get; set; }
        public decimal Weight { get; set; }
        public int ProductId { get; set; }
        public virtual DayProduct Product { get; set; }
    }
}
