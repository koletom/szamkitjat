using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjatiterfaces.Services
{
    public enum AmobaType { TicTacToe /* 3x3 */, Gomoku /* 19x19/5 */}
    public interface IAmobaService:IGameService
    {
        AmobaType GameType { get; }
        byte TableRow { get; }
        byte TableColumn { get; }
        byte[,] Table { get; }
        
        /// <summary>
        /// result == 0 => Nincs győztes, de van még hely a táblán
        /// result == 1 => 1. játékos nyert
        /// result == 2 => 2. játékos nyert
        /// result == 3 => Döntetlen
        /// </summary>
        byte WinnerCheck { get; }

        bool AddBet(byte gamer, byte row, byte col);
    }
}
