namespace BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dPlunder = int.Parse(Console.ReadLine());
            double exPlunder = double.Parse(Console.ReadLine());
            double tPlunder = 0;

            for (int day = 1; day <= days; day++)
            {
                tPlunder += dPlunder;

                if (day % 3 == 0)
                {
                    tPlunder += 0.5 * dPlunder;
                }

                if (day % 5 == 0)
                {
                    tPlunder -= 0.3 * tPlunder;
                }
            }

            if (tPlunder >= exPlunder)
            {
                Console.WriteLine($"Ahoy! {tPlunder:F2} plunder gained.");
            }
            else
            {
                double perc = (tPlunder / exPlunder) * 100;
                Console.WriteLine($"Collected only {perc:F2}% of the plunder.");
            }
        }
    }
}