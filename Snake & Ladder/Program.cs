using System.Diagnostics;
using Snake___Ladder.Models;

//Read number of cells
Console.WriteLine("Enter the number of cells on the board:");
int cellsCount = int.Parse(Console.ReadLine());

//Read number of sides of the die
Console.WriteLine("Enter the number of sides of the die:");
int sideCount = int.Parse(Console.ReadLine());

//Initialise the game
Game game = new Game(cellsCount, sideCount);

Console.WriteLine("Enter the number of snakes:");
int snakesCount = int.Parse(Console.ReadLine());

// Read snake positions
Console.WriteLine("Enter the head and tail positions of each snake:");
for (int i = 0; i < snakesCount; i++)
{
    string[] input = Console.ReadLine().Split();
    int head = int.Parse(input[0]);
    int tail = int.Parse(input[1]);
    game.AddSnakeAndLadder(head, tail);
}

// Read number of ladders
Console.WriteLine("Enter the number of ladders:");
int laddersCount = int.Parse(Console.ReadLine());

// Read ladder positions
Console.WriteLine("Enter the start and end positions of each ladder:");
for (int i = 0; i < laddersCount; i++)
{
    string[] input = Console.ReadLine().Split();
    int start = int.Parse(input[0]);
    int end = int.Parse(input[1]);
    game.AddSnakeAndLadder(start, end);
}

// Read number of players
Console.WriteLine("Enter the number of players:");
int playersCount = int.Parse(Console.ReadLine());

// Read player names
Console.WriteLine("Enter the names of each player:");
for (int i = 0; i < playersCount; i++)
{
    string playerName = Console.ReadLine();
    Player player = new Player(playerName);
    game.AddPlayer(player);
}

game.StartGame();