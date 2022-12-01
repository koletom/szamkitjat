using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace szamkitjat
{
    //TODO: Bővült az interface!!!
    class Kitalalos : IGame
    {
        //public void KitalalosJatek()
        //{

        //}
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "Kitalalos";
        #endregion propertiregion
        int gamer = 0;

        //Csak a játék módot kérje be, le kell ellenőrizni, hogy jó-e a readkeybe beolvasott karakter.
        //Ne innen legyen meghívva a play, a vissza a főmenübe esetén se legyen a g.Kezdés meghívva
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Válassz játékmódot");
            Console.WriteLine("1 - Te gondolsz egy számra");
            Console.WriteLine("2 - A számítógép gondol egy számra");
            Console.WriteLine("3 - Vissza a Főmenübe");

            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    gamer = 1;
                    Play();
                    break;
                case '2':
                    gamer = 2;
                    Play();
                    break;
                case '3':
                    break;
                default:
                    Start();
                    break;
            }
        }
        int cc = 0;
        public void Play()
        {
            //TODO:A readkey-ek mindehol legyenek leellenőrizve a nagy betűket is el kelle fogadni
            if (gamer == 1)//Játékos
            {
                Console.WriteLine("Gondolj egy számra! (1 - 100)");
                Console.ReadLine();

                Random p = new Random();
                int i = 0;
                int x = 50;
                int min = 0;
                int max = 100;
                while (i < 5)   //Ezt még ki kell javítani
                {
                    char size;
                    bool lower;
                    bool higher;
                    bool equal;
                    Console.WriteLine("A számítógép szerint a szám {0}", x);
                    Console.WriteLine("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)");
                    size = Console.ReadKey(true).KeyChar;
                    lower = (size == 'k' ^ size == 'K');
                    higher = (size == 'n' ^ size == 'N');
                    equal = (size == 'e' ^ size == 'E');
                    if (lower == true) { size = 'k'; }
                    else if (higher == true) { size = 'n'; }
                    else if (equal == true) { size = 'e'; }
                    switch (size)
                    {
                        case 'k':
                            if (i == 3)
                                x = p.Next(min, x);
                            else
                            {
                                max = x;
                                x -= (max - min) / 2;
                            }
                            break;
                        case 'n':
                            if (i == 3)
                                x = p.Next(x + 1, max);
                            else
                            {
                                min = x;
                                x += (max - min) / 2;
                            }
                            break;
                        case 'e':
                            cc = 20;
                            End();
                            break;
                    }
                    ++i;
                }
                cc = 5;
                End();

            }
            if (gamer == 2) //Gep
            {

                    Console.WriteLine("\nA gép gondolt egy számra 0-100-ig \n5 tipped lehet!");
                    Random r = new Random();
                    int number = r.Next(100);
                    int c = 1;
                    int y = 0;
                    while (c <= 5)   //Ezt még ki kell javítani
                {
                        Console.WriteLine($"\n{c}. tipped: ");
                        y = int.Parse(Console.ReadLine());

                        if (y < number)
                        {
                            Console.WriteLine("A szám ennél nagyobb!");
                        }
                        else if (y > number)
                        {
                            Console.WriteLine("A szám ennél kisebb!");
                        }
                        else if (y == number)
                        {
                            cc = 10;
                            End();
                        }
                        else
                        {
                            cc = 15;
                            End();
                        }
                        ++c;
                    }
            }
        }
        public void End()
        {
            var h = new Hang();
            if (cc == 5)
            {
                Console.WriteLine("Nyertél! A számítógép nem tudta kitalálni a számot.");
                h.Win();
            }
            else if (cc == 10) {
                Console.WriteLine("Eltaláltad!\nNyertél!");
                h.Win();
            }
            else if (cc == 15)
            {
                Console.WriteLine("\nVesztettél, a szám {number} volt.");
                h.Lose();
            }
            else if (cc == 20)
            {
                Console.WriteLine("Vesztettél, a számítógép kitalálta a számot.");
                h.Lose();
            }
            
        }

        void KitalalRestart(IGame game)
        {
            char c;
            do
            {
                Start();
                Play();
                End();

                Console.WriteLine("Akarsz újra {0} játékkal játszani? (i/n)", game.Name);

                c = Console.ReadKey(true).KeyChar;

            } while (char.ToUpper(c) == 'I');
        }
    }
}
