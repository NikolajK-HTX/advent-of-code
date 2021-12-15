Console.WriteLine("Day 6 - Part 1!");

int days = 80;

string inputString = File.ReadAllText("input.txt");
int[] initialStates = Array.ConvertAll(inputString.Split(','),
    s => int.Parse(s));

List<LanternFish> lanternFishes = new List<LanternFish>();

for (int i = 0; i < initialStates.Length; i++)
{
    int internalTimer = initialStates[i];
    lanternFishes.Add(new LanternFish(internalTimer));
}

for (int i = 1; i <= days; i++)
{
    List<LanternFish> newLanternFishes = new List<LanternFish>();
    for (int j = 0; j < lanternFishes.Count; j++)
    {
        LanternFish lanternFish = lanternFishes[j];
        lanternFish.InternalTimer -= 1;
        if (lanternFish.InternalTimer < 0)
        {
            lanternFish.InternalTimer = 6;
            newLanternFishes.Add(new LanternFish(8));
        }
    }

    foreach (LanternFish lF in newLanternFishes)
    {
        lanternFishes.Add(lF);
    }

    // Console.WriteLine($"After day {i}: {String.Join(", ", lanternFishes.Select(e => e.InternalTimer))}");
}

Console.WriteLine($"There are {lanternFishes.Count} fish");
