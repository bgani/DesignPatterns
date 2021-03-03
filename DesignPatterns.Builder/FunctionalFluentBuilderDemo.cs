using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DesignPatterns.Builder
{

    public class Employee
    {
        public string Name, Position;


        public override string ToString()
        {
            return $"{nameof(Name)} : {Name}, {nameof(Position)}: {Position}";
        }
    }

    // TSubject - type of subject we are building
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf: FunctionalBuilder<TSubject, TSelf>
        where TSubject: new() // can have a parameter-less constructor
    {
        private readonly List<Func<Employee, Employee>> actions
            = new List<Func<Employee, Employee>>();

        public TSelf Do(Action<Employee> action) => AddAction(action);

        public Employee Build() => actions.Aggregate(new Employee(), (e, f) => f(e));

        private TSelf AddAction(Action<Employee> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf) this;
        }
    }

    public sealed class EmployeeBuilder: 
        FunctionalBuilder<Employee, EmployeeBuilder>
    {
        public EmployeeBuilder Called(string name) => Do(p => p.Name = name);
    }


    // open-closed principle doesn't allow us to modify EmployeeBuilder class, instead we can extend it
    // sealed modifier in EmployeeBuilder illustrates that we can't inherit from the class
    public static class EmployeeBuilderExtensions
    {
        public static EmployeeBuilder WorksAs(this EmployeeBuilder builder, string position) =>
            builder.Do(p => p.Position = position);
    }


    public class FunctionalFluentBuilderDemo
    {
        public static void Use()
        {
            var employee = new EmployeeBuilder()
                .Called("Gani")
                .WorksAs("Developer")
                .Build();

            Console.WriteLine(employee);

        }
    }
}
