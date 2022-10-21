using System;

namespace Practical_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number:");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Enter Number:");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int p = 0; p <= num; p++)
            {
                for (int q = 1; q <= num - p; q++)
                {
                    Console.Write(" ");
                }
                for (int r = 1; r <= 2 * p - 1; r++)
                {
                    Console.Write("*");

                }
                Console.WriteLine();
            }
        }
    }
}
