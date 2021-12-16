Console.WriteLine("Day 7!");

ulong MyFunction(ulong number)
{
    ulong answer = 0;
    for (ulong i = 1; i <= number; i++)
    {
        answer += i;
    }
    return answer;
}

var inputString = File.ReadAllText("input.txt");

var input = Array.ConvertAll(inputString.Split(','), s => int.Parse(s)).ToList();

input.Sort();

Dictionary<int, ulong> dictInputFuel = new Dictionary<int, ulong>();

for (int i = 0; i < input.Count; i++)
{
    var inputValue = input[i];
    if (dictInputFuel.ContainsKey(inputValue))
    {
        dictInputFuel[inputValue]++;
    }
    else
    {
        dictInputFuel[inputValue] = 1;
    }
}

List<ulong> fuelExpended = new List<ulong>();

for (int j = 0; j < input.Last(); j++)
{
    ulong sum = 0;
    for (int i = 0; i < dictInputFuel.Keys.Count; i++)
    {
        int keyValue = dictInputFuel.Keys.ToArray()[i];
        ulong fuel = MyFunction((ulong)Math.Abs(keyValue - j)) * dictInputFuel[keyValue];
        sum += fuel;
    }
    fuelExpended.Add(sum);
}

List<ulong> fuelExpendedCopy = new List<ulong>(fuelExpended);
fuelExpendedCopy.Sort();

Console.WriteLine($"Total fuel expended is {fuelExpendedCopy.First()}");
