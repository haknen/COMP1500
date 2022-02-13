using System;

namespace Lab6
{
    public static class Lab6
    {
        public static int[,] Rotate90Degrees(int[,] data)
        {
            int dataWidth = data.GetLength(0);
            int dataLength = data.GetLength(1);
            int[,] result = new int[dataLength, dataWidth];

            for (int i = 0; i < dataWidth; i++)
            {
                for (int j = 0; j < dataLength; j++)
                {
                    result[j, dataWidth - i - 1] = data[i, j];
                }
            }

            return result;
        }

        public static void TransformArray(int[,] data, EMode mode)
        {
            int dataWidth = data.GetLength(0);
            int dataLength = data.GetLength(1);
            int[,] temp = new int[dataWidth, dataLength];

            for (int i = 0; i < dataWidth; i++)
            {
                for (int j = 0; j < dataLength; j++)
                {
                    temp[i, j] = data[i, j];
                }
            }

            switch (mode)
            {
                case EMode.HorizontalMirror:
                    for (int i = 0; i < dataWidth; i++)
                    {
                        for (int j = 0; j < dataLength; j++)
                        {
                            data[i, dataLength - j - 1] = temp[i,j];
                        }
                    }
                    break;

                case EMode.VerticalMirror:
                    for (int i = 0; i < dataWidth; i++)
                    {
                        for (int j = 0; j < dataLength; j++)
                        {
                            data[dataWidth - i - 1, j] = temp[i, j];
                        }
                    }
                    break;

                case EMode.DiagonalShift:
                    for (int i = 0; i < dataWidth; i++)
                    {
                        for (int j = 0; j < dataLength; j++)
                        {
                            if (i + 1 == dataWidth && j + 1 == dataLength)
                            {
                                data[0, 0] = temp[i, j];
                            }
                            else if (i + 1 == dataWidth)
                            {
                                data[0, j + 1] = temp[i, j];
                            }
                            else if (j + 1 == dataLength)
                            {
                                data[i + 1, 0] = temp[i, j];
                            }
                            else
                            {
                                data[i + 1, j + 1] = temp[i, j];
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }
}