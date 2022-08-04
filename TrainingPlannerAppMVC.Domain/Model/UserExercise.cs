﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class UserExercise : AuditableEntity
    {
        public int UserExerciseId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string ExerciseName { get; set; }
        public virtual UserExerciseCategory UserExerciseCategory { get; set; }
    }
}