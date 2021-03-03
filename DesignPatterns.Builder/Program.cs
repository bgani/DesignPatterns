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

            Console.WriteLine("\n Fluent builder");
            BuilderDemo.UseFluentBuilder();

            Console.WriteLine("\n Builder with Inheritance");
            FluentBuilderInheritanceDemo.UseFluentBuilderWithInheritance();

            Console.WriteLine("\n Functional Fluent Builder");
            FunctionalFluentBuilderDemo.Use();

            Console.ReadKey();
            Console.WriteLine("the program is done");
            
        }
    }
}
