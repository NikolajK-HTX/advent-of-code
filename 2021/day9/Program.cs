Console.WriteLine("Welcome to Day 9.");

string[] inputArray = File.ReadAllLines("input.txt");

int[,] grid = new int[inputArray.Length, inputArray[0].Length];

for (int i = 0; i < inputArray.Length; i++)
{
    string line = inputArray[i];
    for (int j = 0; j < line.Length; j++)
    {
        char myChar = line[j];
        grid[i, j] = (int)char.GetNumericValue(myChar);
    }
}

List<int> lowestPoints = new List<int>();

for (int y = 0; y < grid.GetLength(0); y++)
{
    for (int x = 0; x < grid.GetLength(1); x++)
    {
        bool lowest = true;

        // left
        if (x - 1 >= 0 && grid[y, x] >= grid[y, x - 1])
        {
            lowest = false;
        }
        // right
        if (x + 1 < grid.GetLength(1) && grid[y, x] >= grid[y, x + 1])
        {
            lowest = false;
        }
        // up
        if (y - 1 >= 0 && grid[y, x] >= grid[y - 1, x])
        {
            lowest = false;
        }
        // down
        if (y + 1 < grid.GetLength(0) && grid[y, x] >= grid[y + 1, x])
        {
            lowest = false;
        }

        if (lowest)
        {
            lowestPoints.Add(grid[y, x]+1);
        }
    }
}

Console.WriteLine($"The answer is {lowestPoints.Sum()}.");
