using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ExerciseSet : BaseEntity
    {
        public int ExerciseDetailsId { get; set; }
        public virtual ExerciseDetails ExerciseDetails { get; set; }
        public int Set { get; set; }
        public decimal Weight { get; set; }
    }
}
