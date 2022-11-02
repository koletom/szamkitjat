//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace szamkitjat
//{
//    class Osszeg 
//    {
//        public void Ossz()
//        {
//            Console.WriteLine("\nA gép kezében {0} van.\nA játékos kezében {1} van", gepkez, jatekoskez);

//            if (gepkez == 21 || jatekoskez > 21)
//            {
//                Console.WriteLine("Veszítettél!");
//            }
//            else if (gepkez == jatekoskez)
//            {
//                Console.WriteLine("Döntetlen!");
//            }
//            else if (gepkez > 21 || jatekoskez == 21)
//            {
//                Console.WriteLine("Nyertél");
//            }
//            else if (gepkez > jatekoskez)
//            {
//                Console.WriteLine("Veszítettél!");
//            }
//            else
//            {
//                Console.WriteLine("Nyertél");
//            }
//            Console.WriteLine("Új játék? i/n");
//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case 'i':
//                    goto Huszonegy;
//                case 'n':
//                    goto End;
//            }
//        }
//    }
//}
