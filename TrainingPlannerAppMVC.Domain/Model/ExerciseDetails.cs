using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ExerciseDetails : AuditableEntity
    {
        public int ExerciseDetailsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ExerciseSet> Sets { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}