using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.DayVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.Services;

public class DayService : IDayService
{
    private readonly IDayExerciseRepository _dayExerciseRepository;
    private readonly IDayProductRepository _dayProductRepository;
    private readonly IDayRepository _dayRepository;
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

        var dayList = new ListDayForListVm
        {
            Days = days,
            AllowDayCreate = CheckIfDayOfCurrentDateExistByUserId(userId),
            UserId = userId
        };

        return dayList;
    }

    public ListDayProductForListVm GetAllProductsByDayId(Guid dayId)
    {
        var products = _dayProductRepository.GetProductsByDayId(dayId)
            .ProjectTo<DayProductForListVm>(_mapper.ConfigurationProvider).ToList();

        var productList = new ListDayProductForListVm
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

    public DayDetailsVm GetDayDetailsByUserId(Guid dayId)
    {
        var day = _mapper.Map<DayDetailsVm>(_dayRepository.GetDayById(dayId));

        return day;
    }

    public Guid AddDay(Guid userId)
    {
        var day = new NewDayVm { UserId = userId };
        var dayModel = _mapper.Map<Day>(day);
        var result = _dayRepository.AddDay(dayModel);

        return result;
    }

    public ListDayExerciseForListVm GetAllExercisesByDayId(Guid dayId)
    {
        var exercises = _dayExerciseRepository.GetAllExercisesByDayId(dayId)
            .ProjectTo<DayExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

        var exercisesList = new ListDayExerciseForListVm
        {
            Exercises = exercises,
            Count = exercises.Count
        };

        return exercisesList;
    }

    private bool CheckIfDayOfCurrentDateExistByUserId(Guid userId)
    {
        var days = _dayRepository.GetDaysByUserId(userId);
        var currentDay = days.FirstOrDefault(x => x.CreatedOn.Date == DateTime.Now.Date);

        return currentDay == null;
    }
}