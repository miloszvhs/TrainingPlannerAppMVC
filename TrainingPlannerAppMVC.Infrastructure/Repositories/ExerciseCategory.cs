using Microsoft.EntityFrameworkCore;
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
        private readonly Context _context;
        
        public ExerciseCategoryRepository(Context context)
        {
            _context = context;
        }

        public int AddCategory(ExerciseCategory category)
        {
            _context.ExerciseCategories.Add(category);
            _context.SaveChangesAsync();
            return category.Id;
        }

        public int DeleteCategory(int id)
        {
            var category = _context.ExerciseCategories.FirstOrDefault(c => c.Id == id);

            if (category != null)
            {
                _context.ExerciseCategories.Remove(category);
                _context.SaveChangesAsync();
            }
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
