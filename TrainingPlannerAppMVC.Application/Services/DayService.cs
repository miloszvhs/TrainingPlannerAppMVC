using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.DTO.ViewModels.Day;
using TrainingPlannerAppMVC.Domain.Interface;

namespace TrainingPlannerAppMVC.Application.Services
{
    public class DayService : IDayService
    {
        private readonly IDayRepository _dayRepository;

        public DayService(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public ListDayForListVm GetAllDaysByUserId(Guid id)
        {
            var days = _dayRepository.GetDaysByUserId(id);
            return new ListDayForListVm();
        }

        public DayDetailsVm GetDayDetailsByDayId(int id)
        {
            var details = _dayRepository.GetDayById(id);
            return new DayDetailsVm();
        }
    }
}
