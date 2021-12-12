Console.WriteLine("Hello, World!");

string inputPath = "input.txt";
StreamReader inputFile = File.OpenText(inputPath);
int[] inputArray = new int[File.ReadLines(inputPath).Count()];
int lengthOfLine = 0;

for (int i = 0; i < inputArray.Length; i++)
{
    string? input = inputFile.ReadLine();
    if (i == 0 && input != null)
    {
        lengthOfLine = input.Length;
    }
    inputArray[i] = Convert.ToInt32(input, 2);
}

inputFile.Close();

int gammaRate = 0;
int epsilonRate = 0;

for (int pos = lengthOfLine-1; pos >= 0; pos--)
{
    int ones = 0;

    for (int j = 0; j < inputArray.Length; j++)
    {
        int currentInput = inputArray[j];
        if ((currentInput & (int)Math.Pow(2, pos)) == (int)Math.Pow(2, pos))
        {
            ones++;
        }
    }
    if (ones >= inputArray.Length/2)
    {
        gammaRate = gammaRate | (int)Math.Pow(2, pos);
    }
    else
    {
        epsilonRate = epsilonRate | (int)Math.Pow(2, pos);
    }

}

Console.WriteLine($"Gamma rate in decimal is {gammaRate}.");
Console.WriteLine($"Epsilon rate in decimal is {epsilonRate}.\n");
Console.WriteLine($"Epsilon rate * Gamma rate = {gammaRate * epsilonRate}");
Console.WriteLine("Where both rates are in decimal.");
