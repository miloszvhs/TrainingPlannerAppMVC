using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Exercise : AuditableEntity
    {
        public string Name { get; set; }
        public int DayId { get; set; }
        public virtual Day Day { get; set; }
        public virtual ExerciseDetails ExerciseDetails { get; set; }
        public virtual ICollection<ExerciseCategory> ExerciseCategories { get; set; }
    }
}