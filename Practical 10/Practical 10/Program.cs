using System;

namespace Practical_10
{
    class Program
    {
        public int id, age;
        public string name;

        Program(int id,string name,int age)
        {
            this.id = id;//here this keywor diffrentiate method parameter and class field name
            this.name = name;
            this.age = age;
            this.hello("Hello");// here this keyword call the hello method
            Console.WriteLine("Id:"+id +" " + "Name:" + name + " " +"Age:"+ age);
        }
        void hello(string name)
        {
            Console.WriteLine("Name is:" + name);
        }
        static void Main(string[] args)
        {
            Program p = new Program(10, "Ravi", 20);
        }
    }
}
