using System;
using System.Collections.Generic;
using System.Text;

namespace DeisgnPatterns.Factories
{

    /// <summary>
    /// <param name="a">x if cartesian, rho if polar</param>
    /// <param name="b"></param>
    /// <param name="system"></param>
    /// </summary>
    public class PointWithProblem
    {
        private double x, y;

        /// Cuntructor Initializes a point from Either cartesian or polar
        public PointWithProblem(double a, double b,
            CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
