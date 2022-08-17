using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.DayVm
{
    public class DayDetailsVm
    {
        public Guid Id { get; init; }
        public ListDayProductForListVm Products { get; set; }
        public ListDayExerciseForListVm Exercises { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Day, DayDetailsVm>();
        }
    }
}
