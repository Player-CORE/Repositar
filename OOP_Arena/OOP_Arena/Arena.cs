using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        private List<Bojovnik> _bojovnici = new List<Bojovnik>();
        private Kostka _kostka;

        public Arena(List<Bojovnik> bojovnici, Kostka kostka)
        {
            this._bojovnici = bojovnici;
            this._kostka = kostka;
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví bojovníků: \n");
            for (int i = 0; i < _bojovnici.Count; i++)
            {
                if (_bojovnici[i] is Carodej carodej)
                {
                    Console.WriteLine("{0} {1}", _bojovnici[i], carodej.VratGrafickyPekneStaty());    
                }
                else
                {
                    Console.WriteLine("{0} {1}", _bojovnici[i], _bojovnici[i].VratGrafickyPekneZivoty());
                }
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
            Console.WriteLine($"Dnes se utká {_bojovnici.Count} bojovníků či čarodějů! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();
            // cyklus s bojem
            while (true)
            {
                List<Bojovnik> ziviBojovnici = new List<Bojovnik>();
                for (int i = 0; i < _bojovnici.Count; i++)
                {
                    if (_bojovnici[i].JeNazivu())
                    {
                        ziviBojovnici.Add(_bojovnici[i]);
                    }
                }
                if (ziviBojovnici.Count < 2)
                {
                    break;
                }

                Kostka kostkaUtok = new Kostka(ziviBojovnici.Count);
                Bojovnik utocnik = ziviBojovnici[kostkaUtok.HodSebou() - 1];
                int kdoDruhy = kostkaUtok.HodSebou();
                
                List<Bojovnik> mozniObranci = new List<Bojovnik>();
                for (int i = 0; i < ziviBojovnici.Count; i++)
                {
                    if (ziviBojovnici[i] != utocnik)
                    {
                        mozniObranci.Add(ziviBojovnici[i]);
                    }
                }
                Kostka kostkaObrana = new Kostka(mozniObranci.Count);
                Bojovnik obrance = mozniObranci[kostkaObrana.HodSebou() - 1];
                
                utocnik.Utoc(obrance);
                VykresliArenu();
                VypisZpravu(utocnik.Zprava); // zpráva o útoku
                VypisZpravu(obrance.Zprava); // zpráva o obraně
                if (obrance.JeNazivu())
                {
                    obrance.Utoc(utocnik);
                    VykresliArenu();
                    VypisZpravu(obrance.Zprava); // zpráva o útoku
                    VypisZpravu(utocnik.Zprava); // zpráva o obraně
                }
                Console.WriteLine();
            }
        }
    }
}
