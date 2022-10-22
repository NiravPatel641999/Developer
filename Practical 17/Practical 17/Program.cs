using System;

namespace Practical_17
{
    class Program
    {
        public void throwexception()
        {
            try
            {
                throw new DivideByZeroException("Invalid Division");    // throw exception
            }
            catch (DivideByZeroException)                   // handle exception 
            {
                Console.WriteLine("Exception");
            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.throwexception();
            int[] arr = { 22, 0, 56, 7 };
            try
            {
                for(int i=0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i] / arr[i + 1]);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
            }
            finally
            {
                
                for (int i=0; i < arr.Length; i++)
                {
                    Console.Write(" "+arr[i]);
                }
            }

        }
    }
}
