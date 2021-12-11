// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 3 - Part two!");

StreamReader inputFile = File.OpenText("input.txt");
string[] inputArray = inputFile.ReadToEnd().Split('\n');
inputFile.Close();

int digitsInBit = inputArray[0].Length;

List<string> oxygenGeneratorRatingList = new List<string>(inputArray);
List<string> co2ScrubberRatingList = new List<string>(inputArray);

int pos = 0;
do
{
    int bitSum = 0;
    for (int i = 0; i < oxygenGeneratorRatingList.Count; i++)
    {
        string inputLine = oxygenGeneratorRatingList[i];
        if (inputLine[pos] == '1')
        {
            bitSum++;
        }
        else
        {
            bitSum--;
        }
    }
    char toRemove;
    if (bitSum >= 0)
    {
        toRemove = '0';
    }
    else
    {
        toRemove = '1';
    }

    List<int> indicesToRemove = new List<int>();
    for (int i = 0; i < oxygenGeneratorRatingList.Count; i++)
    {
        if (oxygenGeneratorRatingList[i][pos] == toRemove)
        {
            indicesToRemove.Add(i);
        }
    }
    indicesToRemove.Sort();
    indicesToRemove.Reverse();
    foreach (int index in indicesToRemove)
    {
        oxygenGeneratorRatingList.RemoveAt(index);
    }
    pos++;

} while (oxygenGeneratorRatingList.Count != 1);

pos = 0;
do
{
    int bitSum = 0;
    for (int i = 0; i < co2ScrubberRatingList.Count; i++)
    {
        string inputLine = co2ScrubberRatingList[i];
        if (inputLine[pos] == '1')
        {
            bitSum++;
        }
        else
        {
            bitSum--;
        }
    }
    char toRemove;
    if (bitSum >= 0)
    {
        toRemove = '1';
    }
    else
    {
        toRemove = '0';
    }

    List<int> indicesToRemove = new List<int>();
    for (int i = 0; i < co2ScrubberRatingList.Count; i++)
    {
        if (co2ScrubberRatingList[i][pos] == toRemove)
        {
            indicesToRemove.Add(i);
        }
    }
    indicesToRemove.Sort();
    indicesToRemove.Reverse();
    foreach (int index in indicesToRemove)
    {
        co2ScrubberRatingList.RemoveAt(index);
    }
    pos++;

} while (co2ScrubberRatingList.Count != 1);

int oxygenGeneratorRating = Convert.ToInt32(String.Join(null, oxygenGeneratorRatingList), 2);
int co2ScrubberRating = Convert.ToInt32(String.Join(null, co2ScrubberRatingList), 2);

Console.WriteLine($"oxygenGeneratorRating = {oxygenGeneratorRating}");
Console.WriteLine($"co2ScrubberRating = {co2ScrubberRating}");
Console.WriteLine("oxygenGeneratorRating * co2ScrubberRating = {0}",
    oxygenGeneratorRating * co2ScrubberRating);
