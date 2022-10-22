using System;

namespace Practical_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var index = Array.IndexOf(arr, 4);
            Console.WriteLine("Array index of 4 is:" + index);
            Console.WriteLine("Array index of 2:"+Array.FindIndex(arr, item => item == 2));
        }
    }
}
