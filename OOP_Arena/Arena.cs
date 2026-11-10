using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        
        private List<Bojovnik> bojovnici = new List<Bojovnik>();
        private Kostka kostka;

        public Arena(List<Bojovnik> bojovnici, Kostka kostka)
        {
            this.bojovnici = bojovnici;
            this.kostka = kostka;
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví bojovníků: \n");
            foreach (Bojovnik bojovnik in bojovnici)
            {
                Console.WriteLine("{0} {1}", bojovnik, bojovnik.VratGrafickyPekneZivoty());
            }
        }

        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        public void SpustZapas()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");
            Console.WriteLine("Vítejte v aréně!");
            Console.Write("Dnes se utkají ");
            
            
            Console.Write(string.Join(", ", bojovnici));
            
            Console.Write("! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();
            Kostka mince = new Kostka(2);
            int kdoZacne = mince.HodSebou();
            // cyklus s bojem
            while (bojovnik1.JeNazivu() && bojovnik2.JeNazivu())
            {
                bojovnik1.Utoc(bojovnik2);
                VykresliArenu();
                VypisZpravu(bojovnik1.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik2.Zprava); // zpráva o obraně
                
                bojovnik2.Utoc(bojovnik1);
                VykresliArenu();
                VypisZpravu(bojovnik2.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik1.Zprava); // zpráva o obraně
                Console.WriteLine();
            }
        }
    }


}
