//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace szamkitjat
//{
//    class Player : Jatekok
//    {

//        public void Jatekos()
//        {
//                Console.WriteLine("Gondolj egy számra! (1 - 100)");
//                Console.ReadLine();

//                Random p = new Random();
//                int i = 0;
//                int x = 50;
//                int min = 0;
//                int max = 100;
//                while (i < 5)
//                {
//                    Console.WriteLine("A számítógép szerint a szám {0}", x);
//                    Console.WriteLine("Szerinted? (k/n/e)");
//                    switch (Console.ReadKey(true).KeyChar)
//                    {
//                        case 'k':
//                            if (i == 3)
//                                x = p.Next(min, x);
//                            else
//                            {
//                                max = x;
//                                x -= (max - min) / 2;
//                            }
//                            break;
//                        case 'n':
//                            if (i == 3)
//                                x = p.Next(x + 1, max);
//                            else
//                            {
//                                min = x;
//                                x += (max - min) / 2;
//                            }
//                            break;
//                        case 'e':
//                            Console.WriteLine("A számítógép nyert!");
//                            End();
//                            break;
//                    }
//                    ++i;
//                }
//                Console.WriteLine("A számítógép nem tudta kitalálni a számot.");

//                End();
//        }
//    }
//}
