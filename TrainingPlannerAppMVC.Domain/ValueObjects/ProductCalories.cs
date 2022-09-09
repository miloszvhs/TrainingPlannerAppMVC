using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.ValueObjects
{
    [Owned]
    public record ProductCalories
    {
        public ProductCalories()
        {
            
        }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }

        public decimal ToDecimal()
        {
            return Math.Round((Fat * 9) + (Carbs * 4) + (Proteins * 4), 2);
        }

        public override string ToString()
        {
            return ToDecimal().ToString().Replace(",", ".");
        }
    }
}
