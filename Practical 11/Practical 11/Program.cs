using System;

namespace Practical_11
{
    class Student
    {
        public static string department = "Computer Science";//static variable
        public string studentName;
        public static void display()
        {
            Console.WriteLine("Static Display method");
        }
       
    }
    static class Example            //static class contains only static data members
    {
        public static int age = 20;
        static Example()
        {
            Console.WriteLine("Static Constructor");// call Automatically Don't need to create Object
        }
        static void display()
        {

            Console.WriteLine("Static class Display Method");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your Department is:" + Student.department);//Acces static variable value without creating Object
            Student s1 = new Student();
            s1.studentName = "Ram";
            Console.WriteLine("Student Name:" + s1.studentName);//call instance variable
            Console.WriteLine("Department:" + Student.department);//call static variable
            Student s2 = new Student();
            s2.studentName = "Shyam";
            Console.WriteLine("Student Name:" + s2.studentName);//call instance variable
            Console.WriteLine("Department:" + Student.department);
            Student.display();//Call static method without creating object
            Console.WriteLine("Age is:"+Example.age);//Access Static variable
        }
    }
}
