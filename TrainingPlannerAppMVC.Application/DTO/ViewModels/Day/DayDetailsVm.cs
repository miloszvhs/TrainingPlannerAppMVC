using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Day
{
    public class DayDetailsVm
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public List<ExerciseForListVm> Exercises { get; set; }
        //public List<CaloriesForListVm> Calories { get; set; }
    }
}
