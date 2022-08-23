using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class DayExerciseDetails
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DayExerciseSet> Sets { get; set; }
        public int ExerciseId { get; set; }
        public virtual DayExercise Exercise { get; set; }
    }
}