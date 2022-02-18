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

                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (i + height - 1 >= j && i + j >= height - 1)
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
            int shapeHeight = canvas.GetLength(0) - 4;
            int shapeWidth = canvas.GetLength(1) - 4;

            if (canvas.GetLength(0) == 0 || canvas.GetLength(1) == 0)
            {
                return false;
            }

            switch (shape)
            {
                case EShape.Rectangle:
                    for (int i = 0; i < shapeHeight; i++)
                    {
                        for (int j = 0; j < shapeWidth; j++)
                        {
                            if (canvas[i + 2, j + 2] != '*')
                            {
                                return false;
                            }
                        }
                    }
                    return true;

                case EShape.IsoscelesRightTriangle:
                    for (int i = 0; i < shapeHeight; i++)
                    {
                        for (int j = 0; j < shapeWidth; j++)
                        {
                            if ((i >= j && canvas[i + 2, j + 2] != '*') ||
                                (i < j && canvas[i + 2, j + 2] != ' '))
                            {
                                return false;
                            }
                        }
                    }
                    return true;

                case EShape.IsoscelesTriangle:
                    if (shapeWidth != shapeHeight * 2 - 1)
                    {
                        return false;
                    }

                    for (int i = 0; i < shapeHeight; i++)
                    {
                        for (int j = 0; j < shapeWidth; j++)
                        {
                            if (((i + shapeHeight - 1 >= j && i + j >= shapeHeight - 1 && canvas[i + 2, j + 2] != '*')) ||
                                ((i + shapeHeight - 1 < j && i + j < shapeHeight - 1 && canvas[i + 2, j + 2] != ' ')))
                            {
                                return false;
                            }
                        }
                    }
                    return true;

                case EShape.Circle:
                    int r = shapeHeight / 2;
                    for (int i = 0; i < shapeHeight; i++)
                    {
                        for (int j = 0; j < shapeWidth; j++)
                        {
                            if (((Math.Pow(r - i, 2) + Math.Pow(r - j, 2) <= Math.Pow(r, 2) && canvas[i + 2, j + 2] != '*')) || 
                                ((Math.Pow(r - i, 2) + Math.Pow(r - j, 2) > Math.Pow(r, 2) && canvas[i + 2, j + 2] != ' ')))
                            {
                                return false;
                            }
                        }
                    }
                    return true;

                default:
                    return false;

            }
        }
    }
}
