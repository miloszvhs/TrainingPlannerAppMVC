using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm
{
    public class DayExerciseSetVm : IMapFrom<DayExerciseSet>
    {
        public int BreakTimeInSeconds { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DayExerciseSet, DayExerciseSetVm>();
        }
    }
}
