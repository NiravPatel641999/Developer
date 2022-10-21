using System;

namespace Practical_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "C# Programming";
            Console.WriteLine("Length of String is:"+str.Length);//Count length of string
            Console.WriteLine("Substring from 3 to 5 character:" + str.Substring(3,5));// print 5 character from 3rd position(statrt from 0) 
            Console.WriteLine("Convert string in Uppercase:" + str.ToUpper());
            Console.WriteLine("Convert string in Lowercase:" + str.ToLower());
            string str1 = "Hello World";
            string rmv = str1.Remove(3);
            Console.WriteLine("Remove character after 3rd character:" + rmv);
            Console.WriteLine("Remove specific length of character:" + str1.Remove(3, 5));// remove 5 characters after 3rd number
            string str2 = string.Concat(str, str1);
            Console.WriteLine("Concate the both string:" + str2);
            Console.WriteLine("Concate the word in string:" + string.Concat(str, " World"));
            Console.WriteLine("Compare the both string:" + string.Equals(str, str1));
            string date = string.Format("Today's date is:{0}",DateTime.Now);
            Console.WriteLine(date);
        }
    }
}
