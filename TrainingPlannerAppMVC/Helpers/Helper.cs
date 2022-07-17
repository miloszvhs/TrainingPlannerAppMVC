using TrainingPlannerAppMVC.Models;

namespace TrainingPlannerAppMVC.Helpers
{
    static class ListOfExercises
    {
        public static List<Exercise> list = new List<Exercise>()
        {
            new Exercise() { Id = 1, Title = "Przysiady", Description = "Przysiady ze sztangą na plecach", Category = MuscleCategory.Legs},
            new Exercise() { Id = 2, Title = "Podciąganie", Description = "Podciąganie podchwytem", Category = MuscleCategory.Chest},
            new Exercise() { Id = 3, Title = "Uginanie gryfa prostego stojąc", Description = "Stojąc uginasz gryfa do maksymalnego spięcią", Category = MuscleCategory.Arms}
        };
    }

    static class ListOfProducts
    {
        public static List<Product> list = new List<Product>()
        {
            new Product(1, "Boczek", new Calories(30, 0.5, 20), 100),
            new Product(2, "Jajko",  new Calories(9.7, 0.6, 12.5), 100),
            new Product(3, "Masło",  new Calories(88, 0.5, 0.5), 100),
            new Product(4, "Test",   new Calories(100, 10, 10), 90),
        };
    }

    public enum MuscleCategory { Chest, Legs, Back, Arms, Shoulders, Abs, Buttocks };
}
