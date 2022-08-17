/*using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Exercise;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Domain.Interface;

namespace TrainingPlannerAppMVC.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IDayExerciseRepository _exerciseRepository;
        
        public ExerciseService()
        {

        }
        public int AddExercise(ExerciseAddVm exercise)
        {
            throw new NotImplementedException();
        }

        public ListExerciseForListVm GetAllExercisesByDayId(Guid id)
        {
            var exercises = _exerciseRepository.GetAllExercisesByDayId(id);
            ListExerciseForListVm result = new();
            foreach (var item in exercises)
            {
                result.Exercises.Add(new ExerciseForListVm()
                {
                    Id = item.Id,
                    Name = item.ExerciseDetails.Name,
                    Category = item.ExerciseCategory.Name
                });
            }
            result.Count = exercises.Count();
            return result;
        }

        public ListExerciseForListVm GetAllExercisesByUserId(Guid id)
        {
            var exercises = _exerciseRepository.GetAllExercisesByUserId(id);
            ListExerciseForListVm result = new ListExerciseForListVm();
            result.Exercises = new List<ExerciseForListVm>();
            foreach (var exercise in exercises)
            {
                var vm = new ExerciseForListVm()
                {
                    Id = exercise.Id,
                    Name = exercise.ExerciseDetails.Name,
                    Category = _exerciseRepository.GetExerciseById(exercise.Id).ExerciseCategory.Name
                };
                result.Exercises.Add(vm);
            }
            result.Count = result.Exercises.Count;
            return result;
        }

        public ExerciseDetailsVm GetExerciseById(int id)
        {
            var exercise = _exerciseRepository.GetExerciseById(id);
            var result = new ExerciseDetailsVm();
            result.Sets = new();
            foreach (var item in exercise.ExerciseDetails.Sets)
            {
                result.Sets.Add(new ExerciseSetVm()
                {
                    Reps = item.Reps,
                    Weight = item.Weight,
                    BreakTimeInSeconds = item.BreakTimeInSeconds
                });
            }
            result.Name = exercise.ExerciseDetails.Name;
            result.Id = exercise.Id;
            return result;
        }
    }
}
*/