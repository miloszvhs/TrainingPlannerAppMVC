namespace TrainingPlannerAppMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Calories Calories { get; set; }
        private Calories _calories { get; set; } = new Calories();

        public Product(int id, string name, Calories calories, double weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Calories = calories;
        }

        public Product()
        {

        }
    }
}
