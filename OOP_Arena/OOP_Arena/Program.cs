using System.Text;

namespace OOP_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Kostka kostka = new Kostka(6);

            Console.WriteLine("Kolik bojovníků se dneska bude prát?");
            int pocetBojvniku = Convert.ToInt32(Console.ReadLine());
            List<Bojovnik> bojovnici = new List<Bojovnik>();
            for (int i = 0; i < pocetBojvniku; i++)
            {
                Console.WriteLine("Kdo se dneska bude prát? (B - bojovnik C - čaroděj potom jméno)");
                string volba = Console.ReadLine();
                if (volba == "B")
                {
                    bojovnici.Add(new Bojovnik(Console.ReadLine(), 100, 20, 10, kostka));
                }
                else if (volba == "C") 
                { 
                    bojovnici.Add(new Carodej(Console.ReadLine(), 75, 15, 5, kostka, 20, 45));
                }              
            }
            Arena arena = new Arena(bojovnici, kostka);

            arena.SpustZapas();
            Console.ReadLine();
        }
    }


}
