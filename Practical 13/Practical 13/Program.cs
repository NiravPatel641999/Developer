using System;

namespace Practical_13
{
    public class EncapsDemo
    {
        //Declare Private Variable and these can only be accessed by public method of class
        private string studentName;
        private int age;
        public string Name
        {
            get
            {
                return studentName;
            }
            set
            {
                studentName = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EncapsDemo ed = new EncapsDemo();
            ed.Name = "Ram";
            ed.Age = 20;
            Console.WriteLine("Name is:" + ed.Name);
            Console.WriteLine("Age is:" + ed.Age);
        }
    }
}
