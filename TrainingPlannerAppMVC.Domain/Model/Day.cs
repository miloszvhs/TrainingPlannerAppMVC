using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Day : BaseEntity
    {
        public DateTime Date { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
