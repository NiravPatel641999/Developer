using System;

namespace Practical_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number:");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 1;
            while (i <= n)
            {
                Console.WriteLine(i);
                i++;
            }

            Console.Write("Enter Number:");
            int no = Convert.ToInt32(Console.ReadLine());
            int j = 1;
            do
            {
                Console.WriteLine(j);
                j++;
            } while (j <= no);
        }
    }
}
