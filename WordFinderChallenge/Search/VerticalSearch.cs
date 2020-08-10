namespace WordFinderChallenge.Search
{
    public class VerticalSearch : BaseSearch
    {
        public VerticalSearch(string word) : base(word)
        {
            this.FirstDimension = Constants.C_VER_DIMENSION;
            this.SecondDimension = Constants.C_HOR_DIMENSION;
        }

        public override bool WordExists(int firstAxis, int secondAxis, char[,] matrix)
        {
            //Since the first char was compared outside of the method, I start validating from the second one in case it exists
            int i = 1;
            firstAxis++;

            if (Word.Length > 1 && Word.Length != 0)
            {
                while (matrix[firstAxis, secondAxis] == this.Word[i] && i < (this.Word.Length - 1))
                {
                    if (matrix[firstAxis, secondAxis] == this.Word[i])
                    {
                        i++;
                        firstAxis++;
                    }
                }
            }

            return i == Word.Length - 1 || Word.Length == 1;
        }
    }
}
