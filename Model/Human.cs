namespace connect4 // Note: actual namespace depends on the project name.
{
    public class Human : Player
    {
        public override void play(Board board)
        {
            while (true)
            {
                Console.Write("\nChoose a space: ");
                String move = Console.ReadLine();
                int[] coordinate = board.coordinateParser(move);
                Console.WriteLine(coordinate[0] + " " + coordinate[1]);
                try
                {
                    //Check if the space is available
                    if (board.isSpaceAvailable(coordinate) && board.gravityCheck(coordinate))
                    {
                        board.modifyArray(coordinate, "X");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid coordinate");
                    }

                }
                catch
                {
                    Console.WriteLine("Error occured. Please try again.");
                }
            }      
        }
    }
}

