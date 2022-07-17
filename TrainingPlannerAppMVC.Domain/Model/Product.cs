using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CaloriesId { get; set; }
        public int DayId { get; set; }
        public virtual Calories Calories { get; set; }
        public virtual Day Day { get; set; }
    }
}
