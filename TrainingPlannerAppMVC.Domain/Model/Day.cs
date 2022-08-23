using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Day : AuditableEntity
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public virtual User User { get; set; }
        public virtual ICollection<DayProduct>? DayProducts { get; set; }
        public virtual ICollection<DayExercise>? DayExercises { get; set; }
    }
}
