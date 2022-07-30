using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ExerciseCategory : AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
