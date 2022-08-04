using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    public class DayRepository : IDayRepository
    {
        private readonly Context _context;
        
        public DayRepository(Context context)
        {
            _context = context;
        }

        public Guid AddDay(Day day)
        {
            _context.Days.Add(day);
            _context.SaveChangesAsync();
            return day.DayId;
        }

        public Guid DeleteDay(Guid dayId)
        {
            var day = _context.Days.FirstOrDefault(x => x.DayId == dayId);
            
            if (day != null)
            {
                _context.Days.Remove(day);
                _context.SaveChangesAsync();
                return day.DayId;
            }
            return Guid.Empty;
        }

        public IQueryable<Day> GetAllDays()
        {
            return _context.Days;
        }

        public Day GetDayById(Guid dayId)
        {
            var day = _context.Days.FirstOrDefault(x => x.DayId == dayId);
            return day;
        }

        public IQueryable<Day> GetDaysByUserId(Guid userId)
        {
            var days = _context.Days.Where(x => x.UserId == userId);
            return days;
        }

        public Guid UpdateDay(Day day)
        {
            var entity = _context.Days.FirstOrDefault(x => x.DayId == day.DayId);
            
            if (entity != null)
            {
                entity = day;
                _context.SaveChangesAsync();
                return entity.DayId;
            }
            return Guid.Empty;
        }
    }
}
