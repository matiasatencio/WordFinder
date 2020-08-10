using System;
using System.Collections.Generic;

namespace WordFinderChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            /*I inserted some words into the following list so that we can easily test the program.
             Note that "chill" was written three times, so it should be displayed first after the algorithm runs.
             Then we have "cold" (once), and "wind" (once), but feel free to add/remove any word in order to test
             the different cases.
             I didn't want to move it to a separate method because I wanted it to be as visible and clear as possible.
             */
            List<string> StartingList = new List<string>
            {
                "1111111122222222333333334444444455555555666666667777777788888888",
                "1111111122222222333333334444444455555555c66666667777777788888888",
                "11111111222222223333333344444cold5555555h66666667777777788888888",
                "1111111122222222333333334444444455555555i66666667777777788888888",
                "1111111122222222333333334444444455555555l6666666777w777788888888",
                "111111112chill22333333334444444455555555l6666666777i777788888888",
                "111111112222222233333333444444445555555566666666777n777788888888",
                "111111112222222233333333444444445555555566666666777d777788888888",
                "11111111222222223333333344444chill555555666666667777777788888888"
            };

            for (int i = 0; i < 55; i++)
            {
                StartingList.Add("1111111122222222333333334444444455555555666666667777777788888888");
            }

            //The words i'm going to search
            List<string> words = new List<string> {"cold", "chill", "wind", "snow"};

            //Transforms the list into a matrix
            WordFinder wf = new WordFinder(StartingList);

            //Returns the top 10 most repeated words from the word stream found in the matrix
            IEnumerable<string> result = wf.Find(words);

            //Draws the results of the search
            Helpers.DrawResults(result);

            Console.ReadLine();
        }
    }
}
