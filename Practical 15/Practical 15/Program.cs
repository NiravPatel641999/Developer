using System;

namespace Practical_15
{
    class Number
    {
        public virtual void add(int a,int b)                     // Runtime Polymorphism derived Class method
        {
            int c = a + b;
            Console.WriteLine("Addition of A + B:"+c);
        }
        public void add(int a,int b, int c)            // Compile time Polymorphism for same class method 
        {
            int d = a + b + c;
            Console.WriteLine("Addition of A + B + C:" + d);
        }
        public  void add(double a,double b,double c)       // Compile time Polymorphism
        {
            double d = a + b + c;
            Console.WriteLine("Addition of A + B + C:" + d);
        }
    }
    class Digit : Number
    {
        public override void add(int a, int b)              // Runtime Polymorphism
        {
            int c = a + b;
            Console.WriteLine("Addition of A + B:" + c);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Number obj;
            obj = new Number();
            obj.add(10, 20);
            obj.add(10, 20, 30);
            obj.add(10.50, 20.50, 30.00);
            // create object for derived class
            obj = new Digit();
            obj.add(100, 200);
        }
    }
}
