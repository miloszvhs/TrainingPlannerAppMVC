using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class DayExerciseCategory
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public virtual ICollection<DayExercise> Exercises { get; set; }
    }
}
