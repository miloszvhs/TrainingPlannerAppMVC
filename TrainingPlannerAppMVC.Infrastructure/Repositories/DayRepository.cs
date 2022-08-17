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
            _context.SaveChanges();
            return day.Id;
        }

        public Guid DeleteDay(Guid dayId)
        {
            var day = _context.Days.FirstOrDefault(x => x.Id == dayId);
            
            if (day != null)
            {
                _context.Days.Remove(day);
                _context.SaveChanges();
                return day.Id;
            }
            return Guid.Empty;
        }

        public Guid UpdateDay(Day day)
        {
            var entity = _context.Days.FirstOrDefault(x => x.Id == day.Id);

            if (entity != null)
            {
                entity = day;
                _context.SaveChanges();
                return entity.Id;
            }
            return Guid.Empty;
        }

        public IQueryable<Day> GetAllDays()
        {
            return _context.Days;
        }

        public Day GetDayById(Guid dayId)
        {
            var day = _context.Days.FirstOrDefault(x => x.Id == dayId);
            return day;
        }

        public IQueryable<Day> GetDaysByUserId(Guid userId)
        {
            var days = _context.Days.Where(x => x.UserId == userId);
            return days;
        }
    }
}
