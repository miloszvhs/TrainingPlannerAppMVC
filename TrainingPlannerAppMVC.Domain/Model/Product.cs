using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ProductDetails Details { get; set; }
    }
}
