using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ExerciseDetails : BaseEntity
    {
        public string Description { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int BreakTimeInSeconds { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}