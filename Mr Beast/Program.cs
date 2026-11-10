using System.Data;
using System.Diagnostics;
using System.Numerics;

namespace Mr_Beast
{
    internal class Program
    {
        public static Vector BeastPosition = new Vector(0, 0);
        public static int UpdateNumber = 0;
        public static int UpdateEnd = 20;

        static void Main(string[] args)
        {
            char[,] supermarket = MakeSupermarket();
            char[] MrBeastRotations = { '^', '<', 'v', '>' };
            for (int row = 0; row < supermarket.GetLength(0); row++)
            {
                for (int col = 0; col < supermarket.GetLength(1); col++)
                {
                    if (MrBeastRotations.Contains(supermarket[row, col]))
                    {
                        BeastPosition.X = row;
                        BeastPosition.Y = col;
                        break;
                    }
                }
            }

            while (UpdateNumber < UpdateEnd)
            {
                UpdateSupermarket(supermarket);
            }


        }
        static char[,] MakeSupermarket()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            char[,] supermarket = new char[y, x];
            for (int i = 0; i < y; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < x; j++)
                {
                    supermarket[i, j] = line[j];
                }
            }
            return supermarket;
        }
        static void DisplaySupermarket(char[,] supermarket)
        {
            Console.WriteLine($"\n{UpdateNumber + 1}. krok");
            for (int i = 0; i < supermarket.GetLength(0); i++)
            {
                string completedLine = "";
                for (int j = 0; j < supermarket.GetLength(1); j++)
                {

                    completedLine += supermarket[i, j];

                }
                Console.WriteLine(completedLine);
            }
        }
        static int[] MoveBeast(char front, char right)
        {
            int move = 0;
            int rotate = 0;
            if (right != '.' && front == '.')
            {
                move += 1;
                return [rotate, move];
            }
            else if (right == '.')
            {
                rotate += -1;
                move += 1;
                return [rotate, move];

            }
            else if (front != '.')
            {
                rotate += 1;
                return [rotate, move];
            }
            else
            {
                return null;
            }
        }
        static void UpdateSupermarket(char[,] supermarket)
        {
            char front = ' ';
            char right = ' ';
            char beastCharacter = supermarket[BeastPosition.X, BeastPosition.Y];
            int[] RotateMove = { 0, 0 };
            Vector[] rightVectors = { new Vector(0, 1), new Vector(-1, 0), new Vector(0, -1), new Vector(1, 0) };
            Vector[] frontVectors = { new Vector(-1, 0), new Vector(0, -1), new Vector(1, 0), new Vector(0, 1) };
            char[] MrBeastRotations = { '^', '<', 'v', '>' };
            int rotationIndex = Array.IndexOf(MrBeastRotations, beastCharacter);

            front = supermarket[BeastPosition.X + frontVectors[rotationIndex].X, BeastPosition.Y + frontVectors[rotationIndex].Y];
            right = supermarket[BeastPosition.X + rightVectors[rotationIndex].X, BeastPosition.Y + rightVectors[rotationIndex].Y];

            RotateMove = MoveBeast(front, right);

            int newRotationIndex = (rotationIndex + RotateMove[0] + 4) % 4;
            supermarket[BeastPosition.X, BeastPosition.Y] = MrBeastRotations[newRotationIndex];
            rotationIndex = newRotationIndex;
            if (RotateMove[0] != 0)
            {
                DisplaySupermarket(supermarket);
                UpdateNumber += 1;


            }
            RotateMove[0] = 0;

            if (RotateMove[1] == 1)
            {
                int newPosX = BeastPosition.X + frontVectors[rotationIndex].X * RotateMove[1];
                int newPosY = BeastPosition.Y + frontVectors[rotationIndex].Y * RotateMove[1];
                supermarket[newPosX, newPosY] = supermarket[BeastPosition.X, BeastPosition.Y];
                supermarket[BeastPosition.X, BeastPosition.Y] = '.';
                BeastPosition.X = newPosX;
                BeastPosition.Y = newPosY;

            }
            if (RotateMove[1] != 0)
            {
                DisplaySupermarket(supermarket);
                UpdateNumber += 1;
            }
            RotateMove[1] = 0;


        }
    }
    class Vector
    {
        public int X;
        public int Y;
        public Vector(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}