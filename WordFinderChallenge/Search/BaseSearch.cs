using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderChallenge.Search
{
    public abstract class BaseSearch
    {
        public string Word { get; set; }
        public int FirstDimension { get; set; }
        public int SecondDimension { get; set; }

        protected BaseSearch(string word)
        {
            this.Word = word;
        }

        public abstract bool WordExists(int firstAxis, int secondAxis, char[,] matrix);
    }
}
