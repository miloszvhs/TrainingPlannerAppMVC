using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class DayExerciseSet
    {
        public int Id { get; init; }
        public int DetailsId { get; set; }
        public virtual DayExerciseDetails Details { get; set; }
        public int BreakTimeInSeconds { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}
