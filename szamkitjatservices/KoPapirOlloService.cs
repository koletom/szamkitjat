using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces.Services;

namespace szamkitjatservices
{
    public class KoPapirOlloService : IKoPapirOlloService
    {
        public string GameDescription => "A cél, hogy 5 pontot szerezzünk.";

        public string GameName => "Kő, Papír, Olló jéték";

        public byte WinnerCheck => WinnerChecking();

        /// <summary>
        /// result == 0 => Nincs még győztes
        /// result == 1 => játékos nyert
        /// result == 2 => számítógép nyert
        /// </summary>
        private byte WinnerChecking()
        {
            int playerPoints = 0, computerPoints = 0;
            byte winner = 0;

            if (playerPoints == 5)
            {
                winner = 1;
                return winner;
            }
            else if (computerPoints == 5)
            {
                winner = 2;
                return winner;
            }
            else if (playerPoints >= 4 || computerPoints >= 4)
            {
                winner = 0;
                return winner;
            }
            return 0;
        }
    }
}
