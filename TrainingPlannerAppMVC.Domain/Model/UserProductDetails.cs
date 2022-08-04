using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class UserProductDetails : AuditableEntity
    {
        public int UserProductDetailsId { get; set; }
        public string UserProductName { get; set; }
        public string UserProductDescription { get; set; }
        public ProductCalories UserProductCalories { get; set; }
        public int UserProductId { get; set; }
        public virtual UserProduct UserProduct { get; set; }
    }
}
