﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class ProductDetails : AuditableEntity
    {
        public int ProductDetailsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductCalories Calories { get; set; }
        public virtual ProductWeight Weight { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
