using System;

namespace Practical_8
{
    class Emi
    {
        public void EmiCalculator(float p, float r, float t)
        {
            r = r / (12 * 100);
            t = t * 12;
            float emi = (p * r * (float)Math.Pow(1 + r, t)) / (float)(Math.Pow(1 + r, t) - 1);
            Console.WriteLine(emi);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            float principal, rate, time;
            Console.Write("Enter Principal Amout:");
            principal = float.Parse(Console.ReadLine());
            Console.Write("Enter interest:");
            rate = float.Parse(Console.ReadLine());
            Console.Write("Enter Payment time period:");
            time = float.Parse(Console.ReadLine());
            Emi e = new Emi();
            e.EmiCalculator(principal, rate, time);
        }
    }
}
