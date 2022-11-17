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
            if ( _games is null )
            {

            }
            else
            {

            }
            Console.WriteLine("Válassz játékmódot");
            

            char kezdes;
            bool kilep;
            kezdes = Console.ReadKey(true).KeyChar;
            kilep = (kezdes == 'k' ^ kezdes == 'K');
            if (kilep == true) { kezdes = 'k'; }
            else { }
            switch (kezdes)
            {
                case '1':
                    kitalalos.Start();
                    kitalalos.Play();
                    kitalalos.End();
                    break;
                case '2':
                    koPapirOllo.Start();
                    koPapirOllo.Play();
                    koPapirOllo.End();
                    break;
                case '3':
                    huszonegyKartya.Start();
                    huszonegyKartya.Play();
                    huszonegyKartya.End();
                    break;
                case '4':
                    amoba.Start();
                    amoba.Play();
                    amoba.End();
                    break;
                case 'k':
                    Ending();
                    break;
                default:
                    Kezdes();
                    break;
            }
        }

        public void Ending()
        {
            Console.WriteLine("Viszlát");
            System.Threading.Thread.Sleep(2000);
            System.Environment.Exit(1);
        }
    }
}
