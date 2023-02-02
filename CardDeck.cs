using System;
using System.Collections.Generic;

namespace szamkitjat
{
    public class CardDeck
    {
        private List<CardTipus> cards;

        public CardDeck()
        {
            Elokeszit();
        }

        public List<CardTipus> UjPakli()
        {
            List<CardTipus> ujPakli = new List<CardTipus>();

            for (int i = 0; i < 13; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    ujPakli.Add(new CardTipus((CardSzam)i, (CardSzin)k));
                }
            }
            return ujPakli;
        }

        public void Keveres()
        {
            Random kever = new Random();

            int a = cards.Count;
            while (a > 1)
            {
                a--;
                int z = kever.Next(a + 1);
                CardTipus card = cards[z];
                cards[z] = cards[a];
                cards[a] = card;
            }
        }

        public List<CardTipus> KezdoKez() //Kezdő kéz 2 lappal
        {
            if (cards.Count <= 1)
            {
                Elokeszit();
            }

            List<CardTipus> kez = new List<CardTipus>();
            kez.Add(cards[0]);
            kez.Add(cards[1]);

            cards.RemoveRange(0, 2);

            return kez;
        }

        public List<CardTipus> OsztoKez() //Osztó kéz 2 lappal
        {
            if (cards.Count <= 1)
            {
                Elokeszit();
            }

            List<CardTipus> kez = new List<CardTipus>();
            kez.Add(cards[0]);
            kez.Add(cards[1]);

            cards.RemoveRange(0, 2);

            return kez;
        }

        public CardTipus LapHuzas()
        {
            if (cards.Count <= 0)
            {
                Elokeszit();
            }

            CardTipus card = cards[0];

            cards.Remove(card);

            return card;
        }

        public void Elokeszit()
        {
            cards = UjPakli();
            Keveres();
        }
    }

    public class CardDeckMagyar
    {
        private List<CardTipusMagyar> cards;

        public CardDeckMagyar()
        {
            Elokeszit();
        }

        public List<CardTipusMagyar> UjPakli()
        {
            List<CardTipusMagyar> ujPakli = new List<CardTipusMagyar>();

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    ujPakli.Add(new CardTipusMagyar((CardSzamMagyar)i, (CardSzinMagyar)k));
                }
            }
            return ujPakli;
        }

        public void Keveres()
        {
            Random kever = new Random();

            int a = cards.Count;
            while (a > 1)
            {
                a--;
                int z = kever.Next(a + 1);
                CardTipusMagyar card = cards[z];
                cards[z] = cards[a];
                cards[a] = card;
            }
        }

        public List<CardTipusMagyar> KezdoKez() //Kezdő kéz 2 lappal
        {
            if (cards.Count <= 1)
            {
                Elokeszit();
            }

            List<CardTipusMagyar> kez = new List<CardTipusMagyar>();
            kez.Add(cards[0]);
            kez.Add(cards[1]);

            cards.RemoveRange(0, 2);

            return kez;
        }

        public List<CardTipusMagyar> OsztoKez() //Osztó kéz 2 lappal
        {
            if (cards.Count <= 1)
            {
                Elokeszit();
            }

            List<CardTipusMagyar> kez = new List<CardTipusMagyar>();
            kez.Add(cards[0]);
            kez.Add(cards[1]);

            cards.RemoveRange(0, 2);

            return kez;
        }

        public CardTipusMagyar LapHuzas()
        {
            if (cards.Count <= 0)
            {
                Elokeszit();
            }

            CardTipusMagyar card = cards[0];

            cards.Remove(card);

            return card;
        }

        public void Elokeszit()
        {
            cards = UjPakli();
            Keveres();
        }
    }
}