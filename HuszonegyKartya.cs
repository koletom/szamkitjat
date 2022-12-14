using System;
using System.Collections.Generic;
using System.Threading;
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
            Hang.Good();
            Console.Clear();

            string input;
            int p = 0;
            players.Coin = 1000;
            tt = 0;

            Console.WriteLine("\nAz nyer akinél nagyobb száma van vagy előbb lesz 21-e.\nHa valakinek több mint 21 az veszít");
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

            string pakli;
            do
            {
                Console.WriteLine("Válassz kártya paklit.\nMagyar, Francia");
                pakli = Console.ReadLine();

                switch (pakli.ToUpper())
                {
                    case "MAGYAR":
                        Console.Clear();
                        Console.WriteLine("A lapok értéke: \nAlsó: 2 \nFelső: 3 \nKirály: 4 \nSzámozott lapok: (7-10) \nÁsz: 11");
                        break;
                    case "FRANCIA":
                        Console.Clear();
                        Console.WriteLine("A lapok értéke: \nSzámozott lapok: (2-10) \nKirály, Dáma, Bubi: 10 \nÁsz: 1 vagy 11"); 
                        break;
                    default:
                        Console.WriteLine("Lehetséges válaszok:");
                        Console.WriteLine("Magyar, Francia");
                        Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("Nyomj egy gombot a kezdéshez.");
                Console.ReadKey();
            } while (!pakli.ToUpper().Equals("MAGYAR") && !pakli.ToUpper().Equals("FRANCIA"));
            KorKezdes();

        }

        private CardDeck cardDeck = new CardDeck();
        private Players players = new Players();
        private Oszto oszto = new Oszto();

        public enum Vegeredmeny
        {
            BLACKJACK,
            NYERT,
            VESZTETT,
            DONTETLEN,
            SURRENDER,
            BUST,
            //NINCSENTET
        }
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

        public void KezdoKezek()
        {
            cardDeck.Elokeszit();

            players.Hand = cardDeck.KezdoKez();
            oszto.OsztoCards = cardDeck.OsztoKez();

            //nem lehet egyszerre 2 Ász
            if (players.Hand[0].Szam == CardSzam.Asz && players.Hand[1].Szam == CardSzam.Asz)
            {
                players.Hand[1].Ertek = 1;
            }

            if (oszto.OsztoCards[0].Szam == CardSzam.Asz && oszto.OsztoCards[1].Szam == CardSzam.Asz)
            {
                oszto.OsztoCards[1].Ertek = 1;
            }

            players.KezMutat();
            oszto.KezMutat();
        }
        public void KorKezdes()
        {
            Console.Clear();

            if (!Tetek())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Érvénytelten tét");
                HSzinek();
                Console.WriteLine("Nyomj egy gombot az újra próbáláshoz.");
                Console.ReadKey();
                KorKezdes();
                return;
            }

            KezdoKezek();
            Play();

            players.KezMutat();
            oszto.KezMutat();
            if (tt != 1)
            {
                Ellenorzes();
            }
        }

        public void Ellenorzes()
        {
            if (players.KezErtek() > 21)
            {
                KorVege(Vegeredmeny.BUST);
                return;
            }
            while (oszto.OsztoKezErtek() < 17)
            {
                Thread.Sleep(2000);
                oszto.OsztoCards.Add(cardDeck.LapHuzas());

                Console.Clear();
                players.KezMutat();
                oszto.KezMutat();
            }

            if (players.KezErtek() > oszto.OsztoKezErtek())
            {
                if (Blackjack(players.Hand))
                {
                    KorVege(Vegeredmeny.BLACKJACK);
                }
                else
                {
                    KorVege(Vegeredmeny.NYERT);
                }
            }
            else if (oszto.OsztoKezErtek() >= 22)
            {
                KorVege(Vegeredmeny.NYERT);
            }
            else if (oszto.OsztoKezErtek() > players.KezErtek())
            {
                KorVege(Vegeredmeny.VESZTETT);
            }
            else if (oszto.OsztoKezErtek() == players.KezErtek())
            {
                KorVege(Vegeredmeny.DONTETLEN);
            }
        }
        public void Play()
        {
            List<int>[] cards = new List<int>[gamercount];

            //for (int i = 0; i < gamercount; i++)
            //{
            //    Generate(i, cards);
            //    var m = string.Join(",", cards[i]); //TODO: Ezt akár berakhatod a Generate metódusba, annak visszatérési értékeként, és akkor az egész generate hívást  
            //                                        //betehed a következő Console...-os sorba
            

            //Console.WriteLine($"{i}. játékos lapjai:{m}");
            //Console.WriteLine("{0}. játékos lapjai:{1}",i,Generate(i, cards));
            //int hit = 0;

            //bool newcardyes;
            //bool newcardno;

            string rk;
            do
            {
                Console.Clear();
                players.KezMutat();
                oszto.KezMutat();
                Console.WriteLine($"A játékos húz-e új lapot?");
                Console.WriteLine("Válaztási lehetőségek:(Hit, Stop, Surrender, Double)");
                if (tt == 1)
                {
                    rk = "STOP";
                    Console.Clear();
                    Console.WriteLine("Nincs elegendő Coin.");
                    Console.WriteLine("A játéknak vége!");
                    tt = 0;
                }
                else
                {
                    rk = Console.ReadLine();
                }
                //newcardyes=(rk == 'i' ^ rk == 'I');
                //newcardno = (rk == 'n' ^ rk == 'N');
                switch (rk.ToUpper())
                    {
                    case "HIT":
                        players.Hand.Add(cardDeck.LapHuzas());
                        break;
                    case "STOP":
                        break;
                    case "SURRENDER":
                        players.Hand.Clear();
                        KorVege(Vegeredmeny.SURRENDER);
                        break;
                    case "DOUBLE":
                        if (players.Coin <= players.Tet)
                        {
                            players.AddTet(players.Coin);
                        }
                        else
                        {
                            players.AddTet(players.Tet);
                        }
                        players.Hand.Add(cardDeck.LapHuzas());
                        break;
                    default:
                        Console.WriteLine("Válaztási lehetőségek:(Hit, Stop, Surrender, Double)");
                        Console.WriteLine("Nyomj egy gombot az új próbához.");
                        Console.ReadKey();
                        break;
                }
                

                if (players.KezErtek() > 21)
                        {
                            foreach (CardTipus card in players.Hand)
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

                //hit++; //TODO: Ezt rakd át a while feltételbe

            } while (!rk.ToUpper().Equals("STOP") && !rk.ToUpper().Equals("SURREDER") 
                && !rk.ToUpper().Equals("DOUBLE") && players.KezErtek() <= 21); /*while (hit < 3 || newcardyes == true );*/
                //}
        }

        public static int MinimumKezdoTet { get; } = 5;
        public bool Tetek()
        {
            Console.Write("Jelnlegi Coin-ok száma:");
            Console.WriteLine(players.Coin);
            Console.WriteLine(); 
            
            Console.WriteLine("Minimum tét: ");
            Console.WriteLine(MinimumKezdoTet);
            Console.WriteLine();

            Console.WriteLine("Kérem a téteket:");
            string s = Console.ReadLine();
            if (Int32.TryParse(s, out int tet) && tet >= MinimumKezdoTet && players.Coin >= tet)
            {
                players.AddTet(tet);
                return true;
            }
            return false;
        }
        public static void HSzinek()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        int tt = 0;
        public void KorVege(Vegeredmeny vegeredmeny)
        {
            Thread.Sleep(1000);
            switch (vegeredmeny)
            {
                case Vegeredmeny.BUST:
                    players.TetNullaz();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Játékos vesztett! \nA játékos túl sok lapot húzott");
                    HSzinek();
                    Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    if (players.Coin > 4)
                    {
                        KorKezdes();
                    }
                    else if (players.Coin <= 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nincsen a kezdőtéthez elegendő Coin.");
                        Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                        Console.ReadKey();
                        tt = 1;
                        End();
                    }
                    break;
                case Vegeredmeny.SURRENDER:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Játékos feladta.");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("A Játékos "+ (players.Tet / 2) + " Coint visszakap.");
                    HSzinek();
                    players.Coin = players.Coin+players.Tet / 2;
                    players.TetNullaz();
                    Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    KorKezdes();
                    break;
                case Vegeredmeny.BLACKJACK:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Blackjack. Játékos nyert. Nyeremény:" + players.TetNyer(true) +" Coin.");
                    HSzinek();
                    Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    players.TetNullaz();
                    KorKezdes();
                    break;
                case Vegeredmeny.NYERT:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Játékos nyert. Nyeremény:" + players.TetNyer(false) + " Coin.");
                    HSzinek();
                    Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    players.TetNullaz();
                    KorKezdes();
                    break;
                case Vegeredmeny.VESZTETT:
                    players.TetNullaz();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Osztó nyert");
                    HSzinek();
                    Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    if (players.Coin > 4)
                    {
                        KorKezdes();
                    }
                    else if (players.Coin <= 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nincsen a kezdőtéthez elegendő Coin.");
                        Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                        Console.ReadKey();
                        tt = 1;
                        End();
                    }
                    break;
                case Vegeredmeny.DONTETLEN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Döntetlen"); 
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("A Játékos " + (players.Tet) + " Coint visszakap.");
                    HSzinek();
                    players.TetVisszakap();
                    players.TetNullaz();
                    Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
                    Console.ReadKey();
                    KorKezdes();
                    break;
                default:
                    Console.WriteLine("Hiba történt!");
                    break;
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
            if (players.Coin > 4)
            {
                KorKezdes();
            }
            else
            {
            }

            //if (card == 21) //TODO: Ilyen soha nem lesz, itt azt kellene leellenőrizni, hogy cards tömb valamelyik lista elemeinek az összege 21 és ha talál akkor annak az indexét,
            //                //v. indexeit kiíratni mint nyertes. Ha nincs 21 akkor azt is le kell ellenőrizni, hogy van e olyan lista elem összeg ami kissebb 21nél de a legnagyobb a 
            //                //többi játékos lista elem összegeinél. A teljes ellenőrzést nem itt kellene lefuttatni, hanem az End metódusban
            //{
            //    Console.WriteLine($"{gamercount}. játékos nyert.");
            //}
        }
    }
}
