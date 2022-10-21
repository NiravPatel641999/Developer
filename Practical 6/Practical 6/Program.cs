using System;

namespace Practical_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number:");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=1; i<=n; i++)
            {
                if (i == 7)
                {
                    break;
                }
                Console.WriteLine(i);
            }
            Console.WriteLine("*******");
            for (int i = 1; i <= n; i++)
            {
                if (i == 7)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
