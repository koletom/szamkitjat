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

        /// <summary>
        /// Ebben a metódusban kellene kiíratni a nyerteseket mást nem. Az eredmény kiírása után a readkey nem árt azért, hogy el is lehessen olvasni az eredményt
        /// A Start, a Play ill. az End metódusok hívását majd a főprogram fogja elvégezni.
        /// </summary>
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

        //TODO: Ez nem kell
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
                var m = string.Join(",", cards[i]); //TODO: Ezt akár berakhatod a Generate metódusba, annak visszatérési értékeként, és akkor az egész generate hívást  
                                                    //betehed a következő Console...-os sorba

                Console.WriteLine($"{i}. játékos lapjai:{m}"); //TODO: Ez kinézhete akár így is: Console.WriteLine("{0}. játékos lapjai:{1}",i,Generate(i, cards));
                int hit = 0;
                char rk;
                do
                {
                    Console.WriteLine($"{i}. játékos húz-e új lapot? i/n");
                    rk = Console.ReadKey(true).KeyChar;
                    // Le kellene ellenőrizni, hogy csak 'i', 'I', 'n', 'N' karaktereket adott-e meg a felhasználó ha nem ezeket adta akkor újra bekérünk 
                    
                    hit++; //TODO: Ezt rakd át a while feltételbe
                    
                    m = m + card; //TODO: Ez nem jó, nem a játék kártya Listjébe kerül az új lap itt is a Generate-et kellene használni
                                  
                    Console.WriteLine($"{i}. játékos lapjai:{m}"); //TODO: mivel az m stringet nem jól állítod elő ezért nem jó lesz a kiírás
                    Console.WriteLine($"{i}. játékos húz-e új lapot? i/n"); //TODO:Ez nem kell ide

                } while (hit < 3 || rk == 'i');
            }


            if (card == 21) //TODO: Ilyen soha nem lesz, itt azt kellene leellenőrizni, hogy cards tömb valamelyik lista elemeinek az összege 21 és ha talál akkor annak az indexét,
                            //v. indexeit kiíratni mint nyertes. Ha nincs 21 akkor azt is le kell ellenőrizni, hogy van e olyan lista elem összeg ami kissebb 21nél de a legnagyobb a 
                            //többi játékos lista elem összegeinél. A teljes ellenőrzést nem itt kellene lefuttatni, hanem az End metódusban
            {
                Console.WriteLine($"{gamercount}. játékos nyert.");
            }
            
            End(); //TODO:Ezt a metódust nem itt hívjuk hanem majd a játék vezérlő fogja

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

            Play(); //TODO:Ezt a metódust nem itt hívjuk hanem majd a játék vezérlő fogja
        }
    }
}
