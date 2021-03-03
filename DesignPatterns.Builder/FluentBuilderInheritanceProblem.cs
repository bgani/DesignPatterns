using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class FluentBuilderInheritanceProblem
    {
        public class Person
        {
            public string Name;
            public string Position;
            public DateTime DateOfBirth;

            public override string ToString()
            {
                return $"{nameof(Name)} : {Name}, {nameof(Position)}: {Position}";
            }
        }

        public class PersonInfoBuilder
        {
            protected Person person = new Person();

            public PersonInfoBuilder Called(string name)
            {
                person.Name = name;
                return this;
            }
        }

        public class PersonJobBuilder : PersonInfoBuilder
        {
            public PersonJobBuilder WorksAsA(string position)
            {
                person.Position = position;
                return this;
            }
        }

        public static void UseBuilderWithInheritance()
        {
            var builder = new PersonJobBuilder();
            // We can not use WorksAsA method becuase when we call the Called() we return a PersonInfoBuilder, and it doesn't know anything about WorksAsA
            // WorksAsA() is not in a PersonInfoBuilder's inheritance hierarchy
            // We are not allowed to use containing type as a returning type, if someone calls Called() it will degrade Builder from a PersonJobBuilder to PersonInfoBuilder which is not good 
            // builder.Called("Joe").WorksAsA("programmer");
        }
    }
}
