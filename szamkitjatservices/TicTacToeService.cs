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

        /// <summary>
        /// result == 0 Még vannak üres helyek és egyik játoks sem győztes
        /// result == 1 1. játékos nyert
        /// result == 2 2. játékos nyert
        /// result == 3 Döntetlen egyik játékos sem nyert és a tábla betelt
        /// </summary>
        /// <returns></returns>
        private byte WinnerChecking()
        {
            int row = 0, col = 0, i = 0;
            bool isNotFull = false;

            for (byte gamer = 1; gamer <= 2; gamer++)
            {
                for (row = 0; row < Table.GetLength(0); row++)
                {
                    for (col = 0; col < Table.GetLength(1); col++)
                    {
                        if (!isNotFull && Table[row, col] == 0)
                        {
                            isNotFull = true;
                            continue;
                        };

                        while (col < Table.GetLength(1) && Table[row, col] == gamer)
                        {                           
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                            col++;
                        }
                        i = 0;
                    }
                }

                for (col = 0; col < Table.GetLength(1); col++)
                {
                    for (row = 0; row < Table.GetLength(0); row++)
                    {
                        while (row < Table.GetLength(0) && Table[row, col] == gamer)
                        {
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                            row++;
                        }
                        i = 0;
                    }
                }

                for (col = 0; col < Table.GetLength(1); col++)
                {
                    for (row = 0; row < Table.GetLength(0); row++)
                    {
                        while (col < Table.GetLength(1) && row < Table.GetLength(0) && Table[row, col] == gamer)
                        {
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                            row++;
                            col++;
                        }
                        i = 0;
                    }
                }

                for (col = Table.GetLength(1) - 1; col >= 0; col--)
                {
                    for (row = 0; row < Table.GetLength(0); row++)
                    {
                        while (col > 0 && row < Table.GetLength(0) && Table[row, col] == gamer)
                        {
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                            row++;
                            col--;
                        }
                        i = 0;
                    }
                }
            }

            return isNotFull ? (byte)0 : (byte)3;
        }

        public bool AddComputerBet(byte gamerOrder)
        {
            for (byte row = 0; row < Table.GetLength(0); row++)
            {
                for (byte col = 0; col < Table.GetLength(1); col++)
                {
                    if (Table[row, col] == 0)
                    {
                        return AddBet(gamerOrder, row, col);
                    }
                }
            }

            return false;
        }
    }
}