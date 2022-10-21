using System;

namespace Practical_12
{
    /* abstract class has abstract and non abstract method
       but if method is abstract then class mustbe declare as abstract
    */
    public abstract class Demo          
    {
        public abstract void demo();// abstract method can not be defined it must be defined in derived class
        public void example()
        {
            Console.WriteLine("Abstract class example method");
        }
    }
    public class Sample:Demo
    {
        public override void demo()
        {
            Console.WriteLine("Override demo method");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sample s = new Sample();
            s.demo();
            s.example();
        }
    }
}
