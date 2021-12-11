// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

StreamReader inputFile = File.OpenText("input.txt");

string[] inputText = inputFile.ReadToEnd().Split('\n');

int horizontalMovement = 0;
int depth = 0;
int aim = 0;

foreach (string entireCommand in inputText)
{
    if(entireCommand == "")
    {
        continue;
    }

    string[] commandArray = entireCommand.Split(' ');

    string command = commandArray[0];
    int moves = int.Parse(commandArray[1]);

    if (command.ToLower() == "forward")
    {
        horizontalMovement += moves;
        depth += aim * moves;
    }
    if (command.ToLower() == "up")
    {
        aim -= moves;
    }
    if (command.ToLower() == "down")
    {
        aim += moves;
    }
}

Console.WriteLine($"Final horizontal movement: {horizontalMovement}");
Console.WriteLine($"Final depth: {depth}\n");

Console.WriteLine($"horizontalMovement * depth = {horizontalMovement * depth}");

inputFile.Close();
