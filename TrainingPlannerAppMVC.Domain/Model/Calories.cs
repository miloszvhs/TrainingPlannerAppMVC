using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Calories : BaseEntity
    {
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }
        public decimal Proteins { get; set; }
        public decimal Kcal { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
