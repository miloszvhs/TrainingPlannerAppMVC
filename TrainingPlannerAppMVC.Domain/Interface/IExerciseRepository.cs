using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IExerciseRepository
    {
        int AddExercise(Exercise exercise);
        int DeleteExercise(int exerciseId);
        void UpdateExercise(Exercise exercise);
        IQueryable<Exercise> GetAllExercises();
        IQueryable<Exercise> GetAllExercisesByUserId(Guid userId);
        Exercise GetExerciseById(int exerciseId);
    }
}
