namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm.DayProductVm;

public class ListDayProductForListVm
{
    public Guid DayId { get; init; }
    public List<DayProductForListVm> Products { get; set; }
    public int Count { get; set; }
    public decimal AllCarbs { get; set; }
    public decimal AllFat { get; set; }
    public decimal AllProteins { get; set; }
    public decimal AllKcal { get; set; }
}