using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    public class ExerciseCategoryRepository : IExerciseCategory
    {
        public int AddCategory(ExerciseCategory category)
        {
            throw new NotImplementedException();
        }

        public int DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExerciseCategory> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(ExerciseCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
