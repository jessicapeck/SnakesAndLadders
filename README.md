# SnakesAndLadders
- [Introduction](#introduction)
- [Technologies](#technologies)
- [How to play](#how-to-play)
- [License](#license)
 
## Introduction
Welcome to the 'Snakes and Ladders' game! This project was developed for a school assignment in which we were learning how to build a very basic UI for a coded game.

## Technologies
- C# version 8.0
- Microsoft Visual Studio version 16.11.13
- .NET Framework version 4.8

## How to play
When the program is first run, the form will appear like the first image. **Snakes** on the board are represented by green lines and **ladders** are represented by brown lines. There is a blue counter for **Player 1** and a red counter for **Player 2**. Both counters are initially on sqaure 1 of the grid.

- Player 1 has takes their turn first by clicking the *ROLL DICE* button, their roll result will appear in the box next to the button.
- Player 1's counter will incrementally move the number of squares indicated by the dice roll.
- A message in the player's corresponding colour will be displayed below the grid to show a summary of the move.
- If the result of a player's turn is that they land at the bottom of a ladder, they will climb the ladder.
- If the result of a player's turn is that they land at the top of a snake, they will fall back down the snake.
- After Player 1's turn has concluded, the steps above are repeated for Player 2.
- The game concludes once a player has reached square 100. The first player to reach square 100 is the winner!

| Start screen | After player 1's turn | After player 2's turn |
|--------------|-----------------------|-----------------------|
|<img src="https://github.com/jessicapeck/SnakesAndLadders/blob/main/images/snakes-and-ladders-1.png" alt="Snakes and Ladders image 1" width=100%>|<img src="https://github.com/jessicapeck/SnakesAndLadders/blob/main/images/snakes-and-ladders-2.png" alt="Snakes and Ladders image 2" width=100%>|<img src="https://github.com/jessicapeck/SnakesAndLadders/blob/main/images/snakes-and-ladders-3.png" alt="Snakes and Ladders image 3" width=100%>|

## License
Open sourced under the [MIT license](LICENSE.md).

