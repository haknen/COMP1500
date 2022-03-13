using System;
using System.Text;

namespace Lab8
{
    public static class Lab8
    {
        public static string PrettifyList(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            StringBuilder builder = new StringBuilder(s.Length * 2);

            bool isLevel2Able = true;
            bool isLevel3Able = false;
            int countLv1 = 1;
            int countLv2 = 0;

            builder.Append("1) ");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '/' && isLevel3Able)
                {
                    builder.Append("\n        - ");
                }

                else if (s[i] == '_' && isLevel2Able)
                {
                    isLevel3Able = true;
                    builder.Append("\n    ");
                    for (int j = 0; j < countLv2 / 26 + 1; j++)
                    {
                        builder.Append((char)(countLv2 % 26 + 97));
                    }
                    builder.Append(") ");
                    countLv2++;
                }

                else if (s[i] == '|')
                {
                    isLevel2Able = true;
                    isLevel3Able = false;
                    countLv1++;
                    builder.Append("\n" + countLv1);
                    builder.Append(") ");
                    countLv2 = 0;
                }

                else
                {
                    builder.Append(s[i]);
                }
            }
            builder.Append("\n");

            return builder.ToString();
        }
    }
}
