using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm
{
    public class ListDayExerciseForListVm
    {
        public List<DayExerciseForListVm> Exercises { get; set; }
        public int Count { get; set; }
    }
}
