﻿using TrainingPlannerAppMVC.Helpers;

namespace TrainingPlannerAppMVC.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MuscleCategory Category { get; set; }

    }
}
