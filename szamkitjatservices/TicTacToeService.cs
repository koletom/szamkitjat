using szamkitjatiterfaces.Services;

namespace szamkitjatservices
{
    public class TicTacToeService : IAmobaService
    {
        public AmobaType GameType => AmobaType.TicTacToe;

        public byte TableRow => 3;

        public byte TableColumn => 3;

        private byte[,] _table = new byte[3, 3];
        public byte[,] Table => _table;

        public byte WinnerCheck => WinnerChecking();

        public string GameDescription => "Az a cél, hogy egy sorba oszlopba vagy átlósan 3 azonos kő legyen lerakva";

        public string GameName => "3x3-as amőba játék";

        public bool AddBet(byte gamer, byte row, byte col)
        {
            if (row >= 3 || col >= 3 || Table[row, col] != 0)
            {
                return false;
            }

            Table[row, col] = gamer;
            return true;
        }

        private byte WinnerChecking()
        {
            return 0;
        }
    }
}