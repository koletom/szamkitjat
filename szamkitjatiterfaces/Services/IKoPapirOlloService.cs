using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjatiterfaces.Services
{
    public interface IKoPapirOlloService:IGameService
    {
        /// <summary>
        /// result == 0 => Nincs még győztes
        /// result == 1 => játékos nyert
        /// result == 2 => számítógép nyert
        /// </summary>
        byte WinnerCheck { get; }
    }
}
