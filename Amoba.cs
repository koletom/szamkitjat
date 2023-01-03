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
        IGameUI _gameUI;
        public Amoba (IGameUI gameUI)
        {
            _gameUI = gameUI;
        }
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "Amoba";
        #endregion propertiregion
        static int[] tabla = new int[9];
      
        private static bool megszakit()
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
                    _gameUI.Print(".", ConsoleColor.DarkGray, ConsoleColor.White);
                }
                if (tabla[i] == 1)
                {
                    _gameUI.Print("X", ConsoleColor.Blue, ConsoleColor.White);
                }
                if (tabla[i] == 2)
                {
                    _gameUI.Print("O", ConsoleColor.Red, ConsoleColor.White);
                }
                if (i == 2 || i == 5 || i == 8)
                {
                    _gameUI.PrintLNBcg("", ConsoleColor.Gray);
                }
            }
        }

        public void Start()
        {
            Hang.Good();
            _gameUI.Clear();
            _gameUI.PrintLN("A játék célja, hogy 3 X-et helyezzünk egy sorba, oszlopba, keresztbe", ConsoleColor.DarkGray, ConsoleColor.Gray);
            _gameUI.PrintLN("A Játékos az X-el, a Gép a O-rel van.", ConsoleColor.DarkGray, ConsoleColor.Gray);
            _gameUI.PrintLN("A számok a rácson az alábbi helyeket foglalják el:", ConsoleColor.DarkGray, ConsoleColor.Gray);
            _gameUI.PrintLN("0,1,2", ConsoleColor.DarkGray, ConsoleColor.Gray);
            _gameUI.PrintLN("3,4,5", ConsoleColor.DarkGray, ConsoleColor.Gray);
            _gameUI.PrintLN("6,7,8", ConsoleColor.DarkGray, ConsoleColor.Gray);
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
                    _gameUI.PrintLN("Írj be egy számot 0 - 8 ig", ConsoleColor.Blue);
                    bool placeValid = int.TryParse(_gameUI.ReadLine, out number);
                    Hang.Lepes();
                    _gameUI.Clear();
                    if (placeValid)
                    {
                        _gameUI.PrintLN($"A beírt szám:{number}", ConsoleColor.Blue);
                    }
                    if (number >= 9||number<0)
                    {
                        Hang.Hiba();
                        _gameUI.PrintLN($"A beírt szám nem megfelelő", ConsoleColor.Red);
                        tablazat();
                    }
                    else if (number == elsoJatekos || number == gepJatekos)
                    {
                        Hang.Hiba();
                        _gameUI.PrintLN($"A beírt szám helye foglalt", ConsoleColor.Red);
                        tablazat();
                    }
                    else
                    {
                        elsoJatekos = number;
                    }
                }

                tabla[elsoJatekos] = 1;

                if (megszakit())
                    break;
                if (nyertes() != 0) 
                    break;

                while (gepJatekos == -1 || tabla[gepJatekos] != 0)
                {
                    gepJatekos = rand.Next(8);
                    _gameUI.PrintLN($"A gép által választott szám {gepJatekos}", ConsoleColor.Blue);
                }

                tabla[gepJatekos] = 2;

                if (megszakit())
                    break;

                tablazat();
            }
        }

        public void End()
        {
            if (nyertes() == 1)
            {
                tablazat();
                _gameUI.PrintLN("\nGratulálunk! Nyertél!", ConsoleColor.Green);
                _gameUI.PrintLN("Jatékos nyert\n", ConsoleColor.Green);
                Hang.Win();
            }
            if (nyertes() == 2)
            {
                _gameUI.PrintLN("\nVeszítettél! \nA Számítógép nyert!", ConsoleColor.Red);
                Hang.Lose();
            }
            if (nyertes() != 1 && nyertes() != 2)
            {
                tablazat();
                _gameUI.PrintLN("Döntetlen", ConsoleColor.Yellow);
                Hang.Tie();
            }

            System.Threading.Thread.Sleep(1000);

        }
    }
}
