using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    internal class DayExerciseRepository : IDayExerciseRepository
    {
        private readonly Context _context;

        public DayExerciseRepository(Context context)
        {
            _context = context;
        }

        public int AddExercise(DayExercise exercise)
        {
            _context.DayExercises.Add(exercise);
            _context.SaveChanges();
            return exercise.Id;
        }

        public int DeleteExercise(int exerciseId)
        {
            var exercise = _context.DayExercises.FirstOrDefault(x => x.Id == exerciseId);
            if (exercise != null)
            {
                _context.DayExercises.Remove(exercise);
                _context.SaveChanges();
                return exerciseId;
            }
            return -1;
        }

        public IQueryable<DayExercise> GetAllExercises()
        {
            var exercises = _context.DayExercises;
            return exercises;
        }

        public IQueryable<DayExercise> GetAllExercisesByDayId(Guid dayId)
        {
            var exercises = _context.DayExercises.Where(x => x.DayId == dayId);
            return exercises;
        }

        public DayExercise GetExerciseById(int exerciseId)
        {
            var exercise = _context.DayExercises
                .Include(x => x.ExerciseCategory)
                .Include(x => x.ExerciseDetails)
                .ThenInclude(x => x.Sets)
                .FirstOrDefault(x => x.Id == exerciseId);
            return exercise;
        }

        public IQueryable<DayExercise> GetExercisesByCategoryId(int categoryId)
        {
            var exercises = _context.DayExercises.Where(x => x.ExerciseCategory.Id == categoryId);
            return exercises;
        }

        public void UpdateExercise(DayExercise exercise)
        {
            _context.Update(exercise);
            _context.SaveChanges();
        }
    }
}
