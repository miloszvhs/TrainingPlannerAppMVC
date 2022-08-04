using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise
{
    public class ListExerciseForListVm
    {
        public List<ExerciseForListVm> Exercises { get; set; }
        public int Count { get; set; }
    }
}
