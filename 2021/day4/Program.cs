void checkNumbers(int[] chosenNumbers, List<int[][]> fields, List<int[][]> markedFields, int boardSize, ref int boardsThatHaveWon)
{
    int numberOfBoards = fields.Count;

    for (int i = 0; i < chosenNumbers.Length; i++)
    {
        int chosenNumber = chosenNumbers[i];
        List<int> fieldsToRemove = new List<int>();
        for (int j = 0; j < fields.Count; j++)
        {
            int[][] board = fields[j];
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (board[x][y] == chosenNumber)
                    {
                        markedFields[j][x][y] = 1;
                    }
                }
            }
            int won = winningBoard(board, markedFields[j], boardSize);
            if (won > 0)
            {
                boardsThatHaveWon++;
                fieldsToRemove.Add(j);
                if (boardsThatHaveWon == numberOfBoards)
                {
                    Console.WriteLine($"Bingo! {won * chosenNumber}");
                    return;
                }
            }
        }
        fieldsToRemove.Sort();
        fieldsToRemove.Reverse();

        foreach (int index in fieldsToRemove)
        {
            fields.RemoveAt(index);
            markedFields.RemoveAt(index);
        }
    }
}

int winningBoard(int[][] board, int[][] markedBoard, int boardSize)
{
    for (int i = 0; i < board.Length; i++)
    {
        int[] row = board[i];

        int sumRow = 0;
        for (int j = 0; j < boardSize; j++)
        {
            sumRow += markedBoard[j][i];
        }

        if (markedBoard[i].Sum() == boardSize || sumRow == boardSize)
        {
            int score = calculateSum(board, markedBoard, boardSize);
            return score;
        }
    }
    return -1;
}

int calculateSum(int[][] board, int[][] markedBoard, int boardSize)
{
    int sum = 0;
    for (int i = 0; i < boardSize; i++)
    {
        for (int j = 0; j < boardSize; j++)
        {
            if (markedBoard[i][j] == 0)
            {
                sum += board[i][j];
            }
        }
    }
    return sum;
}

Console.WriteLine("Welcome to day 4!");

string[] inputArray = File.ReadAllLines("input.txt");

int[] chosenNumbers = Array.ConvertAll(inputArray[0].Split(','), i => int.Parse(i));

List<int[][]> fields = new List<int[][]>();
List<int[][]> markedFields = new List<int[][]>();

int boardSize = inputArray[2].Split().
        Where(x => x != string.Empty).ToArray().Length;
int untilNumber = 2 + boardSize;
int arrayPos = 0;

fields.Add(new int[boardSize][]);
markedFields.Add(new int[boardSize][]);


for (int i = 2; i < inputArray.Length; i++)
{
    if (inputArray[i] == "")
    {
        continue;
    }
    if (untilNumber < i)
    {
        fields.Add(new int[boardSize][]);
        markedFields.Add(new int[boardSize][]);

        untilNumber += boardSize + 1;
        arrayPos++;

    }
    fields[arrayPos][((i - 2) % boardSize)] = Array.ConvertAll(inputArray[i].Split().
        Where(x => x != string.Empty).ToArray(), s => int.Parse(s));
    markedFields[arrayPos][((i - 2) % boardSize)] = new int[boardSize];
    Array.Fill<int>(markedFields[arrayPos][((i - 2) % boardSize)], (int)0);
}

int boardsThatHaveWon = 0;

// play bingo
checkNumbers(chosenNumbers, fields, markedFields, boardSize, ref boardsThatHaveWon);

Console.WriteLine("The end :-)");
