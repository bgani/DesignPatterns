using System;
using System.Collections.Generic;
using System.Text;

namespace DeisgnPatterns.Factories
{

    /// <summary>
    /// the Factory Method solution for different coordinate systems
    /// the name of factory methods are not directly tied the name of the class
    /// the advantages of factory method:
    /// 1. we get to have an overload with the same sets of arguments x, y but with different discriptive names
    /// 2. names of the factory method are unique, name of method suggests what kind of object we are creating
    /// 3. 1 and 2 improves API
    /// </summary>
    public class Point
    {
        // factory method #1 cartesian
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        // factory method #2 polar
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
