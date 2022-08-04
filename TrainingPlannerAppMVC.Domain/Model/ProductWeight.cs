using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ProductWeight : AuditableEntity
    {
        public int ProductWeightId { get; set; }
        public int ProductDetailsId { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
        public decimal Weight { get; set; }
    }
}
