using System;

namespace Lab10
{
    public class Rectangle
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }

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
        private double mThirdSide;
        public uint Width { get; private set; }
        public uint Height { get; private set; }

        public RightTriangle(uint width, uint height)
        {
            Width = width;
            Height = height;
            mThirdSide = Math.Sqrt(Math.Pow((double)width, 2) + Math.Pow((double)height, 2));
        }

        public double GetPerimeter()
        {
            return Math.Round((double)Width + (double)Height + mThirdSide, 3);
        }

        public double GetArea()
        {
            return Math.Round((double)Width * (double)Height / 2, 3);
        }
    }

    public class Circle
    {
        public uint Radius { get; private set; }
        public uint Diameter { get; private set; }


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