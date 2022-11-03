using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjat
{
    
    public class CardTipus
    {
        CardErtek cardErtek;
        CardSzin szin;

        public CardErtek Ertek
        {
            get { return this.cardErtek; }
        }
        public CardSzin Szin
        {
            get { return this.szin; }
        }
        //public Card()
        //{
        //    cardErtek = 0;
        //    szin = 0;
        //}

        public enum CardErtek
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
                Kor = 1,
                Karo = 2,
                Treff = 3,
                Pikk = 4
            }
            
    }
    
}
