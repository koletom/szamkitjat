using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces.Services;

namespace szamkitjatservices
{
    public class GomokuService : IAmobaService
    {
        public AmobaType GameType => AmobaType.Gomoku;

        public byte TableRow => 19;

        public byte TableColumn => 19;

        private byte[,] _table => new byte[19, 19];
        public byte[,] Table => _table;

        public byte WinnerCheck => WinnerChecking();

        public string GameDescription => "Az a cél, hogy egy sorba oszlopba vagy átlósan 5 azonos kő legyen lerakva";

        public string GameName => "19x19-es amőba játék";

        public bool AddBet(byte gamer, byte row, byte col)
        {
            if (row >= 5 || col >= 5 || Table[row, col] !=0)
            {
                return false;
            }
            Table[row, col] = gamer;
            return true;
        }

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
                            if (i == 5)
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
                            if (i == 5)
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
                            row++;
                            col++;
                            i++;
                            if (i == 5)
                            {
                                return gamer;
                            }
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
                            row++;
                            col--;
                            i++;
                            if (i == 5)
                            {
                                return gamer;
                            }
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
