using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise;

namespace TrainingPlannerAppMVC.Application.Interfaces
{
    public interface IExerciseService
    {
        ListExerciseForListVm GetAllExercisesByUserId(Guid id);
        ListExerciseForListVm GetAllExercisesByDayId(Guid id);
        ExerciseDetailsVm GetExerciseById(int id);
        int AddExercise(ExerciseAddVm exercise);
    }
}
