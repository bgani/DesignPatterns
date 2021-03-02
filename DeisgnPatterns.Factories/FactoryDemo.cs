using System;
using System.Collections.Generic;
using System.Text;

namespace DeisgnPatterns.Factories
{
    public class FactoryDemo
    {
     
        public static async void TestAsyncFactoryMethod()
        {
            AsyncFactoryMethod afm = await AsyncFactoryMethod.CreateAsync();
        }
         
        public static void TestFactoryMethodProblem()
        {
            // the constructor names are not descriptive
            var polar = new PointWithProblem(1.0, Math.PI / 2, CoordinateSystem.Polar);
            Console.WriteLine(polar);

            var cartesian = new PointWithProblem(1.0, Math.PI / 2, CoordinateSystem.Cartesian);
            Console.WriteLine(cartesian);
        }

        public static void TestFactoryMethod()
        {
            // factory method gives unique and descriptive constructor name
            var point = Point.NewCartesianPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}
