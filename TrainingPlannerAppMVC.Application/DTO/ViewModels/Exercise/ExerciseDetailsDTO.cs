using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise
{
    public class ExerciseDetailsDTO
    {
        public string Name { get; set; }
        public int ExerciseDetailsId { get; set; }
        public virtual ExerciseDetailsDTO ExerciseDetails { get; set; }
        public int ExerciseCategoryId { get; set; }
        //public virtual ExerciseCategory ExerciseCategory { get; set; }
        public string Description { get; set; }
        public int Reps { get; set; }
        //public ICollection<ExerciseSet> Sets { get; set; }
        public int BreakTimeInSeconds { get; set; }
        public int ExerciseId { get; set; }
        //public virtual Exercise Exercise { get; set; }
    }
}
