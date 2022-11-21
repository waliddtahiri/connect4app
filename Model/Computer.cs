namespace connect4 // Note: actual namespace depends on the project name.
{
    public class Computer : Player
    {
        public override void play(Board board)
        {
            while (true)
                    {
                        var random = new Random();
                        String cpuChoice = board.Letters[random.Next(0, board.Letters.Length - 1)] + "" + random.Next(0, 5);
                        int[] cpuCoordinate = board.coordinateParser(cpuChoice);
                        if (board.isSpaceAvailable(cpuCoordinate) && board.gravityCheck(cpuCoordinate))
                        {
                            foreach (int i in cpuCoordinate){
                                Console.WriteLine(i);
                            }
                            board.modifyArray(cpuCoordinate, "O");
                            break;
                        }
                    }
        }
    }
}