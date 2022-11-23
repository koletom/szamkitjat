﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjat
{
    public class Players
    {
        public static List<CardTipus> Hand { get; set; }

        public static int KezErtek()
        {
            int ertek = 0;
            foreach (CardTipus card in Hand)
            {
                ertek += card.Ertek;
            }
            return ertek;
        }

        public static void KezMutat()
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