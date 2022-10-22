using System;
using System.Collections.Generic;

namespace Practical_19
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> strings = new List<string> { "Hello", "World", "C#" };
                string join = string.Join(",", strings);        // join list elements with comma
                Console.WriteLine(join);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
            
        }
    }
}
