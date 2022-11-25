using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace szamkitjat
{
    //TODO:Ha jól látom ez lenne a játék vezérlő. Ennek is legyen 1 interface mondjuk IGameController
    
    class Game : IGameController
    {
        private IGame[] _games;
        public Game(IGame[] games)
        {
            _games = games;
        }
        public void Kezdes()
        {
            if ( _games is null || _games.Length==0)
            {
                Console.WriteLine("Nincs érték");
                return;
            }

            //_games

            char kezdes;
            bool kilep;
            kezdes = Console.ReadKey(true).KeyChar;
            kilep = (kezdes == 'k' ^ kezdes == 'K');
            if (kilep == true) { kezdes = 'k'; }
            else { }

            //if (Console.ReadKey(true).KeyChar == 1)
            //{
            //}
            //else if

        }

            public void Ending()
        {
            Console.WriteLine("Viszlát");
            System.Threading.Thread.Sleep(2000);
            System.Environment.Exit(1);
        }
    }
}
