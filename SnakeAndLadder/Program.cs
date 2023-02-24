using SnakeAndLadder;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Add users
        User player1 = new User(1, "Guruprasad", "guruprasadbv4648@gmail.com");
        User player2 = new User(2, "Adithya", "adithyabhatoct99@gmail.com");

        // Create Dice
        Dice dice = new Dice(6);

        // Build the board
        Board board = new Board.BoardBuilder()
                            .SetRows(10)
                            .SetColumns(10)
                            .AddLadder(2, 12)
                            .AddLadder(13, 81)
                            .AddLadder(45, 70)
                            .AddSnake(99, 11)
                            .AddSnake(31, 20)
                            .AddSnake(60, 21)
                            .Build();

        // Build the game
        Game game = new Game.GameBuilder()
                            .SetBoard(board)
                            .SetDice(dice)
                            .AddPlayer(player1)
                            .AddPlayer(player2)
                            .Build();

        game.StartGame();

        Console.ReadKey();
    }
}