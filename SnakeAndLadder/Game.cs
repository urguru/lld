using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    internal class Game
    {
        private Queue<User> Players = new();

        private Board Board;

        private Dice Dice;

        private Dictionary<int, int> PlayerPositions = new();

        internal void StartGame()
        {
            Console.WriteLine("Welcome to the game");
            Console.WriteLine("List of players");
            foreach (var player in Players)
            {
                player.PrintUserDetails();
            }

            while (Players.Count > 1)
            {
                User currentPlayer = Players.Dequeue();
                Console.WriteLine($"{currentPlayer.Name} your turn!!!");
                int points = Dice.RollDice();
                Console.WriteLine($"Dice roll : {points}");
                int currentPosition = PlayerPositions[currentPlayer.Id];
                int finalPosition = currentPosition + points;

                if (Board.TileContainsLadder(finalPosition,out int probablePosition))
                {
                    Console.WriteLine($"You have encountered a ladder. New position : {probablePosition}");
                    PlayerPositions[currentPlayer.Id] = probablePosition;
                    Players.Enqueue(currentPlayer);
                }
                else if(Board.TileContainsSnake(finalPosition,out probablePosition))
                {
                    Console.WriteLine($"You have encountered a snake. New position : {probablePosition}");
                    PlayerPositions[currentPlayer.Id] = probablePosition;
                    Players.Enqueue(currentPlayer);
                }
                else if (Board.TileOutOfBounds(finalPosition))
                {
                    Console.WriteLine("You have gone out of the board. Try again");
                    Players.Enqueue(currentPlayer);
                }
                else if (Board.IsWinningTile(finalPosition))
                {
                    Console.WriteLine("You have won the game");
                }
                else
                {
                    Console.WriteLine($"New position : {finalPosition}");
                    PlayerPositions[currentPlayer.Id] = finalPosition;
                    Players.Enqueue(currentPlayer);
                }
            }

            Console.WriteLine("Game has completed");
        }

        public class GameBuilder
        {
            private Game game;

            public GameBuilder()
            {
                game = new Game
                {
                    PlayerPositions = new Dictionary<int, int>(),
                    Players = new Queue<User>()
                };
            }

            public GameBuilder SetBoard(Board board)
            {
                game.Board = board;
                return this;
            }

            public GameBuilder SetDice(Dice dice)
            {
                game.Dice = dice;
                return this;
            }

            public GameBuilder AddPlayer(User user)
            {
                if (game.PlayerPositions.ContainsKey(user.Id))
                {
                    throw new ArgumentException("Player already added to the game");
                }

                game.PlayerPositions[user.Id] = 1;
                game.Players.Enqueue(user);
                return this;
            }

            public Game Build()
            {
                return game;
            }
        }
    }
}
