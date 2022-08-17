using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.ViewModels.DayVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

namespace TrainingPlannerAppMVC.Application.Interfaces
{
    public interface IDayService
    {
        ListDayProductForListVm GetAllProductsByDayId(Guid dayId);
        ListDayForListVm GetAllDaysByUserId(Guid userId);
        DayDetailsVm GetDayDetailsByUserId(Guid userId);
    }
}
