//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace szamkitjat
//{
//    class Computer : Jatekok
//    {
//        public void Gep()
//        {
//            Console.WriteLine("\nA gép gondolt egy számra 0-100-ig");
//            Random r = new Random();
//            int number = r.Next(100);
//            int c = 0;
//            int y = 0;
//            while (c < 5)
//            {
//                Console.WriteLine("\nA tipped: ");
//                y = int.Parse(Console.ReadLine());

//                if (y < number)
//                {
//                    Console.WriteLine("A szám ennél nagyobb!");
//                }
//                else if (y > number)
//                {
//                    Console.WriteLine("A szám ennél kisebb!");
//                }
//                else
//                {
//                    Console.WriteLine("Nyertél!");
//                    End();
//                }
//                ++c;

//            }
//            Console.WriteLine("\nVesztettél, a szám {0} volt.", number);
//            End();
//        }
//    }
//}