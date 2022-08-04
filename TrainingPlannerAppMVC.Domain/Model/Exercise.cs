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
        public int ExerciseId { get; set; }
        public Guid DayId { get; set; }
        public virtual Day Day { get; set; }
        public virtual ExerciseDetails ExerciseDetails { get; set; }
        public virtual ExerciseCategory ExerciseCategory { get; set; }
    }
}