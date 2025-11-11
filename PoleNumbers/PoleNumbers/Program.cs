namespace PoleNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { 1, 8, 4, -1, 2, -65, 3, 4, 5, 6};

        }
        static int FindMax(int[] ciselnePole) 
        {
            int max = 0;    
            for (int i = 0; i < ciselnePole.Length;)
            {
                if (ciselnePole[i] > max)
                {
                    max = ciselnePole[i];
                    Console.WriteLine(Convert.ToInt32(max));
                    Console.WriteLine(Convert.ToInt32(ciselnePole[i]));
                }
            }
            return max;
        }
    }
}
