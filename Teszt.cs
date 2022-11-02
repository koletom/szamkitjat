//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace szamkitjat
//{
//    public class Teszt
//    {
//        static public void Main()
//        {
//            Jatek jatek = new Jatek();
//            jatek.jatekok();
//            Jatek.Kitalalos kitalalos = new Jatek.Kitalalos();
//            kitalalos.kitalalosjatek();
//            Jatek.Kitalalos.Player player = new Jatek.Kitalalos.Player();
//            player.kitalalosplayer();
//            Jatek.Kitalalos.Computer computer = new Jatek.Kitalalos.Computer();
//            computer.kitalaloscomputer();
//            Jatek.KPO kpo = new Jatek.KPO();
//            kpo.kpojatek();
//            Jatek.Huszonegy huszonegy = new Jatek.Huszonegy();
//            huszonegy.kartyajatek();
//            Jatek.Huszonegy.Osszeg osszeg = new Jatek.Huszonegy.Osszeg();
//            osszeg.osszegzes();
//            End end = new End();
//            end.kerdes();


//            Console.WriteLine("Válassz játékmódot");
//            Console.WriteLine("1 - Te gondolsz egy számra");
//            Console.WriteLine("2 - A számítógép gondol egy számra");
//            Console.WriteLine("3 - Kő, Papír, Olló");
//            Console.WriteLine("4 - 21 kártyajáték");


//        }
//    }

//    public class End
//    {
//        public void kerdes()
//        {
//            Console.WriteLine("\nAkarsz még játszani? i/n");
//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case 'i': (Teszt)
//                case 'n': break;
//                    default(Jatek());
//            }
//        }
//    }

//    public class Jatek
//    {
        

//        public void jatekok()
//        {
//        }

//        public class Kitalalos
//        {
//            public Kitalalos()
//            {
               
//            }

//            public void kitalalosjatek()
//            {
//                throw new NotImplementedException();
//            }

//            public class Player
//            {
//                public void kitalalosplayer()
//                {
//                    Console.WriteLine("Gondolj egy számra! (1 - 100)");
//                    Console.ReadLine();

//                    Random p = new Random();
//                    int i = 0;
//                    int x = 50;
//                    int min = 0;
//                    int max = 100;
//                    while (i < 5)
//                    {
//                        Console.WriteLine("A számítógép szerint a szám {0}", x);
//                        Console.WriteLine("Szerinted? (k/n/e)");
//                        switch (Console.ReadKey(true).KeyChar)
//                        {
//                            case 'k':
//                                if (i == 3)
//                                    x = p.Next(min, x);
//                                else
//                                {
//                                    max = x;
//                                    x -= (max - min) / 2;
//                                }
//                                break;
//                            case 'n':
//                                if (i == 3)
//                                    x = p.Next(x + 1, max);
//                                else
//                                {
//                                    min = x;
//                                    x += (max - min) / 2;
//                                }
//                                break;
//                            case 'e':
//                                Console.WriteLine("A számítógép nyert!");
//                                goto End;
//                        }
//                        ++i;
//                    }
//                    Console.WriteLine("A számítógép nem tudta kitalálni a számot.");

//                    goto End;
//                }
//            }

//            public class Computer
//            {
//                public void kitalaloscomputer()
//                {
//                    Console.WriteLine("\nA gép gondolt egy számra 0-100-ig");
//                    Random r = new Random();
//                    int number = r.Next(100);
//                    int c = 0;
//                    int y = 0;
//                    while (c < 5)
//                    {
//                        Console.WriteLine("\nA tipped: ");
//                        y = int.Parse(Console.ReadLine());

//                        if (y < number)
//                        {
//                            Console.WriteLine("A szám ennél nagyobb!");
//                        }
//                        else if (y > number)
//                        {
//                            Console.WriteLine("A szám ennél kisebb!");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Nyertél!");
//                            goto End;
//                        }
//                        ++c;

//                    }
//                    Console.WriteLine("\nVesztettél, a szám {0} volt.", number);
//                    goto End;
//                }
//            }
//        }

//        public class KPO
//        {
//            public void kpojatek()
//            {
//                throw new NotImplementedException();
//            }
//        }

//        public class Huszonegy
//        {
//            public void kartyajatek()
//            {
//                throw new NotImplementedException();
//            }

//            public class Osszeg
//            {
//                public void osszegzes()
//                {
//                    throw new NotImplementedException();
//                }
//            }
//        }
//    }
//}
