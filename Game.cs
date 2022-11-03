using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjat
{
    //TODO:Ha jól látom ez lenne a játék vezérlő. Ennek is legyen 1 interface mondjuk IGameController
    
    class Game 
    {
        public void Kezdes()
        {
            
            Kitalalos kitalalos = new Kitalalos();
            KoPapirOllo koPapirOllo = new KoPapirOllo();
            HuszonegyKartya huszonegyKartya = new HuszonegyKartya();
            Amoba amoba = new Amoba();
            Console.WriteLine("Válassz játékmódot");
            Console.WriteLine("1 - Kitalálós");
            Console.WriteLine("2 - Kő, Papír, Olló");
            Console.WriteLine("3 - 21 kártyajáték");
            Console.WriteLine("4 - Amőba");
            Console.WriteLine("k - Kilépés");

            switch (Console.ReadKey(true).KeyChar)
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
