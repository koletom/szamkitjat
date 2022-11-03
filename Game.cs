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
            End1 e = new End1();
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
                    break;
                case '2':
                    koPapirOllo.Start();
                    break;
                case '3':
                    huszonegyKartya.Start();
                    break;
                case '4':
                    amoba.Start();
                    break;
                case 'k':
                    e.Ending();
                    break;
                default:
                    Kezdes();
                    break;
            }
        }
    }
    class End1
    {
        public void End()
        {
            Game g = new Game();
            Console.WriteLine("\nVissza a főoldalra? i/n");
            switch (Console.ReadKey(true).KeyChar)
            {
                case 'i':
                    g.Kezdes();
                    break;
                case 'n':
                    g.Kezdes();
                    break;
                default:
                    End();
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
    

    //TODO:Ez maradjon a Program.cs-ben
    class Program{
        static void Main(string[] args)
        {
            Game g = new Game();
            Console.WriteLine("Üdv a játékban");
            Console.WriteLine("Négy játékód közül lehet válsztani");
            g.Kezdes();
        }
    }
}
