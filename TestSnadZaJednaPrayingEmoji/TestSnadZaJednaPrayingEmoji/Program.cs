using System.Numerics;

namespace TestSnadZaJednaPrayingEmoji
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string end = "Nekonči dvojče <//3";
            while (end != "q")
            {
                Console.WriteLine("Napiš iksovou souřadnici bodu A");
                int CordAx = int.Parse(Console.ReadLine());
                Console.WriteLine("Napiš ipsilonovou souřadnici bodu A");
                int CordAy = int.Parse(Console.ReadLine());
                Console.WriteLine("Napiš iksovou souřadnici bodu B");
                int CordBx = int.Parse(Console.ReadLine());
                Console.WriteLine("Napiš ipsilonovou souřadnici bodu B");
                int CordBy = int.Parse(Console.ReadLine());
                Console.WriteLine("Napiš iksovou souřadnici bodu C");
                int CordCx = int.Parse(Console.ReadLine());
                Console.WriteLine("Napiš ipsilonovou souřadnici bodu C");
                int CordCy = int.Parse(Console.ReadLine());
                double AB = Distance(CordAx, CordAy, CordBx, CordBy); //délka strany AB
                double AC = Distance(CordAx, CordAy, CordCx, CordCy); //délka strany AC
                double BC = Distance(CordBx, CordBy, CordCx, CordCy); //délka strany BC
                Console.WriteLine($"Strana a je vlastně {AB} a strana b jakoby {AC} no a nakonec strana c {BC}");

                if (AB + AC > BC && AB + BC > AC && AC + BC > AB) // kontrolujeme trojúhelníkovou nerovnost
                {
                    Console.WriteLine("Ngl tyhle 3 body lowk tvořej trojúhelník gng");
                }
                else
                {
                    Console.WriteLine("Ngl tyhle body lowk nejsou trojúhelník gng, sorry vro");
                }
                Console.WriteLine("Napiš q pokud chceš ukončit program dvojče");
                end = Console.ReadLine();
            }
        }
        static double Distance(int x1, int y1, int x2, int y2) 
        { 
            double distance = Math.Sqrt(Math.Pow(x2 -x1, 2) + Math.Pow(y2 - y1, 2)); //vdálenost dvou bodů je velikost jejich směrového vektoru velikost (2, 1) je sqrt(2^2 + 1^2) neboli odmocnina z 5
            return distance;
        }
    }
    
}