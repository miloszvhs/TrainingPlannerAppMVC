using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise
{
    public class ExerciseDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseSetVm> Sets { get; set; }
    }
}
