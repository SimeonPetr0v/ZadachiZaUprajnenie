namespace BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stud = int.Parse(Console.ReadLine());
            int lect = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            
            double tBonus = 0;
            double attend = 0;
            double mAttend = 0;
            double mBonus = 0;
            
            for (int i = 0; i < stud; i++)
            {
                attend = double.Parse(Console.ReadLine());
                
                if (attend > mAttend)
                {
                    tBonus = (attend / lect) * (5 + bonus);
                    mBonus = Math.Ceiling(tBonus);
                    mAttend = attend;
                }
            }
           
            Console.WriteLine($"Max Bonus: {mBonus}.");
            Console.WriteLine($"The student has attended {mAttend} lectures.");

        }
    }
}