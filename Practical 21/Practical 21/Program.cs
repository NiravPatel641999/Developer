using System;
using System.Collections.Generic;
using System.Linq;

namespace Practical_21
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Remove Duplicate Elements using HashSet
                string[] arr = { "A", "B", "C", "D", "A", "E", "C", "E", "E" };
                var unique = new HashSet<string>(arr);
                string[] distinctarray = unique.ToArray();//Remove duplicate elements
                Console.WriteLine(string.Join(",",distinctarray));//print only distinct elements

                // Remove duplicate elements using List
                List<string> arr2 = new List<string>();
                arr2.Add("A");
                arr2.Add("B");
                arr2.Add("C");
                arr2.Add("D");
                arr2.Add("A");
                arr2.Add("E");
                arr2.Add("C");
                arr2.Add("E");
                arr2.Add("E");
                Console.Write("List Before Removing Duplicates:");
                foreach (string ch in arr2)
                {
                    Console.Write(ch + " ");
                }
                Console.WriteLine();
                List<string> distinct = arr2.Distinct().ToList(); 
                Console.Write("List After Removing Duplicate Elements:");
                foreach(string ch in distinct)
                {
                    Console.Write(ch + " ");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
        }
    }
}
