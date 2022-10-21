using System;

namespace Practical_16
{
    interface vehical
    {
        public void model();    //all methods in interface are abstract So, it just declare but not define
    }
    class Bike : vehical        // class implements interface 
    {
        public void model()
        {
            Console.WriteLine("Model of Bike is Hero Splender+");
        }
        static void Main(string[] args)
        {
            Bike obj = new Bike();
            obj.model();
        }
    }
}
