using System;

namespace Practical_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Month Number:");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("Current Month is: January");
                    break;

                case 2:
                    Console.WriteLine("Current Month is: February");
                    break;

                case 3:
                    Console.WriteLine("Current Month is: March");
                    break;

                case 4:
                    Console.WriteLine("Current Month is: April");
                    break;

                case 5:
                    Console.WriteLine("Current Month is: May");
                    break;

                case 6:
                    Console.WriteLine("Current Month is: June");
                    break;

                case 7:
                    Console.WriteLine("Current Month is: July");
                    break;

                case 8:
                    Console.WriteLine("Current Month is: August");
                    break;

                case 9:
                    Console.WriteLine("Current Month is: September");
                    break;

                case 10:
                    Console.WriteLine("Current Month is: October");
                    break;

                case 11:
                    Console.WriteLine("Current Month is: November");
                    break;

                case 12:
                    Console.WriteLine("Current Month is: December");
                    break;
            }
        }
    }
}
