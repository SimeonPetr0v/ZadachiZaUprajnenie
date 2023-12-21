namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();

            string comm;
            while ((comm = Console.ReadLine()) != "Yohoho!")
            {
                string[] token = comm.Split();
                string action = token[0];

                switch (action)
                {
                    case "Loot":
                        for (int i = 1; i < token.Length; i++)
                        {
                            string item = token[i];
                            if (!chest.Contains(item))
                            {
                                chest.Insert(0, item);
                            }
                        }
                        break;

                    case "Drop":
                        int index = int.Parse(token[1]);
                        if (index >= 0 && index < chest.Count)
                        {
                            string drop = chest[index];
                            chest.RemoveAt(index);
                            chest.Add(drop);
                        }
                        break;

                    case "Steal":
                        int count = Math.Min(int.Parse(token[1]), chest.Count);
                        List<string> stolen = chest.TakeLast(count).ToList();
                        chest.RemoveRange(chest.Count - count, count);
                        Console.WriteLine(string.Join(", ", stolen));
                        break;
                }
            }

            double average = chest.Sum(item => item.Length) / (double)chest.Count;

            if (chest.Count > 0)
            {
                Console.WriteLine($"Average treasure gain: {average:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}