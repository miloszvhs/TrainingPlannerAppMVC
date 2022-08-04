using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IUserExerciseRepository
    {
        int AddExercise(UserExercise exercise);
        int DeleteExercise(int exerciseId);
        int UpdateExercise(UserExercise exercise);
        IQueryable<UserExercise> GetAllExercises();
        IQueryable<UserExercise> GetAllExercisesByUserId(Guid userId);
        UserExercise GetExerciseById(int exerciseId);
    }
}
