﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Common;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Domain.Model
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public Guid DayId { get; set; }
        public virtual Day Day { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
