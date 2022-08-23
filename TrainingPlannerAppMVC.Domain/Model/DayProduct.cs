using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class DayProduct
    {
        public int Id { get; init; }
        public virtual DayProductDetails ProductDetails { get; set; }
        public Guid DayId { get; init; } 
        public virtual Day Day { get; init; }
    }
}
