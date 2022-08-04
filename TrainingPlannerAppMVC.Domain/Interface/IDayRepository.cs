using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IDayRepository
    {
        Guid AddDay(Day day);
        Guid UpdateDay(Day day);
        Guid DeleteDay(Guid dayId);
        IQueryable<Day> GetAllDays();
        IQueryable<Day> GetDaysByUserId(Guid userId);
        Day GetDayById(Guid dayId);
    }
}
