using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class UserProduct : AuditableEntity
    {
        public int UserProductId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual UserProductDetails UserProductDetails { get; set; }
    }
}
