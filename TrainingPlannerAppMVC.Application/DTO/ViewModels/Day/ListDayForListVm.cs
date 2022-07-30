using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Day
{
    public class ListDayForListVm
    {
        public List<DayForListVm> Days { get; set; }
        public int Count { get; set; }
        public Guid UserId { get; set; }
    }
}
