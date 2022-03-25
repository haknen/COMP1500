using System;

namespace Lab10
{
    public class Rectangle
    {
        public uint Width { get; set; }
        public uint Height { get; set; }

        public Rectangle(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public double GetPerimeter()
        {
            return Math.Round(2 * ((double)Width + (double)Height), 3);
        }

        public double GetArea()
        {
            return Math.Round((double)Width * (double)Height, 3);
        }

    }

    public class RightTriangle
    {
        private double thirdSide;
        public uint Width { get; set; }
        public uint Height { get; set; }

        public RightTriangle(uint width, uint height)
        {
            Width = width;
            Height = height;
            thirdSide = Math.Sqrt(Math.Pow((double)width, 2) + Math.Pow((double)height, 2));
        }

        public double GetPerimeter()
        {
            return Math.Round((double)Width + (double)Height + thirdSide, 3);
        }

        public double GetArea()
        {
            return Math.Round((double)Width * (double)Height / 2, 3);
        }
    }

    public class Circle
    {
        public uint Radius { get; set; }
        public uint Diameter { get; set; }


        public Circle(uint radius)
        {
            Radius = radius;
            Diameter = radius * 2;
        }

        public double GetCircumference()
        {
            return Math.Round((double)Diameter * Math.PI, 3);
        }

        public double GetArea()
        {
            return Math.Round((double)Radius * (double)Radius * Math.PI, 3);
        }
    }
}