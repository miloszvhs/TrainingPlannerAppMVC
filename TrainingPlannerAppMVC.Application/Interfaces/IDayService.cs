using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Day;

namespace TrainingPlannerAppMVC.Application.Interfaces
{
    public interface IDayService
    {
        ListDayForListVm GetAllDaysByUserId(Guid id);
        DayDetailsVm GetDayDetailsByDayId(Guid id);
    }
}
