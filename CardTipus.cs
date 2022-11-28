using System;

using static szamkitjat.CardSzam;
using static szamkitjat.CardSzin;

namespace szamkitjat
{
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
        }
    }
}