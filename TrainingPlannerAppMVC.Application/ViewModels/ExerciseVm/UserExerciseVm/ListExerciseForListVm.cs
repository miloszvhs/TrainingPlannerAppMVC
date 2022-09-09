namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.UserExerciseVm;

public class ListExerciseForListVm
{
    public List<ExerciseForListVm> Exercises { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public int Count { get; set; }
    public Guid UserId { get; set; }
}