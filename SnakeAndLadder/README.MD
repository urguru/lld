# Snake and Ladder Game
## Overview
This is a Snake and Ladder game implementation in C#. The game is played on a board with a grid of cells, where each cell represents a tile. The game has two or more players, and each player starts from the first tile. Players take turns rolling a dice to determine the number of tiles they move forward. If a player lands on a tile with a ladder, they climb the ladder to the higher-numbered tile, while if they land on a tile with a snake, they slide down to the lower-numbered tile. The winner is the first player to reach the last tile.

## Low-Level Design (LLD)
The game has several key components, including the board, the dice, the players, and the game itself.

### Board
The Board class represents the game board, which consists of a grid of cells or tiles. The Board class has properties for the number of rows and columns on the board, as well as a dictionary of jumps that represents the locations of the snakes and ladders on the board. The Board class also has a method for calculating the index of the winning tile, which is simply the product of the number of rows and columns.

### Dice
The Dice class represents the dice used to play the game. It has a property for the number of sides on the dice and a method for rolling the dice to generate a random number.

### Player
The Player class represents a player in the game. It has properties for the player's ID, name, and email address, as well as a property for the player's current position on the board.

### Game
The Game class is the main class that controls the game flow. It has properties for the board, dice, and players, as well as methods for adding players to the game, rolling the dice, and moving the players on the board. The Game class also has a method for determining the winner of the game.

### BoardBuilder
The BoardBuilder class is a builder pattern implementation for the Board class. It allows the creation of a board by specifying the number of rows and columns, as well as the locations of the snakes and ladders on the board.

### GameBuilder 
The GameBuilder class is responsible for constructing and configuring a Game instance. It provides a fluent API for configuring various aspects of the game such as the board, dice, and players.

## Conclusion
The Snake and Ladder game implementation is a fun project that can help you understand the principles of low-level design. It involves several key components, including the board, the dice, the players, and the game itself. By understanding the low-level design of the game, you can gain a better appreciation of the underlying architecture that makes the game work.