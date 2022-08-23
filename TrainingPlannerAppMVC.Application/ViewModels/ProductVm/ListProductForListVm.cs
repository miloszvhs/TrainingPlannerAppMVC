namespace TrainingPlannerAppMVC.Application.ViewModels.ProductVm;

public class ListProductForListVm
{
    public List<ProductForListVm> Products { get; set; }
    public int Count { get; set; }
    public Guid UserId { get; init; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public string SearchString { get; set; }
}