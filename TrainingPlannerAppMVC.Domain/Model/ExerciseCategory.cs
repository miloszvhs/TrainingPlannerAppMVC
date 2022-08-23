using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ExerciseCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Exercise> UserExercises { get; set; }
    }
}
