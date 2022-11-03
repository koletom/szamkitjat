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
        Game g = new Game(); //TODO: Ez nem kell
        int gamer = 0;

        //Csak a játék módot kérje be, le kell ellenőrizni, hogy jó-e a readkeybe beolvasott karakter.
        //Ne innen legyen meghívva a play, a vissza a főmenübe esetén se legyen a g.Kezdés meghívva
        public void Start()
        {
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
                    g.Kezdes();
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
                while (i < 5)
                {
                    Console.WriteLine("A számítógép szerint a szám {0}", x);
                    Console.WriteLine("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)");
                    switch (Console.ReadKey(true).KeyChar)
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
                            Console.WriteLine("A számítógép nyert!");
                            Console.WriteLine("Új játék? i/n");
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case 'i':
                                    Start();
                                    break;
                                case 'n':
                                    End();
                                    break;
                            }
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
                    while (c <= 5)
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
                        }
                        ++c;
                    }
                }
            
        }
        public void End()
        {
            if (cc==5)
            {
                Console.WriteLine("A számítógép nem tudta kitalálni a számot.");
            }
            if (cc==10) {
                Console.WriteLine("Eltaláltad!\nNyertél!");
                Console.WriteLine("Új játék? i/n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'i':
                        Start();
                        break;
                    case 'n':
                        End();
                        break;
                }
            }
            else if(cc==15)
            {
                Console.WriteLine("\nVesztettél, a szám {number} volt.");
            }
            Console.WriteLine("Új játék? i/n");
            switch (Console.ReadKey(true).KeyChar)
            {
                case 'i':
                    Start();
                    break;
                case 'n':
                    Exit();
                    break;
            }
        }
        void Exit()
        {
            Console.WriteLine("Visszatérés a Főmenübe? (i/n)");
            switch (Console.ReadKey(true).KeyChar)
            {
                case 'i':
                    g.Kezdes();
                    break;
                case 'n':
                    Console.WriteLine("Új játék? i/n");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'i':
                            Start();
                            break;
                        case 'n':
                            End();
                            break;
                    }
                    break;
            }
        }
    }
}
