namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> meals = Console.ReadLine().Split().ToList();
            List<int> calories = Console.ReadLine().Split().Select(int.Parse).ToList();

            int count = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                int mealCalories = Calories(meals[0]);
                int dailyCalories = calories[0];

                if (mealCalories <= dailyCalories)
                {
                    meals.RemoveAt(0);
                    calories[0] -= mealCalories;

                    if (calories[0] == 0)
                    {
                        calories.RemoveAt(0);
                    }
                }
                else
                {
                    meals[0] = Subtract(meals[0], dailyCalories);
                    calories.RemoveAt(0);
                }

                count++;
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }

        static int Calories(string meal)
        {
            switch (meal)
            {
                case "salad": return 350;
                case "soup": return 490;
                case "pasta": return 680;
                case "steak": return 790;
                default: return 0;
            }
        }

        static string Subtract(string meal, int calories)
        {
            int mealCalories = Calories(meal);
            int remaining = mealCalories - calories;

            if (remaining <= 0)
            {
                return "none";
            }

            return $"{meal.Substring(0, meal.Length - 1)} {remaining}";
        }
    }
}
