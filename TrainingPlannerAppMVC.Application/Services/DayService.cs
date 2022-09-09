using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.DayVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.Services;

public class DayService : IDayService
{
    private readonly IDayExerciseRepository _dayExerciseRepository;
    private readonly IDayProductRepository _dayProductRepository;
    private readonly IDayRepository _dayRepository;
    private readonly IMapper _mapper;
    private IDayService _dayServiceImplementation;

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

    public ListDayExerciseForListVm GetAllExercisesByDayId(Guid dayId)
    {
        var dayExercises = _dayExerciseRepository.GetAllExercisesByDayId(dayId)
            .ProjectTo<DayExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

        var dayExerciseList = new ListDayExerciseForListVm
        {
            Exercises = dayExercises,
            Count = dayExercises.Count
        };

        return dayExerciseList;
    }

    public ListDayProductForListVm GetAllProductsByDayId(Guid dayId)
    {
        var products = _dayProductRepository.GetProductsByDayId(dayId)
            .ProjectTo<DayProductForListVm>(_mapper.ConfigurationProvider).ToList();

        var productList = new ListDayProductForListVm
        {
            Products = products,
            Count = products.Count,
            AllFat = products.Sum(x => x.ProductDetails.Calories.Fat),
            AllCarbs = products.Sum(x => x.ProductDetails.Calories.Carbs),
            AllProteins = products.Sum(x => x.ProductDetails.Calories.Proteins),
            AllKcal = products.Sum(x => x.ProductDetails.Kcal)
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

    public DayDetailsVm GetDayById(Guid dayId)
    {
        var dayProductList = GetAllProductsByDayId(dayId);

        var dayExerciseList = GetAllExercisesByDayId(dayId);

        var dayVm = new DayDetailsVm
        {
            Id = dayId,
            Products = dayProductList,
            Exercises = dayExerciseList
        };

        return dayVm;
    }

    public void AddProductToDay(NewDayProductVm product)
    {
        var entity = _mapper.Map<DayProduct>(product);
        _dayProductRepository.AddProduct(entity);
    }

    public void AddExerciseToDay(NewDayExerciseVm exercise)
    {
        var entity = _mapper.Map<DayExercise>(exercise);
        _dayExerciseRepository.AddExercise(entity);
    }

    public NewDayExerciseVm GetExerciseById(int id)
    {
        var exercise = _dayExerciseRepository.GetExerciseById(id);
        var exerciseVm = _mapper.Map<NewDayExerciseVm>(exercise);
        return exerciseVm;
    }

    public void UpdateExercise(NewDayExerciseVm model)
    {
        var exercise = _mapper.Map<DayExercise>(model);
        _dayExerciseRepository.UpdateExercise(exercise);
    }

    public NewDayProductVm GetProductById(int id)
    {
        var product = _dayProductRepository.GetProductById(id);
        var productVm = _mapper.Map<NewDayProductVm>(product);
        return productVm;
    }

    public void UpdateProduct(NewDayProductVm model)
    {
        var product = _mapper.Map<DayProduct>(model);
        _dayProductRepository.UpdateProduct(product);
    }

    private bool CheckIfDayOfCurrentDateExistByUserId(Guid userId)
    {
        var days = _dayRepository.GetDaysByUserId(userId);
        var currentDay = days.FirstOrDefault(x => x.CreatedOn.Date == DateTime.Now.Date);

        return currentDay == null;
    }
}