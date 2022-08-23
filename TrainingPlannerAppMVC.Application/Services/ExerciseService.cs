using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;

    public ExerciseService(IMapper mapper, IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
    }

    public ListExerciseForListVm GetExercisesByUserId(Guid userId, int pageSize, int pageNumber, string searchString)
    {
        var exercises = _exerciseRepository.GetAllExercisesByUserId(userId)
            .Where(p => p.ExerciseName.StartsWith(searchString))
            .ProjectTo<ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();

        var exerciseToShow = exercises.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        var exerciseList = new ListExerciseForListVm
        {
            PageSize = pageSize,
            CurrentPage = pageNumber,
            SearchString = searchString,
            Exercises = exerciseToShow,
            Count = exercises.Count,
            UserId = userId
        };

        return exerciseList;
    }

    public int AddExercise(NewExerciseVm exercise)
    {
        var exerciseModel = _mapper.Map<Exercise>(exercise);
        var result = _exerciseRepository.AddExercise(exerciseModel);
        return result;
    }

    public NewExerciseVm GetExerciseForEdit(int id)
    {
        var exercise = _exerciseRepository.GetExerciseById(id);
        var exerciseVm = _mapper.Map<NewExerciseVm>(exercise);
        return exerciseVm;
    }
    
    public int UpdateExercise(NewExerciseVm model)
    {
        var exercise = _mapper.Map<Exercise>(model);
        _exerciseRepository.UpdateExercise(exercise);
        return exercise.Id;
    }

    public int DeleteExercise(int id)
    {
        var result = _exerciseRepository.DeleteExercise(id);
        return result;
    }
}