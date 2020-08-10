using System.Collections.Generic;
using System.Linq;
using WordFinderChallenge.Search;

namespace WordFinderChallenge
{
    public class WordFinder
    {
        public char[,] Matrix { get; set; }

        public WordFinder(IEnumerable<string> matrix)
        {
            this.Matrix = matrix.ToCharMatrix(Constants.C_MATRIX_WIDTH, Constants.C_MATRIX_HEIGHT);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            List<string> foundWords = new List<string>();

            /* I considered using recursion in order to improve the performance, but after
             * some research I figured out that it's way slower in C#. */
            foreach (string word in wordstream)
            {
                SearchWord(foundWords, new HorizontalSearch(word)); //Searches horizontally
                SearchWord(foundWords, new VerticalSearch(word)); //Searches vertically
            }

            return foundWords.GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .SelectMany(g => g)
                .Distinct()
                .Take(Constants.C_TOP_WORDS)
                .ToList();
        }

        public void SearchWord(List<string> foundWords, BaseSearch baseSearch)
        {
            /*I subtract the word length to the total length because it wouldn't make sense 
                * the remaining coordinates when the word doesn't fit there */
            for (int i = 0; i < this.Matrix.GetLength(baseSearch.FirstDimension) - baseSearch.Word.Length + 1; i++)
            {
                for (int j = 0; j < this.Matrix.GetLength(baseSearch.SecondDimension) - baseSearch.Word.Length + 1; j++)
                {
                    //Once the method finds a coincident char it starts validating the existence of the rest of the word
                    if (this.Matrix[i, j] == baseSearch.Word[0])
                    {
                        if (baseSearch.WordExists(i, j, Matrix))
                            foundWords.Add(baseSearch.Word);
                    }
                }
            }
        }
    }
}
