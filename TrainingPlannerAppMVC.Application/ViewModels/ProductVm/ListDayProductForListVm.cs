using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm
{
    public class ListDayProductForListVm
    {
        public List<DayProductForListVm> Products { get; set; }
        public int Count { get; set; }
        public decimal AllCarbs { get; set; }
        public decimal AllFat { get; set; }
        public decimal AllProteins { get; set; }
        public decimal AllKcal { get; set; }
    }
}
