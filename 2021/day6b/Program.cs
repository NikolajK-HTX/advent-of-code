Console.WriteLine("Day 6 Part Two!");

int days = 256;

string inputArrayString = File.ReadAllText("../day6/input.txt");
int[] initialState = Array.ConvertAll(inputArrayString.Split(','),
    s => int.Parse(s));

Dictionary<int, ulong> lanternFishes = new Dictionary<int, ulong>(8);
for (int i = 0; i <= 8; i++)
{
    lanternFishes[i] = 0;
}

foreach (int index in initialState)
{
    lanternFishes[index]++;
}

for (int i = 1; i <= days; i++)
{
    ulong fishReproducing = lanternFishes[0];
    for (int j = 0; j < lanternFishes.Keys.Count-1; j++)
    {
        lanternFishes[j] = lanternFishes[j+1];
    }
    lanternFishes[6] += fishReproducing;
    lanternFishes[8] = fishReproducing;
}

ulong sum = 0;
foreach (var numberOfFish in lanternFishes.Values.ToArray())
{
    sum += numberOfFish;
}

Console.WriteLine($"After 256 days: {sum}");

Console.ReadLine();


