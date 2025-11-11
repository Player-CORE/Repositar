namespace MyLittlePonyFriendshipIsMagic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NumberPeople = Convert.ToInt32(Console.ReadLine());
            bool[,] matrix = new bool[NumberPeople, NumberPeople];
            string inputData = Console.ReadLine();
            string[] dataSplit = inputData.Split(" ");
            for (int i = 0; i < dataSplit.Length; i++) 
            {
                string[] data = dataSplit[i].Split("-");
                matrix[Convert.ToInt32(data[0]), Convert.ToInt32(data[1])] = true;
            }

        }
    }
}
