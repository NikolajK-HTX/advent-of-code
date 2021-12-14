Console.WriteLine("Day 5!");

string[] inputArrayString = File.ReadAllLines("example.txt");

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

    if (from[0] == to[0])
    {
        direction = 1;
        difference = to[1] - from[1];
        start = from[1];
        end = to[1];
    }
    else if (from[1] == to[1])
    {
        direction = 0;
        difference = to[0] - from[0];
        start = from[0];
        end = to[0];
    }
    if (start > end) {
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

int[][] field = new int[allXNumbers.Max()][];
for (int i = 0; i < field.Length; i++)
{
    field[i] = new int[allYNumbers.Max()];
    Array.Fill(field[i], 0);
}

for (int i = 0; i < allPoints.Count; i++)
{
    int[] currentPoint = allPoints[i];
    int x = currentPoint[0];
    int y = currentPoint[1];
    field[x][y]++;
}