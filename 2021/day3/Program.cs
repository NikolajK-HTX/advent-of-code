// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

StreamReader inputFile = File.OpenText("input.txt");

string[] inputArray = inputFile.ReadToEnd().Split('\n');

List<char> gammaRate = new List<char>();
List<char> epsilonRate = new List<char>();

for (int i = 0; i < inputArray[0].Length; i++)
{
    int ones = 0;
    int zeroes = 0;

    for (int j = 0; j < inputArray.Length; j++)
    {
        string inputText = inputArray[j];
        if (inputText.Length == 0)
        {
            continue;
        }
        char inputChar = inputText[i];
        if (inputChar == '1')
        {
            ones++;
        }
        else if (inputChar == '0')
        {
            zeroes++;
        }
        else
        {
            throw new Exception();
        }
    }
    if (ones > zeroes)
    {
        gammaRate.Add('1');
        epsilonRate.Add('0');
    }
    else
    {
        gammaRate.Add('0');
        epsilonRate.Add('1');
    }

}

int gammaRateDecimal = Convert.ToInt32(String.Join(null, gammaRate), 2);
int epsilonRateDecimal = Convert.ToInt32(String.Join(null, epsilonRate), 2);

Console.WriteLine($"Gamma rate in decimal is {gammaRateDecimal}.");
Console.WriteLine($"Epsilon rate in decimal is {epsilonRateDecimal}.\n");
Console.WriteLine($"Epsilon rate * Gamma rate = {gammaRateDecimal * epsilonRateDecimal}");
Console.WriteLine("Where both rates are in decimal.");
