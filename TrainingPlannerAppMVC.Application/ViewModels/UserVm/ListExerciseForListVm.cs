using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

namespace TrainingPlannerAppMVC.Application.ViewModels.UserVm
{
    public class ListExerciseForListVm
    {
        public List<ExerciseForListVm> Exercises { get; set; }
        public int Count { get; set; }
    }
}
