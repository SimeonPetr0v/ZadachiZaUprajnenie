namespace ManOfWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> wShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            
            int maxHealth = int.Parse(Console.ReadLine());
            string comm = Console.ReadLine();
            
            while (comm != "Retire")
            {
                string[] command = comm.Split().ToArray();
                switch (command[0])
                {
                    case "Fire":
                        int fire = int.Parse(command[1]);
                        int damage = int.Parse(command[2]);

                        if (fire >= 0 && fire < wShip.Count)
                        {
                            wShip[fire] -= damage;

                            if (wShip[fire] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;

                    case "Defend":
                        int defendS = int.Parse(command[1]);
                        int defendE = int.Parse(command[2]);
                        
                        damage = int.Parse(command[3]);

                        if (defendS >= 0 && defendS < pShip.Count &&
                            defendE >= 0 && defendE < pShip.Count &&
                            defendS <= defendE)
                        {
                            for (int i = defendS; i <= defendE; i++)
                            {
                                pShip[i] -= damage;

                                if (pShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;

                    case "Repair":
                        int repair = int.Parse(command[1]);
                        int health = int.Parse(command[2]);

                        if (repair >= 0 && repair < pShip.Count)
                        {
                            pShip[repair] = Math.Min(pShip[repair] + health, maxHealth);
                        }
                        break;

                    case "Status":
                        int count = pShip.Count(s => s < maxHealth * 0.2);
                        Console.WriteLine($"{count} sections need repair.");
                        break;

                }
                comm = Console.ReadLine();
            }
            Console.WriteLine($"Pirate ship status: {pShip.Sum()}");
            Console.WriteLine($"Warship status: {wShip.Sum()}");
        }
    }
}