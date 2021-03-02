using System;

/// <summary>
/// A Factory is a component responsible solely for the wholesale (not piecewise) creation of objects
/// Motivation: 
/// Object creation logic becomes too convoluted
/// Constructor is not descriptive, 
///   - name mandated by name of containing type
///   - cannot overload with same sets of arguments with different names
///   - can turn into 'optional parameter hell'
/// Object creation (non-piecewise, unlike Builder) can be outsourced to
///   - a seperate function (Factory Method)
///   - that may exist in a seperate class (Factory)
///   - can create hierarchy of factories with Abstract Factory
/// </summary>
namespace DeisgnPatterns.Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
