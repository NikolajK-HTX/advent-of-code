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

    // easy digits
    foreach (var output in outputArray)
    {
        if(numberLength[output.Length].Length == 1)
        {
            dictDigits[numberLength[output.Length][0]] = output;
        }
    }

    foreach (var output in outputArray)
    {
        
    }
}


Console.WriteLine($"The answer is {sum}");
Console.WriteLine("The end.");
