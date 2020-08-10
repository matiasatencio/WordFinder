using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordFinderChallenge
{
    public class Helpers
    {
        private static readonly Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = Constants.C_ALPHABET;
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<string> GenerateRandomMatrix()
        {
            List<string> matrix = new List<string>();

            for (int i = 0; i < Constants.C_MATRIX_WIDTH; i++)
            {
                string str = string.Empty;
                for (int j = 0; j < Constants.C_MATRIX_HEIGHT; j++)
                {
                    str += RandomString(1);
                }
                matrix.Add(str);
            }

            return matrix;
        }
        
        public static void DrawResults(IEnumerable<string> result)
        {
            int i = 1;
            if (result.Any())
            {
                Console.WriteLine(Constants.C_MSG_TOP10);
                Console.WriteLine(string.Empty);

                foreach (string s in result)
                {
                    Console.WriteLine($"{i}: {s}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine(Constants.C_TOP_WORDS);
            }
        }
    }
}
