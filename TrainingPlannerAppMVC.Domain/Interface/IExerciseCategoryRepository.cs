using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IExerciseCategoryRepository
    {
        int AddCategory(ExerciseCategory category);
        int DeleteCategory(int id);
        int UpdateCategory(ExerciseCategory category);
        IQueryable<ExerciseCategory> GetAllCategories();
        string GetCategoryByExerciseId(int exerciseId);
    }
}
