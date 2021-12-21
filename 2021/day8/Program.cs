Console.WriteLine("Day 8!");

string[] inputArray = File.ReadAllLines("example.txt");

int sum = 0;

// dictDigits[int is the number] = string is characters that make up the digit
Dictionary<int, string> dictDigits = new Dictionary<int, string>();

Dictionary<int, int[]> numberLength = new Dictionary<int, int[]>()
{
    {2, new int[] {1} },
    {3, new int[] {7} },
    {4, new int[] {4} },
    {5, new int[] {2, 3, 5} },
    {6, new int[] {0, 6, 9} },
    {7, new int[] {8} },
};

foreach (var line in inputArray)
{
    string[] lineArray = line.Split('|');
    string[] digitsArray = lineArray[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string[] outputArray = lineArray[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string[] decodingArray = digitsArray.Concat(outputArray).ToArray();

    // easy digits
    foreach (var input in decodingArray)
    {
        if(numberLength[input.Length].Length == 1)
        {
            var inputOrdered = String.Concat(input.OrderBy(x => x));
            dictDigits[numberLength[input.Length][0]] = inputOrdered;
        }
    }

    foreach (var input in decodingArray)
    {
    var inputOrdered = String.Concat(input.OrderBy(x => x));
        if(inputOrdered.Length == 5)
        {
            // if the length of the word is 5
            // then it could be 2, 3 or 5

            // however if it shares the letters
            // from digit 1, then it can only be 3
            if (inputOrdered.Contains(dictDigits[1]))
            {
                dictDigits[3] = inputOrdered;
            }
        }
    }
}

Console.WriteLine($"The answer is {sum}");
Console.WriteLine("The end.");
