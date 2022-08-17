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
    public class ExerciseForListVm : IMapFrom<Exercise>
    {
        public int Id { get; init; }
        public string ExerciseName { get; set; }
        public string Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Exercise, ExerciseForListVm>()
                .ForMember(x => x.Category, opt => opt.MapFrom(s => s.Category.CategoryName));
        }
    }
}
