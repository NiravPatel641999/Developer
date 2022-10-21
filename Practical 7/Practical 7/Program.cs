using System;

namespace Practical_7
{
    class Program
    {
        Program()
        {
            Console.WriteLine("Default Constructor");
        }
        Program(int a,int b)
        {
            int c = a + b;
            Console.WriteLine("Addition of a + b = "+c);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the value of a:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the value of b:");
            int b = Convert.ToInt32(Console.ReadLine());
            Program p = new Program();
            Program p1 = new Program(a, b);
        }
    }
}
