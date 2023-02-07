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
            int row = 0, col = 0, i = 0;
            bool areFull = false;

            for (byte gamer = 1; gamer <= 2; gamer++)
            {

                for (row = 0; row < Table.GetLength(0); row++)                       
                {
                    for (col = 0; col < Table.GetLength(1); col++)           
                    {
                        if(!areFull && Table[row,col]==0 )
                        {
                            areFull = true;
                            continue;
                        };

                        while (Table[row,col] == gamer)      
                        {
                            col++;
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                        }
                        i = 0;
                    }
                }

                for (col = 0; col < Table.GetLength(1); col++)                       
                {
                    for (row = 0; row < Table.GetLength(0); row++)
                    {
                        while (Table[row,col] == gamer)
                        {
                            row++;
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                        }
                        i = 0;
                    }
                }

                for (col = 0; col < Table.GetLength(1); col++)             
                {
                    for (row = 0; row < Table.GetLength(0); row++)
                    {
                        while (Table[row,col] == gamer)
                        {
                            row++;
                            col++;
                            i++;
                            if (i == 3)
                            {
                                return gamer;
                            }
                        }
                        i = 0;
                    }
                }
                
                for (col = Table.GetLength(1) - 1; col >= 0 ; col--) 
                {                                                   
                    for (row = 0; row < Table.GetLength(0); row++)    
                    {
                        while (Table[row,col] == gamer) 
                        {
                            row++;                                  
                            col--;                                  
                            i++;                                    
                            if (i == 3)                             
                            {
                                return gamer;                      
                            }                                      
                        }                                          
                        i = 0;                                     
                    }                                              
                }
            }
            return !areFull ? (byte)0:(byte)1;
        }
    }
}