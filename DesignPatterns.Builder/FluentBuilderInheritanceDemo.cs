using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class Person
    {
        public string Name;
        public string Position;
        public DateTime DateOfBirth;

        // exposing Person's builder
        public class Builder: PersonJobBuilder<Builder>
        {
        }
        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)} : {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build() 
        { 
            return person; 
        }
    }

    public class PersonInfoBuilder<SELF>
        : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }

    // as we inherit builder from other builders, derived line is going to get really long
    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF: PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF) this;
        }
    }
    
    public class FluentBuilderInheritanceDemo
    {
       public static void UseFluentBuilderWithInheritance()
       {
           var person =  Person.New
                .Called("Gani")
                .WorksAsA("developer")
                .Build();
            Console.WriteLine(person);
       }
    }
}
