using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

namespace TrainingPlannerAppMVC.Application.Interfaces;

public interface IExerciseService
{
    ListExerciseForListVm GetExercisesByUserId(Guid userId, int pageSize, int pageNumber, string searchString);
    /*ListExerciseForListVm GetAllExercisesByDayId(Guid id);
    ExerciseDetailsVm GetExerciseById(int id);*/
    int AddExercise(NewExerciseVm exercise);
    NewExerciseVm GetExerciseForEdit(int id);
    int UpdateExercise(NewExerciseVm exercise);
    int DeleteExercise(int id);
}