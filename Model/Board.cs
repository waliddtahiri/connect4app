using System;
using System.Globalization;

namespace connect4 // Note: actual namespace depends on the project name.
{
    public class Board
    {
        public String[] Letters = { "A", "B", "C", "D", "E", "F", "G" };
        private String[][] gameBoard = {
            new String[] {"","","","","","",""},
            new String[] {"","","","","","",""},
            new String[] {"","","","","","",""},
            new String[] {"","","","","","",""},
            new String[] {"","","","","","",""},
            new String[] {"","","","","","",""}
        };

        private static int columns = 7;
        private static int rows = 6;

        public void displayBoard()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to Connect 4 game");
            Console.WriteLine("-------------------------");

            Console.Write("\n     A    B    C    D    E    F    G  ");
            for (int x = 0; x < rows; ++x)
            {
                Console.WriteLine("\n   +----+----+----+----+----+----+----+");
                Console.Write(x + "  |");

                for (int y = 0; y < columns; ++y)
                {
                    if (gameBoard[x][y] == "X")
                        Console.Write(" " + gameBoard[x][y] + "  |");
                    else if (gameBoard[x][y] == "O")
                        Console.Write(" " + gameBoard[x][y] + "  |");
                    else
                        Console.Write(" " + "   |");
                }
            }
            Console.WriteLine("\n   +----+----+----+----+----+----+----+");
        }

        public void modifyArray(int[] spacePicked, String turn)
        {
            gameBoard[spacePicked[0]][spacePicked[1]] = turn;
        }

        public Boolean checkForWinner(String chip)
        {
            Boolean winner = false;
            // check for horizontal spaces
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < columns - 3; ++x)
                {
                    // Console.Write(gameBoard[x][y]);
                    // Console.Write(gameBoard[x + 1][y]);
                    // Console.Write(gameBoard[x + 2][y]);
                    //Console.WriteLine(gameBoard[x + 3][y]);
                    
                    if (gameBoard[x][y] == chip && gameBoard[x + 1][y] == chip && gameBoard[x + 2][y] == chip
                    && gameBoard[x + 3][y] == chip)
                    {
                        Console.Write("\n" + chip + " player is the winner");
                        winner = true;
                    }
                }
            }
            // check for vertical spaces
            for (int x = 0; x < rows; ++x)
            {
                for (int y = 0; y < columns - 3; ++y)
                {
                    if (gameBoard[x][y] == chip && gameBoard[x][y + 1] == chip && gameBoard[x][y + 2] == chip
                    && gameBoard[x][y + 3] == chip)
                    {
                        Console.Write("\n" + chip + " player is the winner");
                        winner = true;
                    }
                }
            }
            //check for diagonal spaces
            for (int x = 0; x < rows - 3; ++x)
            {
                for (int y = 3; y < columns; ++y)
                {
                    if (gameBoard[x][y] == chip && gameBoard[x + 1][y - 1] == chip && gameBoard[x + 2][y - 2] == chip
                   && gameBoard[x + 3][y - 3] == chip)
                    {
                        Console.Write("\n" + chip + " player is the winner");
                        winner = true;
                    }
                }
            }
            //check for anti-diagonal spaces
            for (int x = 0; x < rows - 3; ++x)
            {
                for (int y = 0; y < columns - 3; ++y)
                {
                    if (gameBoard[x][y] == chip && gameBoard[x + 1][y + 1] == chip && gameBoard[x + 2][y + 2] == chip
                   && gameBoard[x + 3][y + 3] == chip)
                    {
                        Console.Write("\n" + chip + " player is the winner");
                        winner = true;
                    }
                }
            }
            return winner;
        }

        public int[] coordinateParser(String input)
        {
            int coordinateX = 0;
            int coordinateY = 0;
            if (input[0] == 'A')
            {
                coordinateY = 0;
            }
            if (input[0] == 'B')
            {
                coordinateY = 1;
            }
            if (input[0] == 'C')
            {
                coordinateY = 2;
            }
            if (input[0] == 'D')
            {
                coordinateY = 3;
            }
            if (input[0] == 'E')
            {
                coordinateY = 4;
            }
            if (input[0] == 'F')
            {
                coordinateY = 5;
            }
            if (input[0] == 'G')
            {
                coordinateY = 6;
            }

            coordinateX = CharUnicodeInfo.GetDecimalDigitValue(input[1]);
            int[] coordinate = { coordinateX, coordinateY };

            return coordinate;
        }

        public Boolean isSpaceAvailable(int[] Coordinate)
        {
            if (gameBoard[Coordinate[0]][Coordinate[1]] == "O")
            {
                return false;
            }
            else if (gameBoard[Coordinate[0]][Coordinate[1]] == "X")
            {
                return false;
            }
            else
                return true;
        }

        public Boolean gravityCheck(int[] Coordinate)
        {
            // calculate space below
            int spacebelowX = Coordinate[0] + 1;
            int spacebelowY = Coordinate[1];
            // is coordinate at ground level
            if (spacebelowX == 6)
                return true;
            int[] spacebelow = { spacebelowX, spacebelowY };
            if (isSpaceAvailable(spacebelow) == false)
            {
                return true;
            }
            return false;
        }
    }
}