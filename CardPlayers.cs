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

        public List<CardTipus> Hand { get; set; }

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

            Coin += nyeremeny;
            TetNullaz();
            return nyeremeny;
        }

        public int KezErtek()
        {
            int ertek = 0;
            foreach (CardTipus card in Hand)
            {
                ertek += card.Ertek;
            }
            return ertek;
        }

        public void KezMutat()
        {
            Console.WriteLine($"Kézben levő lapok értéke: {KezErtek()}");
        }
    }
    public class Oszto
    {
        public static List<CardTipus> OsztoCards { get; set; } = new List<CardTipus>();

        public static int OsztoKezErtek()
        {
            int ertek = 0;
            foreach (CardTipus card in OsztoCards)
            {
                ertek += card.Ertek;
            }
            return ertek;
        }

        public static void KezMutat()
        {
            Console.WriteLine($"Osztó kezében levő lapok értéke: {OsztoKezErtek()}");
        }
    }

}
