using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("first 10 fibonacci numbers:");
            int a = 0, b = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a + " ");
                (a, b) = (b, a + b);
            }
            Console.WriteLine("\n");

            
            Console.WriteLine("Even numbers from 2 to 20:");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Multiplication table from 1 to 5:");
            for (int fn = 1; fn <=5; fn++)
            {
                for (int sn = 1; sn <= 5; sn++)
                {
                    Console.Write($"{fn} x {sn} = {fn * sn}" + "   " );
                }
                Console.WriteLine();
            }

            string password = "qwerty";
            string input;
            do
            {
                Console.Write("\nEnter password: ");
                input = Console.ReadLine() ?? "";

                if (input != password)
                {
                    Console.WriteLine("Wrong password! Try again.");
                }

            } while (input != password);

            Console.WriteLine("Password correct! Access granted.");
        }
    }
}
