﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IExerciseRepository
    {
        int AddExercise(Exercise exercise);
        int DeleteExercise(int exerciseId);
        int UpdateExercise(Exercise exercise);
        IQueryable<Exercise> GetExercisesByCategoryId(int categoryId);
        Exercise GetExerciseById(int exerciseId);
        IQueryable<Exercise> GetAllExercises();
        IQueryable<Exercise> GetAllExercisesByUserId(Guid userId);
        IQueryable<Exercise> GetAllExercisesByDayId(Guid dayId);
    }
}
