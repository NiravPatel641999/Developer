using System;

namespace Practical_14
{
    class A
    {
        public int a = 10;
        public int b = 20;
        public void addition()
        {
            Console.WriteLine("Addition of A+B:" + (a + b));
        }
    }
    class B : A         // single level inheritance
    {
        public int c = 100;
        public int d = 50;
        public void subtraction()
        {
            Console.WriteLine("Subtraction of B-A:" + (b - a));
        }
    }
    class C : B         // Multi Level inheritance  //Hierarchical      //Hybrid inheritance
    {
        public void multiplication()
        {
            Console.WriteLine("Multiplication of A*B:" + (a * b));
            Console.WriteLine("Value of C:" + c);
        }
    }
    class D : B         // Hierarchical inheritance         // Hybrid inheritance
    {
        public void division()
        {
            Console.WriteLine("Division of C/D:" + (c / d));
        }
    }

    interface E
    {
        void add(int a, int b);
    }
    interface F
    {
        void sub(int c, int d);
    }
    class G : E, F
    {
        public void add(int x, int y)
        {
            Console.WriteLine("Addition of X+Y:" + (x + y));
        }
        public void sub(int p, int q)
        {
            Console.WriteLine("Subtraction of P-Q:" + (p - q));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            G g = new G();
            g.add(10, 15);
            g.sub(20, 10);

            D d = new D();
            d.division();
            d.subtraction();
            d.addition();

            C c = new C();
            c.multiplication();
        }
    }
}
