using System;

namespace Practical_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your Age:");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age >= 18)
            {
                Console.WriteLine("Your age is 18 or Higher than 18");
            }
            else
            {
                Console.WriteLine("You are below the 18.");
            }

        }
    }
}
