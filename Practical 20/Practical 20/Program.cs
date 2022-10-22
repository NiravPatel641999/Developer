using System;
using System.Collections.Generic;

namespace Practical_20
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();     // creating Dictionary 
                dict.Add("Name", "Nirav"); //Adding key / value pair using Add method
                dict.Add("Education", "B.E Computer");
                foreach(KeyValuePair<string,string> list in dict)
                {
                    Console.WriteLine("Key:{0}, value:{1}", list.Key, list.Value);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message); // if Dictionary has duplicate key  then it throws Exception
            }
        }
    }
}
