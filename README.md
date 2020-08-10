WordFinder challenge considerations

I will make a brief summary of what I've taken into account to develop this solution:

First of all, what I interpreted is that the WordFinder constructor receives
a IEnumerable of 64 strings containinc 64 characters each, which I should
convert into an array and assign it as an attribute of this class.

Regarding the 'Find' method, I opted to use Search classes that derive from
an abstract BaseSearch class. This way I avoid repeating code and makes it easy
to expand with only a few lines of code.

In terms of performance I've taken into account a few details:
-Instead of searching through the entire matrix, I only search from zero to
(64 - word.Length) because it wouldn't make sense to search inside the remaining
coordinates when the word doesn't fit there.
-I considered using recursion in order to improve the performance, but after
some research I figured out that it's way slower in C#, so I opted to use loops.
-The 'WordExists' method starts validating after the first char coincidence was found.
It also starts from the 2nd char of that word because the first one was compared outside
of the method.
-Every variables such as messages or configurations are defined as constants.

Regarding scalability, the program is easy to expand due to the use of abstract classes.
In case I'd want to add something like a 'backwards search' or a 'diagonal' one, I just
add a class that derives from BaseSearch and implements its methods with its own logic.
Then you just pass an instance of this class as a parameter of the SearchWord method
and that would be it.

Thank you for reading!

Matías Atencio - Systems Analyst / Sr .NET Developer

