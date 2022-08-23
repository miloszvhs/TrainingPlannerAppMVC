namespace TrainingPlannerAppMVC.Application.ViewModels.DayVm;

public class ListDayForListVm
{
    public List<DayForListVm> Days { get; set; }
    public bool AllowDayCreate { get; init; }
    public Guid UserId { get; init; }
}