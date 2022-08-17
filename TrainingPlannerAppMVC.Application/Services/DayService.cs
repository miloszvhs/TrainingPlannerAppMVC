using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingPlannerAppMVC.Application.ViewModels.DayVm;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

namespace TrainingPlannerAppMVC.Application.Services
{
    public class DayService : IDayService
    {
        private readonly IDayRepository _dayRepository;
        private readonly IDayExerciseRepository _dayExerciseRepository;
        private readonly IDayProductRepository _dayProductRepository;
        private readonly IMapper _mapper;

        public DayService(IDayRepository dayRepository,
            IDayProductRepository dayProductRepository,
            IDayExerciseRepository dayExerciseRepository,
            IMapper mapper)
        {
            _dayRepository = dayRepository;
            _dayProductRepository = dayProductRepository;
            _dayExerciseRepository = dayExerciseRepository;
            _mapper = mapper;
        }

        public ListDayForListVm GetAllDaysByUserId(Guid userId)
        {
            var days = _dayRepository.GetDaysByUserId(userId)
                .ProjectTo<DayForListVm>(_mapper.ConfigurationProvider).ToList();

            var dayList = new ListDayForListVm()
            {
                Days = days
            };

            return dayList;
        }

        public ListDayProductForListVm GetAllProductsByDayId(Guid dayId)
        {
            var products = _dayProductRepository.GetProductsByDayId(dayId)
                .ProjectTo<DayProductForListVm>(_mapper.ConfigurationProvider).ToList();

            var productList = new ListDayProductForListVm()
            {
                Products = products,
                Count = products.Count,
                AllFat = Math.Round(products.Select(x => x.Fat).Sum(), 2),
                AllCarbs = Math.Round(products.Select(x => x.Carbs).Sum(), 2),
                AllProteins = Math.Round(products.Select(x => x.Proteins).Sum(), 2),
                AllKcal = Math.Round(products.Select(x => x.Kcal).Sum(), 2)
            };

            return productList;
        }

        public ListDayExerciseForListVm GetAllExercisesByDayId(Guid dayId)
        {
            var exercises = _dayExerciseRepository.GetAllExercisesByDayId(dayId)
                .ProjectTo<DayExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

            var exercisesList = new ListDayExerciseForListVm()
            {
                Exercises = exercises,
                Count = exercises.Count
            };

            return exercisesList;
        }

        public DayDetailsVm GetDayDetailsByUserId(Guid dayId)
        {
            var day = _mapper.Map<DayDetailsVm>(_dayRepository.GetDayById(dayId));

            return day;
        }
    }
}
