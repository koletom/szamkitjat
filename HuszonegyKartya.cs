using System;
using System.Collections.Generic;
using System.Threading;
using szamkitjatiterfaces;

namespace szamkitjat
{
    //TODO: https://hu.wikipedia.org/wiki/Huszonegy e szerint működjön
    public class HuszonegyKartya : IGame
    {
        private IGameUI _gameUI;
        public HuszonegyKartya(IGameUI gameUI)
        {
            _gameUI = gameUI ?? throw new NullReferenceException();
        }
        #region propertiregion
        private int gamercount { get; set; }
        public string Name => "Huszonegy";
        #endregion propertiregion

        public void Start()
        {
            _gameUI.Sound(SoundTipes.Good);
            _gameUI.Clear(ConsoleColor.White, ConsoleColor.Black);

            string input;
            int p = 0;
            players.Coin = 1000;
            tt = 0;

            _gameUI.PrintLN("\nAz nyer akinél nagyobb száma van vagy előbb lesz 21-e.\nHa valakinek több mint 21 az veszít");
            do
            {
                bool isValid;
                int? number;
                _gameUI.PrintLN("Adja meg a játékosok számát (max 5)");
                number = (int?)_gameUI.ReadNumber();
                _gameUI.Sound(SoundTipes.Step);
                if (number is null)
                {
                    _gameUI.PrintLN("A beírt szöveg men egy szám!");
                }
                _gameUI.PrintLN("Játékosok száma 1-5 -ig szám lehet");
                if (number is null)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                    p = (int)number;
                }
                
                //input = _gameUI.ReadLine;
                //if (!int.TryParse(input, out p))
                //{

                //    _gameUI.PrintLN("Játékosok száma 1-5 -ig szám lehet");
                //}
            } while (p < 1 || p > 5);
            gamercount = p;

            string pakli;
            do
            {
                _gameUI.Clear();
                _gameUI.PrintLN("Válassz kártya paklit.\nMagyar, Francia");
                pakli = _gameUI.ReadLine;
                _gameUI.Sound(SoundTipes.Step);

                switch (pakli.ToUpper())
                {
                    case "MAGYAR":
                        _gameUI.Clear();
                        _gameUI.PrintLN($"Választott pakli: {pakli}");
                        _gameUI.PrintLN("A lapok értéke: \nAlsó: 2 \nFelső: 3 \nKirály: 4 \nSzámozott lapok: (7-10) \nÁsz: 11");
                        _gameUI.PrintLN("\nA játékszabályok: Ha valakinél 2 Ász van nyet.\nAz nyer akinél nagyobb száma van vagy előbb lesz 21-e\nAz osztó 14 értékig húz lapot.");
                        _gameUI.PrintLN("\nHa valakinek több van mint 21 vesztett!\nHa az osztó és játékos lapjainak értéke egyenlő a játékos vesztett!");
                        players.DeckTipeP = 2;
                        oszto.DeckTipeO = 2;
                        break;
                    case "FRANCIA":
                        _gameUI.Clear();
                        _gameUI.PrintLN($"Választott pakli: {pakli}");
                        _gameUI.PrintLN("A lapok értéke: \nSzámozott lapok: (2-10) \nKirály, Dáma, Bubi: 10 \nÁsz: 1 vagy 11");
                        _gameUI.PrintLN("\nA játékszabályok: \nAz nyer akinél nagyobb száma van vagy előbb lesz 21-e\nAz osztó 17 értékig húz lapot.");
                        _gameUI.PrintLN("\nHa valakinek több van mint 21 vesztett!\nHa az osztó és játékos lapjainak értéke egyenlő a játékos visszakapja a tétet!");
                        players.DeckTipeP = 1;
                        oszto.DeckTipeO = 1;
                        break;
                    default:
                        _gameUI.PrintLN($"Választott pakli: '{pakli}' nincs a lehetséges válaszok között.");
                        _gameUI.PrintLN("Lehetséges válaszok:");
                        _gameUI.PrintLN("Magyar, Francia");
                        _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                        _gameUI.ReadKey();
                        break;
                }
            } while (!pakli.ToUpper().Equals("MAGYAR") && !pakli.ToUpper().Equals("FRANCIA"));

            _gameUI.PrintLN($"\nA játékot {p} darab játékos játsza {pakli} kártyával.");
            _gameUI.PrintLN("\nKezdődjön a játék!");
            _gameUI.PrintLN("Nyomj egy gombot a kezdéshez.");
            _gameUI.ReadKey();
            _gameUI.Sound(SoundTipes.Good);
            //KorKezdes();
        }

        

        private CardDeck cardDeck = new CardDeck();
        private CardDeckMagyar cardDeckMagyar = new CardDeckMagyar();
        private Players players = new Players();
        private Oszto oszto = new Oszto();

        public enum Vegeredmeny
        {
            WIN,
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


        private void Generate(int gamernum, List<int>[] gamercards)
        {
            //gamercards[gamernum].Add(card);
            //if (gamercards[gamernum].Count < 2)
            //{
            //    gamercards[gamernum].Add(card);
            //}
        }

        public void KezdoKezek()
        {
            if (players.DeckTipeP == 1)
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

            }
            else if (players.DeckTipeP == 2)
            {
                cardDeck.Elokeszit();

                players.HandM = cardDeckMagyar.KezdoKez();
                oszto.OsztoCardsM = cardDeckMagyar.OsztoKez();
            }

            players.KezMutat();
            oszto.KezMutat();
        }
        //public void KorKezdes()                   //KorKezdes() -t át kell alakítani
        //{
        //    //_gameUI.Clear(ConsoleColor.DarkBlue, ConsoleColor.Cyan);

        //    //if (!Tetek())
        //    //{
        //    //    _gameUI.PrintLN("Érvénytelten tét", ConsoleColor.Red);
        //    //    HSzinek();
        //    //    _gameUI.PrintLN("Nyomj egy gombot az újra próbáláshoz.");
        //    //    _gameUI.ReadKey();
        //    //    KorKezdes();
        //    //    return;
        //    //}

        //    //KezdoKezek();
        //    Play();                   //Play() -t át kell alakítani

        //    //players.KezMutat();
        //    //oszto.KezMutat();
        //    //if (tt != 1)
        //    //{
        //    //    if (players.DeckTipeP == 1)
        //    //    {
        //    //        Ellenorzes();
        //    //    }
        //    //    else if (players.DeckTipeP == 2)
        //    //    {
        //    //        EllenorzesM();
        //    //    }
        //    //}
        //}
        
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

                _gameUI.Clear();
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
        public void EllenorzesM()
        {
            if (oszto.OsztoKezErtek() == 22)
            {
                KorVege(Vegeredmeny.VESZTETT);
                return;
            }

            else if (players.KezErtek() == 22)
            {
                KorVege(Vegeredmeny.WIN);
                return;
            }

            else if (players.KezErtek() > 21)
            {
                KorVege(Vegeredmeny.BUST);
                return;
            }

            while (oszto.OsztoKezErtek() < 14)
            {
                Thread.Sleep(2000);
                oszto.OsztoCardsM.Add(cardDeckMagyar.LapHuzas());

                _gameUI.Clear();
                players.KezMutat();
                oszto.KezMutat();
            }

            if (players.KezErtek() > oszto.OsztoKezErtek())
            {
                if (BlackjackM(players.HandM))
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
                KorVege(Vegeredmeny.VESZTETT);
            }
        }
        public void Play()
        {
            do
                {
                _gameUI.Clear(ConsoleColor.DarkBlue, ConsoleColor.Cyan);

                if (!Tetek())
                {
                    _gameUI.Sound(SoundTipes.Bad);
                    _gameUI.PrintLN("Érvénytelten tét", ConsoleColor.Red);
                    HSzinek();
                    _gameUI.PrintLN("Nyomj egy gombot az újra próbáláshoz.");
                    _gameUI.ReadKey();

                    tt = 1;
                }

                List<int>[] cards = new List<int>[gamercount];

                KezdoKezek();

                string rk;
                do
                {
                    _gameUI.Clear();
                    players.KezMutat();
                    oszto.KezMutat();
                    _gameUI.PrintLN($"A játékos húz-e új lapot?");
                    _gameUI.PrintLN("Válaztási lehetőségek:(Hit, Stop, Surrender, Double)");
                    if (tt == 1)
                    {
                        rk = "STOP";
                    
                        tt = 0;
                        //End();
                    }
                    else
                    {
                        rk = _gameUI.ReadLine;
                    }
                    //newcardyes=(rk == 'i' ^ rk == 'I');
                    //newcardno = (rk == 'n' ^ rk == 'N');
                    switch (rk.ToUpper())
                        {
                        case "HIT":
                            if (players.DeckTipeP == 1)
                            {
                                players.Hand.Add(cardDeck.LapHuzas());
                            }
                            else if (players.DeckTipeP == 2)
                            {
                                players.HandM.Add(cardDeckMagyar.LapHuzas());
                            }
                            break;
                        case "STOP":
                            break;
                        case "SURRENDER":
                            if (players.DeckTipeP == 1)
                            {
                                players.Hand.Clear();
                            }
                            else if (players.DeckTipeP == 2)
                            {
                                players.HandM.Clear();
                            }
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
                            if (players.DeckTipeP == 1)
                            {
                                players.Hand.Add(cardDeck.LapHuzas());
                            }
                            else if (players.DeckTipeP == 2)
                            {
                                players.HandM.Add(cardDeckMagyar.LapHuzas());
                            }
                            break;
                        default:
                            _gameUI.PrintLN("Válaztási lehetőségek:(Hit, Stop, Surrender, Double)");
                            _gameUI.PrintLN("Nyomj egy gombot az új próbához.");
                            _gameUI.ReadKey();
                            break;
                    }
                

                    if (players.KezErtek() > 21)
                    {
                        if (players.DeckTipeP == 1)
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
                        else if (players.DeckTipeP == 2)
                        {
                            foreach (CardTipusMagyar card in players.HandM)
                            {
                                if (card.Ertek == 11)
                                {
                                    card.Ertek = 11;
                                    break;
                                }
                            }
                        }
                    }
                

                    //m = m + card; //TODO: Ez nem jó, nem a játék kártya Listjébe kerül az új lap itt is a Generate-et kellene használni
                    //Generate(i, cards);

                    //Console.WriteLine($"{i}. játékos lapjai:{m}"); //TODO: mivel az m stringet nem jól állítod elő ezért nem jó lesz a kiírás

                    //hit++; //TODO: Ezt rakd át a while feltételbe

                } while (!rk.ToUpper().Equals("STOP") && !rk.ToUpper().Equals("SURRENDER") 
                    && !rk.ToUpper().Equals("DOUBLE") && players.KezErtek() <= 21); /*while (hit < 3 || newcardyes == true );*/
                //}
            
                players.KezMutat();
                oszto.KezMutat();
                if (tt != 1)
                {
                    if (players.Tet != 0)
                    {
                        if (players.DeckTipeP == 1)
                        {
                            Ellenorzes();
                        }
                        else if (players.DeckTipeP == 2)
                        {
                            EllenorzesM();
                        }
                    }
                }
            } while (players.Coin > 4);
        }

        public static int MinimumKezdoTet { get; } = 5;
        public bool Tetek()
        {
            _gameUI.Print("Jelnlegi Coin-ok száma:");
            _gameUI.PrintLN($"{players.Coin}");
            _gameUI.PrintLN("");

            _gameUI.Print("Minimum tét: ");
            _gameUI.PrintLN($"{MinimumKezdoTet}");
            _gameUI.PrintLN("");

            _gameUI.PrintLN("Kérem a téteket:");

            //string s = _gameUI.ReadLine;
            int? number;
            number = (int?)_gameUI.ReadNumber();
            if (number is null)
            {
                _gameUI.PrintLN($"A beírt adat nem egy szám!");
                return false;
            }
            int tet = (int)number;
            
            if (/*Int32.TryParse(s, out int tet) && */tet >= MinimumKezdoTet && players.Coin >= tet)
            {
                players.AddTet(tet);
                return true;
            }
            return false;
        }
        public void HSzinek()
        {
            _gameUI.PrintLN("", ConsoleColor.DarkBlue, ConsoleColor.Cyan);
        }
        private int tt = 0;
        public void KorVege(Vegeredmeny vegeredmeny)
        {
            Thread.Sleep(1000);
            switch (vegeredmeny)
            {
                case Vegeredmeny.BUST:
                    players.TetNullaz();
                    _gameUI.PrintLN("A Játékos vesztett! \nA játékos túl sok lapot húzott", ConsoleColor.Red);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Bad);
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();
                    //if (players.Coin > 4)
                    //{
                    //    //KorKezdes();
                    //}
                    if (players.Coin <= 4)
                    {
                        //_gameUI.PrintLN("");
                        //_gameUI.PrintLN("Nincsen a kezdőtéthez elegendő Coin.");
                        //_gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                        //_gameUI.ReadKey();
                        tt = 1;
                        //End();
                    }
                    break;
                case Vegeredmeny.SURRENDER:
                    _gameUI.PrintLN("A Játékos feladta.", ConsoleColor.Red);
                    _gameUI.PrintLN("A Játékos "+ (players.Tet / 2) + " Coint visszakap.",ConsoleColor.DarkGreen);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Bad);
                    players.Coin = players.Coin+players.Tet / 2;
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();
                    players.TetNullaz();
                    //KorKezdes();
                    break;
                case Vegeredmeny.WIN:
                    _gameUI.PrintLN("A Játékos 2 Ászt húzott. Játékos nyert. Nyeremény:" + players.TetNyer(true) + " Coin.", ConsoleColor.DarkGreen);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Good);
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();
                    players.TetNullaz();
                    //KorKezdes();
                    break;
                case Vegeredmeny.BLACKJACK:
                    _gameUI.PrintLN("Blackjack. Játékos nyert. Nyeremény:" + players.TetNyer(true) +" Coin.", ConsoleColor.DarkGreen);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Win);
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();
                    players.TetNullaz();
                    //KorKezdes();
                    break;
                case Vegeredmeny.NYERT:
                    _gameUI.PrintLN("Játékos nyert. Nyeremény:" + players.TetNyer(false) + " Coin.", ConsoleColor.DarkGreen);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Win);
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();
                    players.TetNullaz();
                    //KorKezdes();
                    break;
                case Vegeredmeny.VESZTETT:
                    players.TetNullaz();
                    _gameUI.PrintLN("Osztó nyert", ConsoleColor.Red);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Bad);
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();

                    if (players.Coin <= 4)
                    {
                        //_gameUI.PrintLN("");
                        //_gameUI.PrintLN("Nincsen a kezdőtéthez elegendő Coin.");
                        //_gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                        //_gameUI.ReadKey();
                        tt = 1;
                        //End();
                    }
                    break;
                case Vegeredmeny.DONTETLEN:
                    _gameUI.PrintLN("Döntetlen", ConsoleColor.Yellow);
                    _gameUI.PrintLN("A Játékos " + (players.Tet) + " Coint visszakap.", ConsoleColor.DarkGreen);
                    HSzinek();
                    _gameUI.Sound(SoundTipes.Tie);
                    players.TetVisszakap();
                    players.TetNullaz();
                    _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
                    _gameUI.ReadKey();
                    //KorKezdes();
                    break;
                default:
                    _gameUI.PrintLN("Hiba történt!");
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
        public static bool BlackjackM(List<CardTipusMagyar> kez)
        {
            if (kez.Count == 2)
            {
                if (kez[0].SzamM == CardSzamMagyar.Asz && kez[1].Ertek == 10)
                {
                    return true;
                }
                else if (kez[1].SzamM == CardSzamMagyar.Asz && kez[0].Ertek == 10)
                {
                    return true;
                }
            }
            return false;
        }
        //public static bool BlackjackM2(List<CardTipusMagyar> kez)
        //{
        //    if (kez.Count == 2)
        //    {
        //        if (kez[0].SzamM == CardSzamMagyar.Asz && kez[1].SzamM == CardSzamMagyar.Asz)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Ebben a metódusban kellene kiíratni a nyerteseket mást nem. Az eredmény kiírása után a readkey nem árt azért, hogy el is lehessen olvasni az eredményt
        /// A Start, a Play ill. az End metódusok hívását majd a főprogram fogja elvégezni.
        /// </summary>
        public void End()
        {
            _gameUI.Sound(SoundTipes.Lose);
            _gameUI.Clear(ConsoleColor.Black, ConsoleColor.White);
            _gameUI.PrintLN("Nincs elegendő Coin.");
            _gameUI.PrintLN("A játéknak vége!");
            _gameUI.PrintLN("Nyomj egy gombot a folytatáshoz.");
            _gameUI.ReadKey();
            _gameUI.PrintLN("");
            if (players.Coin > 4)
            {
                //KorKezdes();
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
