using System;
using System.Collections.Generic;
using szamkitjatiterfaces;

namespace szamkitjat
{

    class HuszonegyKartya : IGame
    {
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "Huszonegy";
        #endregion propertiregion

        Game g = new Game();

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

        }

        private static CardDeck cardDeck = new CardDeck();

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

        static void KezdoKezek()
        {
            cardDeck.Elokeszit();
        }
        public void Play()
        {
            List<int>[] cards = new List<int>[gamercount];

            for (int i = 0; i < gamercount; i++)
            {
                Generate(i, cards);
                var m = string.Join(",", cards[i]); //TODO: Ezt akár berakhatod a Generate metódusba, annak visszatérési értékeként, és akkor az egész generate hívást  
                                                    //betehed a következő Console...-os sorba

                Console.WriteLine($"{i}. játékos lapjai:{m}");
                //Console.WriteLine("{0}. játékos lapjai:{1}",i,Generate(i, cards));
                int hit = 0;
                char rk;
                bool newcardyes;
                bool newcardno;
                do
                {
                    Console.WriteLine($"{i}. játékos húz-e új lapot? i/n");
                    rk = Console.ReadKey(true).KeyChar;
                    newcardyes=(rk == 'i' ^ rk == 'I');
                    newcardno = (rk == 'n' ^ rk == 'N');
                   


                    m = m + card; //TODO: Ez nem jó, nem a játék kártya Listjébe kerül az új lap itt is a Generate-et kellene használni
                    Generate(i, cards);
                                  
                    Console.WriteLine($"{i}. játékos lapjai:{m}"); //TODO: mivel az m stringet nem jól állítod elő ezért nem jó lesz a kiírás
                   

                    hit++; //TODO: Ezt rakd át a while feltételbe
                } while (hit < 3 || newcardyes == true );
            }
        }

        /// <summary>
        /// Ebben a metódusban kellene kiíratni a nyerteseket mást nem. Az eredmény kiírása után a readkey nem árt azért, hogy el is lehessen olvasni az eredményt
        /// A Start, a Play ill. az End metódusok hívását majd a főprogram fogja elvégezni.
        /// </summary>
        public void End()
        {
            if (card == 21) //TODO: Ilyen soha nem lesz, itt azt kellene leellenőrizni, hogy cards tömb valamelyik lista elemeinek az összege 21 és ha talál akkor annak az indexét,
                            //v. indexeit kiíratni mint nyertes. Ha nincs 21 akkor azt is le kell ellenőrizni, hogy van e olyan lista elem összeg ami kissebb 21nél de a legnagyobb a 
                            //többi játékos lista elem összegeinél. A teljes ellenőrzést nem itt kellene lefuttatni, hanem az End metódusban
            {
                Console.WriteLine($"{gamercount}. játékos nyert.");
            }
        }
        void Exit()
        {
            char exit;
            bool yes;
            bool no;
            Console.WriteLine("Visszatérés a Főmenübe? (i/n)");
            exit = Console.ReadKey(true).KeyChar;
            yes = (exit == 'i' ^ exit == 'I');
            no = (exit == 'n' ^ exit == 'N');
            if (yes == true) { exit = 'i'; }
            else if (no == true) { exit = 'n'; }
            switch (exit)
            {
                case 'i':
                    g.Kezdes();
                    break;
                case 'n':
                    char newgame;
                    bool y;
                    bool n;
                    Console.WriteLine("Új játék? i/n");
                    newgame = Console.ReadKey(true).KeyChar;
                    y = (newgame == 'i' ^ newgame == 'I');
                    n = (newgame == 'n' ^ newgame == 'N');
                    if (y == true) { newgame = 'i'; }
                    else if (n == true) { newgame = 'n'; }
                    switch (newgame)
                    {
                        case 'i':
                            Start();
                            break;
                        case 'n':
                            End();
                            break;
                    }
                    break;
                default:
                    Exit();
                    break;
            }
        }
    }
}
