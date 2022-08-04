using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ExerciseSet : AuditableEntity
    {
        public int ExerciseSetId { get; set; }
        public int ExerciseDetailsId { get; set; }
        public virtual ExerciseDetails ExerciseDetails { get; set; }
        public int BreakTimeInSeconds { get; set; }
        public int Reps { get; set; }
        public int Set { get; set; }
        public decimal Weight { get; set; }
    }
}
