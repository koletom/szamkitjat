using System;

using static szamkitjat.CardSzam;
using static szamkitjat.CardSzin;

namespace szamkitjat
{
    public class Szinek
    {
        public static void AlapSzin()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
    }
    
    public enum CardSzam
    {
        Asz,
        Ketto,
        Harom,
        Negy,
        Ot,
        Hat,
        Het,
        Nyolc,
        Kilenc,
        Tiz,
        Jumbo,
        Dama,
        Kiraly
    }

    public enum CardSzin
    {
        Kor,
        Karo,
        Treff,
        Pikk
    }

    public enum CardSzamMagyar
    {
        Also,
        Felso,
        Kiraly,
        Het,
        Nyolc,
        Kilenc,
        Tiz,
        Asz
    }
    public enum CardSzinMagyar
    {
        Piros,
        Tok,
        Makk,
        Zold
    }

    public class CardTipus
    {
        public CardSzam Szam { get; }
        public CardSzin Szin { get; }
        public int Ertek { get; set; }

        public CardTipus(CardSzam szam, CardSzin szin)
        {
            Szam = szam;
            Szin = szin;

            switch (Szin)
            {
                case Kor:
                    break;

                case Karo:
                    break;

                case Treff:
                    break;

                case Pikk:
                    break;
            }

            switch (Szam)
            {
                case Tiz:
                case Jumbo:
                case Dama:
                case Kiraly:
                    Ertek = 10;
                    break;

                case Asz:
                    Ertek = 11;
                    break;

                default:
                    Ertek = (int)Szam + 1;
                    break;
            }
        }

        public void CardFeltetel()
        {
            if (Szin == Pikk || Szin == Treff)

            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            if (Szam == Asz)
            {
                if (Ertek == 11)
                {
                    Console.WriteLine($"{Szin} {Szam} (értéke:11)");
                }
                else
                {
                    Console.WriteLine($"{Szin} {Szam} (értéke:1)");
                }
            }
            else
            {
                Console.WriteLine($"{Szin} {Szam}");
            }
            Szinek.AlapSzin();
        }
    }
    public class CardTipusMagyar
    {
        public CardSzamMagyar SzamM { get; }
        public CardSzinMagyar SzinM { get; }
        public int Ertek { get; set; }
        public CardTipusMagyar(CardSzamMagyar szamM, CardSzinMagyar szinM)
        {
            SzamM = szamM;
            SzinM = szinM;

            switch (SzinM)
            {
                case CardSzinMagyar.Piros:
                    break;

                case CardSzinMagyar.Tok:
                    break;

                case CardSzinMagyar.Makk:
                    break;

                case CardSzinMagyar.Zold:
                    break;
            }

            switch (SzamM)
            {
                
                case CardSzamMagyar.Also:
                    Ertek = 2;
                    break;
                case CardSzamMagyar.Felso:
                    Ertek = 3;
                    break;
                case CardSzamMagyar.Kiraly:
                    Ertek = 4;
                    break;
                case CardSzamMagyar.Het:
                    Ertek = 7;
                    break;
                case CardSzamMagyar.Nyolc:
                    Ertek = 8;
                    break;
                case CardSzamMagyar.Kilenc:
                    Ertek = 9;
                    break;
                case CardSzamMagyar.Tiz:
                    Ertek = 10;
                    break;
                case CardSzamMagyar.Asz:
                    Ertek = 11;
                    break;
            }
        }
        public void CardFeltetelMagyar()
        {
            if (SzinM == CardSzinMagyar.Piros)

            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (SzinM == CardSzinMagyar.Tok)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (SzinM == CardSzinMagyar.Makk)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (SzinM == CardSzinMagyar.Zold)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
                Console.WriteLine($"{SzinM} {SzamM}");
            
            Szinek.AlapSzin();
        }
    }
}