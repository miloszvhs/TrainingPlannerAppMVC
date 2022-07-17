using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Day : BaseEntity
    {
        public DateTime Time { get; set; } = DateTime.Now.Date;
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
