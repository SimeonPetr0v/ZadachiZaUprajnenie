namespace Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> armor = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            List<int> striking = Console.ReadLine().Split(',').Select(int.Parse).ToList();

            int killedM = 0;

            while (armor.Any() && striking.Any())
            {
                int monsterArmor = armor.First();
                int cStrike = striking.Last();

                if (cStrike >= monsterArmor)
                {
                    armor.RemoveAt(0);
                    striking.RemoveAt(striking.Count - 1);

                    int remainingImpact = cStrike - monsterArmor;

                    if (striking.Any())
                    {
                        striking[striking.Count - 1] += remainingImpact;
                    }
                }
                else
                {
                    armor[0] -= cStrike;
                    striking.RemoveAt(striking.Count - 1);
                    armor.Add(armor[0]);
                    armor.RemoveAt(0);
                }

                killedM++;
            }

            if (armor.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
                Console.WriteLine($"Total monsters killed: {killedM - 1}");
            }
            else
            {
                Console.WriteLine("All monsters have been killed!");
                Console.WriteLine($"Total monsters killed: {killedM}");
            }
        }
    }
}
