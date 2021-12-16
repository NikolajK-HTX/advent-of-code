Console.WriteLine("Day 7!");

var inputString = File.ReadAllText("input.txt");

var input = Array.ConvertAll(inputString.Split(','), s => int.Parse(s)).ToList();

input.Sort();

int medianIndex = (int)input.Count/2;

Console.WriteLine($"The median is {input[medianIndex]} with the index of {medianIndex}");

int fuelExpended = 0;

for (int i = 0; i < input.Count; i++)
{
    var horizontalPosition = input[i];
    fuelExpended += Math.Abs(horizontalPosition-input[medianIndex]);
}

Console.WriteLine($"Total fuel expended is {fuelExpended}");
