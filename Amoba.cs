using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace szamkitjat
{
    class Amoba : IGame
    {
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "Amoba";
        #endregion propertiregion
        static int[] tabla = new int[9];
      
        private static bool dontetlen()
        {
            bool tele = true;
            for (int i = 0; i < tabla.Length; i++)
            {
                if (tabla[i] == 0)
                {
                    tele = false;
                }   
            }
            return tele;
        }

        private static int nyertes()
        {
            //1.sor
            if (tabla[0] == tabla[1] && tabla[1] == tabla[2])
            {
                return tabla[0];
            }
            //2.sor
            if (tabla[3] == tabla[4] && tabla[4] == tabla[5])
            {
                return tabla[3];
            }
            //3.sor
            if (tabla[6] == tabla[7] && tabla[7] == tabla[8])
            {
                return tabla[6];
            }
            //1.oszlop
            if (tabla[0] == tabla[3] && tabla[3] == tabla[6])
            {
                return tabla[0];
            }
            //2.oszlop
            if (tabla[1] == tabla[4] && tabla[4] == tabla[7])
            {
                return tabla[1];
            }
            //3.oszlop
            if (tabla[2] == tabla[5] && tabla[5] == tabla[8])
            {
                return tabla[2];
            }
            //1.átló
            if (tabla[0] == tabla[4] && tabla[4] == tabla[8])
            {
                return tabla[4];
            }
            //2.átló
            if (tabla[2] == tabla[4] && tabla[4] == tabla[6])
            {
                return tabla[4];
            }
            return 0;
        }
        private void tablazat()
        {
            for (int i = 0; i < 9; i++)
            {
                if (tabla[i] == 0)
                {
                    Console.Write(".");
                }
                if (tabla[i] == 1)
                {
                    Console.Write("X");
                }
                if (tabla[i] == 2)
                {
                    Console.Write("O");
                }

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }

       
        public void Start()
        {
            Console.WriteLine("A játék célja, hogy 3 X-et helyezzünk egy sorba, oszlopba, keresztbe");
            Console.WriteLine("A Játékos az X-el, a Gép a O-rel van.");
            Console.WriteLine("A számok a rácson az alábbi helyeket foglalják el:");
            Console.WriteLine("0,1,2");
            Console.WriteLine("3,4,5");
            Console.WriteLine("6,7,8");
        }

        public void Play()
        {
            
            for (int i = 0; i < 9; i++)
            {
                tabla[i] = 0;
            }

            int elsoJatekos = -1;
            int gepJatekos = -1;
            Random rand = new Random();
            
            tablazat();
            while (nyertes() == 0)
            {
                while (elsoJatekos == -1 || tabla[elsoJatekos] != 0)
                {
                    int number;
                    Console.WriteLine("Írj be egy számot 0 - 8 ig");
                    bool placeValid = int.TryParse(Console.ReadLine(), out number);
                    if (placeValid)
                    {
                        Console.WriteLine($"A beírt szám:{number}");
                    }
                    if (number >= 9||number<0)
                    {
                        Console.WriteLine($"A beírt szám nem megfelelő");
                    }
                    else
                    {
                        elsoJatekos = number;
                    }
                }

                tabla[elsoJatekos] = 1;

                if (dontetlen())
                    break;

                while (gepJatekos == -1 || tabla[gepJatekos] != 0)
                {
                    gepJatekos = rand.Next(8);
                    Console.WriteLine($"A gép által választott szám {gepJatekos}");
                }

                tabla[gepJatekos] = 2;

                if (dontetlen())
                    break;

                tablazat();

            }
        }

        public void End()
        {
            if (nyertes() == 1)
            {
                Console.WriteLine("\nGratulálunk! Nyertél!");
                Console.WriteLine("Jatékos nyert");
            }
            if (nyertes() == 2)
            {
                Console.WriteLine("\nVeszítettél! \nA Számítógép nyert!");
            }
            if (dontetlen())
            {
                Console.WriteLine("Döntetlen");
            }

            System.Threading.Thread.Sleep(2000);

            char newgame;
            bool y;
            bool n;
            Console.WriteLine("Új játék? i/n");
            newgame = Console.ReadKey(true).KeyChar;
            y = (newgame == 'i' ^ newgame == 'I');
            n = (newgame == 'n' ^ newgame == 'N');
            if (y == true) { newgame = 'i'; }
            else if (n == true) { newgame = 'n'; }
            switch (newgame)
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
            char exit;
            bool yes;
            bool no;
            Console.WriteLine("Visszatérés a Főmenübe? (i/n)");
            exit = Console.ReadKey(true).KeyChar;
            yes = (exit == 'i' ^ exit == 'I');
            no = (exit == 'n' ^ exit == 'N');
            if (yes == true) { exit = 'i'; }
            else if (no == true) { exit = 'n'; }
            switch (exit)
            {
                case 'i':
                    Kezdes();
                    break;
                case 'n':
                    char newgame;
                    bool y;
                    bool n;
                    Console.WriteLine("Új játék? i/n");
                    newgame = Console.ReadKey(true).KeyChar;
                    y = (newgame == 'i' ^ newgame == 'I');
                    n = (newgame == 'n' ^ newgame == 'N');
                    if (y == true) { newgame = 'i'; }
                    else if (n == true) { newgame = 'n'; }
                    switch (newgame)
                    {
                        case 'i':
                            Start();
                            break;
                        case 'n':
                            End();
                            break;
                    }
                    break;
                default:
                    Exit();
                    break;
            }
        }
    }
}
