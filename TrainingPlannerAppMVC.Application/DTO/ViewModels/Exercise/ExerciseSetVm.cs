using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise
{
    public class ExerciseSetVm
    {
        public int Id { get; set; }
        public int Reps { get; set; }
        public int BreakTimeInSeconds { get; set; }
        public decimal Weight { get; set; }
    }
}
