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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly Context _context;

        public ExerciseRepository(Context context)
        {
            _context = context;
        }

        public int AddExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return exercise.Id;
        }

        public int DeleteExercise(int exerciseId)
        {
            var exercise = _context.Exercises.FirstOrDefault(x => x.Id == exerciseId);

            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                _context.SaveChanges();
                return exercise.Id;
            }
            return -1;
        }

        public void UpdateExercise(Exercise exercise)
        {
            _context.Update(exercise);
            _context.SaveChanges();
        }

        public IQueryable<Exercise> GetAllExercises()
        {
            var exercises = _context.Exercises.Include(x => x.Category);
            return exercises;
        }

        public IQueryable<Exercise> GetAllExercisesByUserId(Guid userId)
        {
            var exercises = _context.Exercises.Include(x => x.Category).Where(x => x.UserId == userId);
            return exercises;
        }

        public Exercise GetExerciseById(int exerciseId)
        {
            var exercise = _context.Exercises.Include(x => x.Category).FirstOrDefault(x => x.Id == exerciseId);
            return exercise;
        }
    }
}
