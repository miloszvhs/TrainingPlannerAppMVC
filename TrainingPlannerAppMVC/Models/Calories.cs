namespace TrainingPlannerAppMVC.Models
{
    public class Calories
    {
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public double Proteins { get; set; }
        public double Kcal { get; set; }

        public Calories(double fat, double carbs, double proteins)
        {
            Fat = fat;
            Carbs = carbs;
            Proteins = proteins;

            Kcal = (Fat * 9) + (Carbs * 4) + (Proteins * 4);
        }
    }
}
