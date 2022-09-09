using TrainingPlannerAppMVC.Application.ViewModels.DayVm;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;

namespace TrainingPlannerAppMVC.Application.Interfaces;

public interface IDayService
{
    ListDayProductForListVm GetAllProductsByDayId(Guid dayId);
    ListDayExerciseForListVm GetAllExercisesByDayId(Guid dayId);
    ListDayForListVm GetAllDaysByUserId(Guid userId);
    DayDetailsVm GetDayDetailsByUserId(Guid userId);
    Guid AddDay(Guid userId);
    DayDetailsVm GetDayById(Guid dayId);
    void AddProductToDay(NewDayProductVm product);
    void AddExerciseToDay(NewDayExerciseVm exercise);
    NewDayExerciseVm GetExerciseById(int id);
    void UpdateExercise(NewDayExerciseVm exercise);
    NewDayProductVm GetProductById(int id);
    void UpdateProduct(NewDayProductVm product);
}