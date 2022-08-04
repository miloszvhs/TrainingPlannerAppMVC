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
    public class ExerciseCategoryRepository : IExerciseCategoryRepository
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
            return category.ExerciseCategoryId;
        }

        public int DeleteCategory(int id)
        {
            var category = _context.ExerciseCategories.FirstOrDefault(c => c.ExerciseCategoryId == id);

            if (category != null)
            {
                _context.ExerciseCategories.Remove(category);
                _context.SaveChangesAsync();
                return id;
            }
            return -1;
        }

        public IQueryable<ExerciseCategory> GetAllCategories()
        {
            var categories = _context.ExerciseCategories;
            return categories;
        }

        public string GetCategoryByExerciseId(int exerciseId)
        {
            var category = _context.ExerciseCategories.Include(x => x.Exercises)
                .FirstOrDefault(x => x.Exercises.FirstOrDefault().ExerciseId == exerciseId).Name;
            return category;
        }

        public int UpdateCategory(ExerciseCategory category)
        {
            var entity = _context.ExerciseCategories.FirstOrDefault(c => c.ExerciseCategoryId == category.ExerciseCategoryId);

            if (entity != null)
            {
                entity = category;
                _context.SaveChangesAsync();
                return entity.ExerciseCategoryId;
            }
            return -1;
        }
    }
}
