using System;
using System.Collections.Generic;
using szamkitjatiterfaces;

namespace szamkitjat
{
    //TODO: https://hu.wikipedia.org/wiki/Huszonegy e szerint működjön
    class HuszonegyKartya : IGame
    {
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "Huszonegy";
        #endregion propertiregion


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
        private static Players players = new Players();
        //int card
        //{
        //    get
        //    {
        //        Random num = new Random();
        //        return num.Next(1, 10);
        //    }
        //} 



        void Generate(int gamernum, List<int>[] gamercards)
        {
            //gamercards[gamernum].Add(card);
            //if (gamercards[gamernum].Count < 2)
            //{
            //    gamercards[gamernum].Add(card);
            //}
        }

        static void KezdoKezek()
        {
            cardDeck.Elokeszit();

            Players.Hand = cardDeck.KezdoKez();
            Oszto.OsztoCards = cardDeck.OsztoKez();

            //nem lehet egyszerre 2 Ász
            if (Players.Hand[0].Szam == CardSzam.Asz && Players.Hand[1].Szam == CardSzam.Asz)
            {
                Players.Hand[1].Ertek = 1;
            }

            if (Oszto.OsztoCards[0].Szam == CardSzam.Asz && Oszto.OsztoCards[1].Szam == CardSzam.Asz)
            {
                Oszto.OsztoCards[1].Ertek = 1;
            }

            Players.KezMutat();
            Oszto.KezMutat();
        }
        public void KorKezdes()
        {
            Console.Clear();

            if (!Tet())
            {
                KorVege(Vegeredmeny.NINCSENTET);
                return;
            }

            KezdoKezek();
            Play();

            Players.KezMutat();
            Oszto.KezMutat();

            if (Players.KezErtek()>21)
            {
                KorVege(Vegeredmeny.VESZTETT);
                return;
            }
            while (Oszto.OsztoKezErtek()<17)
            {
                Oszto.OsztoCards.Add(cardDeck.LapHuzas());
            }
            Players.KezMutat();
            Oszto.KezMutat();

            if (Players.KezErtek() > Oszto.OsztoKezErtek())
            {
                if (Blackjack(Players.Hand))
                {
                    KorVege(Vegeredmeny.BLACKJACK);
                }
                else
                {
                    KorVege(Vegeredmeny.NYERT);
                }
            }
            else if (Oszto.OsztoKezErtek() > 21)
            {
                KorVege(Vegeredmeny.NYERT);
            }
            else if (Oszto.OsztoKezErtek() > Players.KezErtek())
            {
                KorVege(Vegeredmeny.VESZTETT);
            }
            else if (Oszto.OsztoKezErtek() == Players.KezErtek())
            {
                KorVege(Vegeredmeny.DONTETLEN);
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
            

            Console.WriteLine($"{i}. játékos lapjai:{m}");
            //Console.WriteLine("{0}. játékos lapjai:{1}",i,Generate(i, cards));
            int hit = 0;

            //bool newcardyes;
            //bool newcardno;

            Console.Clear();
            Players.KezMutat();
            Oszto.KezMutat();

            string rk;
            do
                    {
                        Console.Clear();
                        Console.WriteLine($"{i}. játékos húz-e új lapot?");
                        Console.WriteLine("Válaztási lehetőségek:(Hit, Stop)");
                        rk = Console.ReadLine();
                        //newcardyes=(rk == 'i' ^ rk == 'I');
                        //newcardno = (rk == 'n' ^ rk == 'N');
                        switch (rk.ToUpper())
                        {
                            case "HIT":
                                Players.Hand.Add(cardDeck.LapHuzas());
                                break;
                            case "STOP":
                                break;
                            default:
                                Console.WriteLine("Válaztási lehetőségek:(Hit, Stop)");
                                Console.ReadKey();
                                break;
                        }

                        if (Players.KezErtek() >21)
                        {
                            foreach (CardTipus card in Players.Hand)
                            {
                                if (card.Ertek == 11)
                                {
                                    card.Ertek = 1;
                                    break;
                                }
                            }
                        }

                    //m = m + card; //TODO: Ez nem jó, nem a játék kártya Listjébe kerül az új lap itt is a Generate-et kellene használni
                    //Generate(i, cards);

                    //Console.WriteLine($"{i}. játékos lapjai:{m}"); //TODO: mivel az m stringet nem jól állítod elő ezért nem jó lesz a kiírás


                    hit++; //TODO: Ezt rakd át a while feltételbe
                } while (!rk.ToUpper().Equals("STOP") && Players.KezErtek() <= 21); /*while (hit < 3 || newcardyes == true );*/
            }
        }

        public static int MinimumKezdoTet { get; } = 5;
        static bool Tet()
        {
            Console.WriteLine("Kérem a téteket:");
            string s = Console.ReadLine();
            if (Int32.TryParse(s, out int tet) && tet >= MinimumKezdoTet)
            {
                players.AddTet(tet);
                return true;
            }
            return false;
        }

        private enum Vegeredmeny
        {
            BLACKJACK,
            NYERT,
            VESZTETT,
            DONTETLEN,
            SURRENDER,
            BUST,
            NINCSENTET
        }

        static void KorVege(Vegeredmeny vegeredmeny)
        {
            switch (vegeredmeny)
            {
                case Vegeredmeny.BUST:
                    players.TetNullaz();
                    break;
                case Vegeredmeny.SURRENDER:
                    Console.WriteLine("A Játékos feladta. A Játékos "+ (players.Tet / 2) + " Coint visszakap.");
                    players.Coin = players.Tet / 2;
                    players.TetNullaz();
                    break;
                case Vegeredmeny.BLACKJACK:
                    Console.WriteLine("Blackjack. Játékos nyert. Nyeremény:" + players.TetNyer(true) +"Coin.");
                    break;
                case Vegeredmeny.NYERT:
                    Console.WriteLine("Játékos nyert. Nyeremény:" + players.TetNyer(false) + "Coin.");
                    break;
                case Vegeredmeny.VESZTETT:
                    Console.WriteLine("Osztó nyert");
                    break;
                case Vegeredmeny.DONTETLEN:
                    players.TetVisszakap();
                    Console.WriteLine("Döntetlen");
                    break;
                default:
                    Console.WriteLine("Hiba történt!");
                    break;
            }

            if (players.Coin<=4)
            {
                Console.WriteLine("Nincsen a kezdőtéhez elegendő Coin. Coin");
            }
        }

        public static bool Blackjack(List<CardTipus> kez)
        {
            if (kez.Count == 2)
            {
                if (kez[0].Szam == CardSzam.Asz && kez[1].Ertek == 10)
                {
                    return true;
                }
                else if (kez[1].Szam == CardSzam.Asz && kez[0].Ertek == 10)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Ebben a metódusban kellene kiíratni a nyerteseket mást nem. Az eredmény kiírása után a readkey nem árt azért, hogy el is lehessen olvasni az eredményt
        /// A Start, a Play ill. az End metódusok hívását majd a főprogram fogja elvégezni.
        /// </summary>
        public void End()
        {
            

            //if (card == 21) //TODO: Ilyen soha nem lesz, itt azt kellene leellenőrizni, hogy cards tömb valamelyik lista elemeinek az összege 21 és ha talál akkor annak az indexét,
            //                //v. indexeit kiíratni mint nyertes. Ha nincs 21 akkor azt is le kell ellenőrizni, hogy van e olyan lista elem összeg ami kissebb 21nél de a legnagyobb a 
            //                //többi játékos lista elem összegeinél. A teljes ellenőrzést nem itt kellene lefuttatni, hanem az End metódusban
            //{
            //    Console.WriteLine($"{gamercount}. játékos nyert.");
            //}
        }
    }
}
