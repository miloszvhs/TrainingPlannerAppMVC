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
        int AddDay(Day day);
        int UpdateDay(Day day);
        int DeleteDay(int dayId);
        IQueryable<Day> GetAllDays();
        IQueryable<Day> GetDaysByUserId(Guid userId);
        Day GetDayById(int dayId);
    }
}
