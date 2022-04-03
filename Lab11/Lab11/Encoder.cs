using System;
using System.IO;

namespace Lab11
{
    public static class Encoder
    {
        public static bool TryEncode(Stream input, Stream output)
        {
            if (input == null || input.Length < 1)
            {
                return false;
            }

            using (var reader = new StreamReader(input))
            using (var writer = new BinaryWriter(output))
            {
                byte count = 1;
                int data = reader.Read();
                int compare;

                for (int i = 1; i < input.Length; i++)
                {
                    compare = reader.Read();
                    if (data == compare)
                    {
                        count++;
                        if (count > 254)
                        {
                            writer.Write(count);
                            writer.Write((byte)data);
                            count = 0;
                        }
                    }
                    else
                    {
                        writer.Write(count);
                        writer.Write((byte)data);
                        count = 1;
                    }
                    data = compare;
                }

                writer.Write(count);
                writer.Write((byte)data);
            }

            return true;
        }

        public static bool TryDecode(Stream input, Stream output)
        {
            if (input == null || input.Length < 1)
            {
                return false;
            }

            using (var reader = new BinaryReader(input))
            using (var writer = new StreamWriter(output))
            {
                for (int i = 0; i < input.Length; i += 2)
                {
                    int count = reader.ReadByte();
                    char data = reader.ReadChar();

                    for (int j = 0; j < count; j++)
                    {
                        writer.Write(data);
                    }
                }
            }

            return true;
        }
    }
}
