using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class DayExercise : AuditableEntity
    {
        public int Id { get; init; }
        public virtual DayExerciseDetails ExerciseDetails { get; set; }
        public virtual DayExerciseCategory ExerciseCategory { get; set; }
        public Guid DayId { get; init; }
        public virtual Day Day { get; init; }
    }
}