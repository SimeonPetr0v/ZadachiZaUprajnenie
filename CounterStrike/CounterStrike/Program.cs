namespace CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            int won = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End of battle")
                {
                    Console.WriteLine($"Won battles: {won}. Energy left: {energy}");
                    break;
                }

                int dist = int.Parse(input);

                if (energy >= dist)
                {
                    energy -= dist;
                    won++;

                    if (won % 3 == 0)
                    {
                        energy += won;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {won} won battles and {energy} energy");
                    break;
                }
            }
        }
    }
}