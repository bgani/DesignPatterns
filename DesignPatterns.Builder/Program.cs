using System;

namespace DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Without builder");
            BuilderDemo.TestExampleWithoutBuilder();

            Console.WriteLine("\n With builder");
            BuilderDemo.UseBuilder();

            Console.ReadKey();
            Console.WriteLine("the program is done");
            
        }
    }
}
