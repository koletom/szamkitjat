using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace szamkitjat
{
    class Game : IGameController
    {
        private IGame[] _games;
        public Game(IGame[] games)
        {
            _games = games;
        }
        public void Kezdes()
        {
            if (_games is null || _games.Length == 0)
            {
                Console.WriteLine("Nincs érték");
                return;
            }

            char valasztas;            
            do
            {
                sbyte jatekmod = -1;
                
                Console.WriteLine("Üdv a Játékok Univerzumában\n");
                Console.WriteLine("Az alábbi {0} játékmód közül lehet válsztani\n", _games.Length);

                for (int i = 0; i < _games.Length; i++)
                {
                    Console.WriteLine("{0} -> {1}", i, _games[i].Name);
                }

                Console.WriteLine("\nK -> Kilépés a játék univerzumból\n");
                Console.WriteLine("Válassz játékmódot / Add meg a játékmód számát (0-{0})", _games.Length - 1);
                valasztas = Console.ReadKey(true).KeyChar;

                if (sbyte.TryParse(((char)valasztas).ToString(), out jatekmod))
                {
                    if (jatekmod >= 0 && jatekmod < _games.Length)
                    {
                        PlayGame(_games[jatekmod]);
                    }
                }
                Console.Clear();
            } while (char.ToUpper(valasztas) != 'K');
        }

        public void Ending()
        {
            Console.WriteLine("Viszlát");            
        }

        void PlayGame(IGame selectedGame)
        {
            char c;
            do
            {
                selectedGame.Start();
                selectedGame.Play();
                selectedGame.End();

                //TODO:Ez a kiírás nem az igazi, javítsd ki, hogy jó legyen.
                Console.WriteLine("Akarsz újra {0} játszani? (i/n)");
                
                c = Console.ReadKey(true).KeyChar;

            } while ( char.ToUpper(c) == 'I');
            
        }
    }
}
