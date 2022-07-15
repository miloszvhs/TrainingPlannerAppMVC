namespace TrainingPlannerAppMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public Calories Calories { get; set; }
    }
}
