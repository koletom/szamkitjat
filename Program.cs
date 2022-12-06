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
            var h = new Hang(); 
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            h.Music();
            Console.WriteLine("Üdv a Játékok Univerzumában\n");
            h.Music();
            IGame[] games = new IGame[4];

            games[0] = new Amoba();
            games[1] = new Kitalalos();
            games[2] = new HuszonegyKartya();
            games[3] = new KoPapirOllo();

            var n = new Game(games);

            n.Kezdes();
            h.Music();
            n.Ending();
            h.Music();

        }
    }
}

