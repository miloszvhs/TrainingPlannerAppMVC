using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IDayExerciseRepository
    {
        int AddExercise(DayExercise exercise);
        int DeleteExercise(int exerciseId);
        void UpdateExercise(DayExercise exercise);
        IQueryable<DayExercise> GetExercisesByCategoryId(int categoryId);
        DayExercise GetExerciseById(int exerciseId);
        IQueryable<DayExercise> GetAllExercises();
        IQueryable<DayExercise> GetAllExercisesByDayId(Guid dayId);
    }
}
