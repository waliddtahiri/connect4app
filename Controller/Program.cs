using System;

namespace connect4 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Human player1 = new Human();
            Computer player2 = new Computer();

            Boolean winner = false;
            Boolean leaveLoop = false;
            int turnCounter = 0;

            while (leaveLoop == false)
            {
                if (turnCounter % 2 == 0)
                {
                    board.displayBoard();
                    player1.play(board);
                    winner = board.checkForWinner("X");
                    turnCounter += 1;
                }
                else
                {
                    player2.play(board);
                    turnCounter += 1;
                    winner = board.checkForWinner("O");
                }

                if (winner)
                {
                    board.displayBoard();
                    break;
                }
            }
        }
    }
}
