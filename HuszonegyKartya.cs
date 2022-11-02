using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;
namespace szamkitjat
{

    class HuszonegyKartya : IGame
    {
        #region propertiregion
        int gamercount { get; set; }
        #endregion propertiregion

        Game g = new Game();
        public void End()
        {
            Console.WriteLine("Visszatérés a Főmenübe? (i/n)");
            switch (Console.ReadKey(true).KeyChar)
            {
                case 'i':
                    g.Kezdes();
                    break;
                case 'n':
                    Console.WriteLine("Új játék? i/n");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'i':
                            Start();
                            break;
                        case 'n':
                            End();
                            break;
                    }
                    break;
            }
        }

        //public void Huszonegy()
        //{

        //    int gepkez = 0;
        //    int jatekoskez = 0;

        //    void Osszeg()
        //    {
        //        Console.WriteLine("\nA gép kezében {0} van.\nA játékos kezében {1} van", gepkez, jatekoskez);

        //        if (gepkez == 21 || jatekoskez > 21)
        //        {
        //            Console.WriteLine("Veszítettél!");
        //        }
        //        else if (gepkez == jatekoskez)
        //        {
        //            Console.WriteLine("Döntetlen!");
        //        }
        //        else if (gepkez > 21 || jatekoskez == 21)
        //        {
        //            Console.WriteLine("Nyertél");
        //        }
        //        else if (gepkez > jatekoskez)
        //        {
        //            Console.WriteLine("Veszítettél!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Nyertél");
        //        }

        //    }
        //}
        
        


        int card
        {
            get
            {
                Random num = new Random();
                return num.Next(1, 10);
            }
        }

        void Generate(int gamernum, List<int>[] gamercards)
        {
            gamercards[gamernum].Add(card);
            if (gamercards[gamernum].Count < 2)
            {
                gamercards[gamernum].Add(card);
            }
        }
        public void Play()
        {
            List<int>[] cards = new List<int>[gamercount];

            for (int i = 0; i < gamercount; i++)
            {
                Generate(i, cards);
                var m = string.Join(",", cards[i]);
                Console.WriteLine($"{i}. játékos lapjai:{m}");
                int hit = 0;
                char rk;
                do
                {
                    Console.WriteLine($"{i}. játékos húz-e új lapot? i/n");
                    rk = Console.ReadKey(true).KeyChar;
                    hit++;
                    m = m + card;
                    Console.WriteLine($"{i}. játékos lapjai:{m}");
                    Console.WriteLine($"{i}. játékos húz-e új lapot? i/n");

                } while (hit < 3 || rk == 'i');
            }
            if (card == 21)
            {
                Console.WriteLine($"{gamercount}. játékos nyert.");
            }
            End();
        }

        public void Start()
        {
            string input;
            int p = 0;
            Console.WriteLine("\nAz nyer akinek nagyobb száma van vagy előbb lesz 21-e.\nHa valakinek több mint 21 az veszít");
            do
            {
                Console.WriteLine("Adja meg a játékosok számát (max 5)");
                input = Console.ReadLine();
                if (!int.TryParse(input, out p))
                {

                    Console.WriteLine("Játékosok száma 1-5 -ig szám lehet");
                }

            } while (p < 1 || p > 5);
            gamercount = p;
            Play();
        }
    }
}
