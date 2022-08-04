using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class UserExerciseCategory : AuditableEntity
    {
        public int UserExerciseCategoryId { get; set; }
        public string UserExerciseCategoryName { get; set; }
        public virtual ICollection<UserExercise> UserExercises { get; set; }
    }
}
