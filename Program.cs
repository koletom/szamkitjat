using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjat;
using szamkitjatiterfaces;

namespace SzamKitJat
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameUI ui = new UI(); 
            IGame[] games = new IGame[4];

            games[0] = new Amoba(ui);
            games[1] = new Kitalalos(ui);
            games[2] = new HuszonegyKartya(ui);
            games[3] = new KoPapirOllo(ui);

            var n = new Game(games);

            n.Kezdes();
            Hang.Music();
            n.Ending();
            Hang.Music();

        }
    }
}

