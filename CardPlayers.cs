using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjat
{
    public class Players
    {
        public static int MinimumTet { get; } = 10;
        public int Coin { get; set; } = 1000;
        public int Tet { get; set; }
        public int DeckTipeP { get; set; } = 0;

        public List<CardTipus> Hand { get; set; }
        public List<CardTipusMagyar> HandM { get; set; }

        public void AddTet(int tet)
        {
            Tet += tet;
            Coin -= tet;
        }

        public void TetNullaz()
        {
            Tet = 0;
        }

        public void TetVisszakap()
        {
            Coin += Tet;
            TetNullaz();
        }

        public int TetNyer(bool blackjack)
        {
            int nyeremeny;
            if (blackjack)
            {
                nyeremeny = Tet * 3;
            }
            else
            {
                nyeremeny = Tet * 2;
            }

            Coin = Coin+nyeremeny;
            TetNullaz();
            return nyeremeny;
        }

        public int KezErtek()
        {
            int ertek = 0;
            if (DeckTipeP == 1)
            {
                foreach (CardTipus card in Hand)
                {
                    ertek += card.Ertek;
                }
                return ertek;
            }
            else if (DeckTipeP == 2)
                {
                    foreach (CardTipusMagyar card in HandM)
                    {
                        ertek += card.Ertek;
                    }
                    return ertek;
            }
            return ertek;
        }

        public void KezMutat()
        {
            Console.Write("Tét: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Tet + " ");
            Szinek.AlapSzin();
            Console.Write("Coin: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Coin + " ");
            Szinek.AlapSzin();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Kézben levő lapok értéke: {KezErtek()}");

            if (DeckTipeP == 1)
            {
                foreach (CardTipus cardTipus in Hand)
                {
                    cardTipus.CardFeltetel();
                }
                Console.WriteLine();
            }
            else if (DeckTipeP == 2)
            {
                foreach (CardTipusMagyar cardTipusMagyar in HandM)
                {
                    cardTipusMagyar.CardFeltetelMagyar();
                }
                Console.WriteLine();
            }
        }
    }
    public class Oszto
    {
        public int DeckTipeO { get; set; } = 0;

        public List<CardTipus> OsztoCards { get; set; } = new List<CardTipus>();
        public List<CardTipusMagyar> OsztoCardsM { get; set; } = new List<CardTipusMagyar>();

        public int OsztoKezErtek()
        {
            int ertek = 0;
            if (DeckTipeO == 1)
            {
                foreach (CardTipus card in OsztoCards)
                {
                    ertek += card.Ertek;
                }
                return ertek;
            }
            else if (DeckTipeO == 2)
            {
                foreach (CardTipusMagyar card in OsztoCardsM)
                {
                    ertek += card.Ertek;
                }
                return ertek;
            }
            return ertek;
        }

        public void KezMutat()
        {
            Console.WriteLine($"Osztó kezében levő lapok értéke: {OsztoKezErtek()}");
            if (DeckTipeO == 1)
            {
                foreach (CardTipus cardTipus in OsztoCards)
                {
                    cardTipus.CardFeltetel();
                }
                Console.WriteLine();
            }
            else if (DeckTipeO == 2)
            {
                foreach (CardTipusMagyar cardTipusMagyar in OsztoCardsM)
                {
                    cardTipusMagyar.CardFeltetelMagyar();
                }
                Console.WriteLine();
            }
        }
    }

}
