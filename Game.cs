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
            if ( _games is null || _games.Length==0)
            {
                Console.WriteLine("Nincs érték");
                return;
            }

            //TODO: Jelenítsd meg a menüt!!! 
            //(ciklus kiir ciklusindex, IGame.Name)

            byte jatekmod = 9;

            Console.WriteLine("Üdv a játékban");
            //do
            //{
                Console.WriteLine("Az alábbi {0} játékód közül lehet válsztani",_games.Length);

                for (int i = 0; i < _games.Length; i++)
                {
                    Console.WriteLine("{0} -> {1}", i, _games[i].Name);
                }

                Console.WriteLine("Válassz játékmódot / Adja meg a játékmód számát (0-{0})",_games.Length-1);
                string valasztas = Console.ReadLine();
                jatekmod = Convert.ToByte(valasztas[0]);

                //char w = '0';
                //byte b = Convert.ToByte(valasztas);
                if (byte.TryParse(valasztas.ToString(), out jatekmod))
                {
                    Console.WriteLine(jatekmod);
                }
                else
                {
                    Console.WriteLine("hiba");
                }


                if (jatekmod >= '0' || jatekmod <= _games.Length-1 )
                {
                    _ = _games;
                }

            //} while ((jatekmod < 1) || (jatekmod > 5));

            string jname = "";
            switch (jatekmod)
            {
                case 0:
                    jname = "Amőba";
                    break;
                case 1:
                    jname = "Kitalálós";
                    break;
                case 2:
                    jname = "Huszonegy";
                    break;
                case 3:
                    jname = "Kő, Papír, Olló";
                    break;
                default:
                    break;
            }


            Console.WriteLine("A választott játékmód: {0} {1}", jatekmod, jname);


            _games = valasztas[0];
            _games = jatekmod;

            char kezdes;
            bool kilep;
            kezdes = Console.ReadKey(true).KeyChar;
            kilep = (kezdes == 'k' ^ kezdes == 'K'); //TODO:Logikai kifejezésben ne használj bitwise operátorokat.
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
