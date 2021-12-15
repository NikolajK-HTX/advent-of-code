Console.WriteLine("Day 5!");

string[] inputArrayString = File.ReadAllLines("input.txt");

List<int[]> allPoints = new List<int[]>();
List<int> allXNumbers = new List<int>();
List<int> allYNumbers = new List<int>();

for (int i = 0; i < inputArrayString.Length; i++)
{
    string inputString = inputArrayString[i];
    string[] inputStringSplit = inputString.Split(" -> ");
    int[] from = Array.ConvertAll(inputStringSplit[0].Split(','), s => int.Parse(s));
    int[] to = Array.ConvertAll(inputStringSplit[1].Split(','), s => int.Parse(s));
    // The number specifies if the line is horizontal or vertical
    // 0 is horizontal (x changes) and 1 is vertical (y changes)
    int direction = -1;
    int difference = 0;
    int start = 0;
    int end = 0;
    allXNumbers.Add(from[0]);
    allXNumbers.Add(to[0]);
    allYNumbers.Add(from[1]);
    allYNumbers.Add(to[1]);

    if (from[0] == to[0]) // vertical: y changes (x is the same)
    {
        direction = 1;
        difference = to[1] - from[1];
        start = from[1];
        end = to[1];
    }
    else if (from[1] == to[1]) // horizontal: x changes (y is the same)
    {
        direction = 0;
        difference = to[0] - from[0];
        start = from[0];
        end = to[0];
    }
    else // diagonal line
    {
        int[] point;
        int[] temp;
        if (from[0] > to[0])
        {
            temp = from;
            from = to;
            to = temp;
        }
        int a = (to[1] - from[1]) / (to[0] - from[0]);
        int b = from[1] - a * from[0];
        for (int j = from[0]; j <= to[0]; j++)
        {
            point = new int[] { j, (int) j*a+b };
            allPoints.Add(point);
        }
        continue;
    }
    if (start > end)
    {
        int temp = start;
        start = end;
        end = temp;
    }
    for (int j = start; j <= end; j++)
    {
        int[] point;
        if (direction == 1)
        {
            point = new int[] { from[0], j };
        }
        else
        {
            point = new int[] { j, from[1] };

        }
        allPoints.Add(point);
    }
}

Console.WriteLine($"Max horizontal: {allXNumbers.Max()}");
Console.WriteLine($"Max vertical: {allYNumbers.Max()}");

int[][] field = new int[allXNumbers.Max() + 1][];
for (int i = 0; i < field.Length; i++)
{
    field[i] = new int[allYNumbers.Max() + 1];
    Array.Fill(field[i], 0);
}

for (int i = 0; i < allPoints.Count; i++)
{
    int[] currentPoint = allPoints[i];
    int x = currentPoint[0];
    int y = currentPoint[1];
    field[x][y]++;
}

int countOverlap = 0;
for (int x = 0; x < field.Length; x++)
{
    for (int y = 0; y < field[x].Length; y++)
    {

        if (field[x][y] >= 2)
        {
            countOverlap++;
        }
    }
}
Console.WriteLine($"My answer is {countOverlap}");