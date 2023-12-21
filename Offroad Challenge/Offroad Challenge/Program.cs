namespace Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> fuel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> cons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> nFuel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> altitude = new List<int>();

            while (fuel.Any() && cons.Any() && fuel.Any())
            {
                int currFuel = fuel.Last();
                int currConsumption = cons.First();
                int currAltitude = fuel.First();
                int result = currFuel - currConsumption;

                if (result >= currAltitude)
                {
                    altitude.Add(currAltitude);
                    fuel.RemoveAt(fuel.Count - 1);
                    cons.RemoveAt(0);
                    fuel.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            if (altitude.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, altitude.Select(a => $"John has reached: Altitude {a}")));

                if (fuel.Any())
                {
                    Console.WriteLine("John failed to reach the top.");
                    Console.WriteLine($"Reached altitudes: {string.Join(", ", altitude)}");
                }
                else
                {
                    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                }
            }
            else
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }
        }
    }
}