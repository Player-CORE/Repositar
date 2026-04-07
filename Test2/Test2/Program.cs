using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = Convert.ToInt32(Console.ReadLine());
            bool[,] matrix = new bool[numberOfCities, numberOfCities];
            int start = 0;
            int end = 0;
            while (true)
            {
                string input = Console.ReadLine();
                string[] inputSplit = input.Split(" ");
                if (inputSplit.Length == 1)
                {
                    start = Convert.ToInt32(inputSplit[0]);
                    end = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                else 
                {
                    matrix[Convert.ToInt32(inputSplit[0]) -1, Convert.ToInt32(inputSplit[1]) -1] = true;
                    matrix[Convert.ToInt32(inputSplit[1]) - 1, Convert.ToInt32(inputSplit[0]) - 1] = true;
                }
            }
            string[] output = Search(matrix, start, end, numberOfCities);
            if (output == null) 
            {
                Console.WriteLine("Neexistuje");
            }
            else 
            {
                for (int i = output.Length - 1; i > -1; i--)
                {
                    Console.Write(output[i] + " ");
                }
            }     
        }
        static string[] Search(bool[,] matrix, int start, int end, int numberOfCities)
        {
            Queue<int> queue = new Queue<int>(); 
            queue.Enqueue(start);

            List<int> closed = new List<int>(); //uzavřené vrcholy abychom nejeli donekonečna
            
            int[] parent = new int[numberOfCities]; //odkud jsme do města přišli, odsud bereme input
            for (int i = 0; i < numberOfCities; i++)
            {
                parent[i] = -1; // -1 znamená že do města nevede cesta
            }
            parent[start -1] = 0; // identifikátor startu
            
            while (queue.Count != 0) 
            {
                int current = queue.Peek();
                for (int i = 0; i < numberOfCities; i++)
                {
                    if (matrix[current -1, i] == true && closed.Contains(i+1) == false)
                    {
                        queue.Enqueue(i + 1);
                        if (parent[i] == -1)
                        {
                            parent[i] = current;
                        }
                    }
                }
                closed.Add(queue.Dequeue()); 
            }
            
            //output:
            int curentlyOutputting = end;
            List<string> output = new List<string>();
            output.Add(Convert.ToString(end));
            while (parent[curentlyOutputting -1] != 0) 
            {    
                if (parent[curentlyOutputting - 1] == -1)
                {
                    return null;
                }
                output.Add(Convert.ToString(parent[curentlyOutputting -1]));
                curentlyOutputting = parent[curentlyOutputting -1];
            }
            string[] outputArray = output.ToArray();
            return outputArray;


        }
    }
}
