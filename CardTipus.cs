using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjat
{
    
    public class CardTipus
    {

        public enum CardSzam
            {
                Asz = 1,
                Ketto = 2,
                Harom = 3,
                Negy = 4,
                Ot = 5,
                Hat = 6,
                Het = 7,
                Nyolc = 8,
                Kilenc = 9,
                Tiz = 10,
                Jumbo = 11,
                Dama = 12,
                Kiraly = 13
            }

            public enum CardSzin
            {
                Kor,
                Karo,
                Treff,
                Pikk
            }

        public class Card
        {
            public CardSzam Szam { get; }
            public CardSzin Szin { get; }
            public int Ertek { get; set; }

            public Card(CardSzam szam, CardSzin szin)
            {
                Szam = szam;
                Szin = szin;

                switch (Szam)
                {
                    case CardSzam.Tiz:
                    case CardSzam.Jumbo:
                    case CardSzam.Dama:
                    case CardSzam.Kiraly:
                        Ertek = 10;
                        break;
                    case CardSzam.Asz:
                        Ertek = 11;
                        break;
                    default:
                        Ertek = (int)Szam;
                        break;
                }
            }
        
        
       
            public void CardFeltetel()
       
            {
        
                if (Szin == CardSzin.Pikk || Szin == CardSzin.Treff)
       
                {
                    Console.ForegroundColor = ConsoleColor.Black;
           
                }
        
                else
        
                {
           
                    Console.ForegroundColor = ConsoleColor.Red;
     
                }
        
                if (Szam == CardSzam.Asz)
      
                {
              
                    if (Ertek == 11)
                    {

                    }
                    else
                    {

                    }
     
                }
       
            }

        }
    }

}
