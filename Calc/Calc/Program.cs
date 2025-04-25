using System;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 1
            int[] fibonacci = new int[8];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < fibonacci.Length; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
            Console.WriteLine("Fibonacci numbers:");
            foreach (int num in fibonacci)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // task 2
            string[] months = {
                "January", "February", "March", "April",
                "May", "June", "July", "August",
                "September", "October", "November", "December"
            };
            Console.WriteLine("\nMonths:");
            foreach (string month in months)
            {
                Console.WriteLine(month);
            }

            // task 3
            int[,] matrix = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    matrix[row, col] = (int)Math.Pow(col + 2, row + 1);
                }
            }
            Console.WriteLine("\nMatrix 3x3:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // task 4
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new double[] { Math.E, Math.PI };
            jaggedArray[2] = new double[] {
                Math.Log10(1),
                Math.Log10(10),
                Math.Log10(100),
                Math.Log10(1000)
            };
            Console.WriteLine("\nJagged array:");
            foreach (var subArray in jaggedArray)
            {
                for (int i = 0; i < subArray.Length; i++)
                {
                    Console.Write(subArray[i]);
                    if (i < subArray.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine(); 
            }

            // task 5-6
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            // task 5
            Array.Copy(array, array2, 3);
            Console.WriteLine("\nAfter copying first 3 elements:");
            Console.WriteLine("array2: " + string.Join(", ", array2));

            // task 6
            Array.Resize(ref array, array.Length * 2);
            Console.WriteLine("\nAfter resizing first array:");
            Console.WriteLine("array: " + string.Join(", ", array));
        }
    }
}