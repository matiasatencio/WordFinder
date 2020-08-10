using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WordFinderChallenge
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts the initial IEnumerable of strings into a customizable bi-dimensional char matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static char[,] ToCharMatrix(this IEnumerable<string> matrix, int width, int height)
        {
            char[,] newMatrix = new char[width, height];
            int i = 0, j = 0;

            //Validates matrix width to avoid IndexOutOfRangeException
            while (i < matrix.Count() && i < newMatrix.GetLength(0))
            {
                char[] row = matrix.ElementAt(i).ToCharArray();

                //Validates matrix height to avoid IndexOutOfRangeException
                while (j < matrix.ElementAt(i).Length && j < newMatrix.GetLength(1) && j < matrix.ElementAt(i).Length)
                {
                    newMatrix[i, j] = row[j];
                    j++;
                }
                j = 0;
                i++;
            }

            return newMatrix;
        }
    }
}
