using System;

namespace Assignment2
{
    public enum EShape
    {
        Rectangle,
        IsoscelesRightTriangle,
        IsoscelesTriangle,
        Circle
    }

    public static class Canvas
    {
        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            char[,] result = new char[height + 4, width + 4];
            char[,] wrongShape = new char[0, 0];

            if (width != 0 && height != 0)
            {
                for (int i = 0; i < width + 4; i++)
                {
                    result[0, i] = '-';
                    result[1, i] = ' ';
                    result[height + 2, i] = ' ';
                    result[height + 3, i] = '-';
                }

                for (int j = 1; j < height + 3; j++)
                {
                    result[j, 0] = '|';
                    result[j, 1] = ' ';
                    result[j, width + 2] = ' ';
                    result[j, width + 3] = '|';
                }

                switch (shape)
                {
                    case EShape.Rectangle:
                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                result[i + 2, j + 2] = '*';
                            }
                        }

                        return result;

                    case EShape.IsoscelesRightTriangle:
                        if (width != height)
                        {
                            return wrongShape;
                        }

                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (i >= j)
                                {
                                    result[i + 2, j + 2] = '*';
                                }
                                else
                                {
                                    result[i + 2, j + 2] = ' ';
                                }
                            }
                        }

                        return result;

                    case EShape.IsoscelesTriangle:
                        if (width != height * 2 - 1)
                        {
                            return wrongShape;
                        }
                        uint center = width / 2;

                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (i + 4 >= j && i + j >= height - 1)
                                {
                                    result[i + 2, j + 2] = '*';
                                }
                                else
                                {
                                    result[i + 2, j + 2] = ' ';
                                }
                            }
                        }

                        return result;

                    case EShape.Circle:
                        if (width != height || width % 2 == 0)
                        {
                            return wrongShape;
                        }

                        uint r = width / 2;

                        for (int i = 0; i < width; i++)
                        {
                            for (int j = 0; j < height; j++)
                            {
                                if (Math.Pow(r - i, 2) +
                                    Math.Pow(r - j, 2) <= Math.Pow(r, 2))
                                {
                                    result[i + 2, j + 2] = '*';
                                }
                                else
                                {
                                    result[i + 2, j + 2] = ' ';
                                }
                            }
                        }

                        return result;

                    default:
                        break;
                }
            }

            return wrongShape;
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {
            int shapeHeight = canvas.GetLength(0) - 3;
            int shapeWidth = canvas.GetLength(1) - 3;
            uint shapeCheck = 0;

            if (canvas[shapeHeight, shapeWidth] != '*')
            {
                shapeCheck = 3;
            }

            else if (canvas[2, 2] != '*')
            {
                shapeCheck = 2;
            }

            else if (canvas[2, shapeWidth] != '*')
            {
                shapeCheck = 1;
            }

            return (shapeCheck == (int)shape);
        }
    }
}
