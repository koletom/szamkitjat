﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace szamkitjat
{
    class KoPapirOllo : IGame
    {
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "KPO";
        #endregion propertiregion
        public void Start()
        {
            Console.WriteLine("Válassz a három lehetőség közül! kő, papír, olló (k/p/o)");
            Console.WriteLine("\nA játék 5 pontig megy!");
        }
        
        int compScore = 0;
        int playerScore = 0;
        public void Play()
        {
            Random kpo = new Random();

            do
            {
                string compChoice = "";
                string playerChoice = "";
                Console.WriteLine("Mit választasz? (k/p/o)");
                char valaszt;
                bool ko;
                bool papir;
                bool ollo;
                valaszt = Console.ReadKey(true).KeyChar;
                ko = (valaszt == 'k' ^ valaszt == 'K');
                papir = (valaszt == 'p' ^ valaszt == 'P');
                ollo = (valaszt == 'o' ^ valaszt == 'O');
                if (ko == true)  { valaszt = 'k'; }
                else if (papir==true) { valaszt = 'p'; }
                else if (ollo==true) { valaszt = 'o'; }
                switch (valaszt)
                {
                    case 'k':
                        playerChoice = "kő";
                        break;
                    case 'p':
                        playerChoice = "papír";
                        break;
                    case 'o':
                        playerChoice = "olló";
                        break;
                }
                switch (kpo.Next(0, 3))
                {
                    case 0:
                        compChoice = "kő";
                        break;
                    case 1:
                        compChoice = "papír";
                        break;
                    case 2:
                        compChoice = "olló";
                        break;
                }

                if (
                    (playerChoice == "kő" && compChoice == "papír")
                    ||
                    (playerChoice == "papír" && compChoice == "olló")
                     ||
                     (playerChoice == "olló" && compChoice == "kő")
                   )
                {
                    Console.WriteLine("\nVeszítettél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
                    ++compScore, playerScore);
                }
                else if (playerChoice == compChoice)
                {
                    Console.WriteLine("\nDöntetlen! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
                    compScore, playerScore);
                }
                else if (
                    (compChoice == "kő" && playerChoice == "papír")
                    ||
                    (compChoice == "papír" && playerChoice == "olló")
                     ||
                     (compChoice == "olló" && playerChoice == "kő")
                   )
                {
                    Console.WriteLine("\nNyertél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
                    compScore, ++playerScore);
                }
                else
                {
                    Console.WriteLine("Csak az alábbi lehetőségek közül lehet választani: (k/p/o)");
                }
            } while (playerScore <= 4 && compScore != 5
                    || compScore <= 4 && playerScore != 5);
        }

       
        //TODO:Az End-be csak az eredményeket írjuk ki 

        public void End()
        {
            if (compScore == 5)
            {
                char tryagain;
                bool y;
                bool n;
                Console.WriteLine("\nVeszítettél! \nA Számítógép: {0}:{1} -ra/-re nyert!", compScore, playerScore);
                Console.WriteLine("Új próbálkozás? i/n");
                tryagain = Console.ReadKey(true).KeyChar;
                y = (tryagain == 'i' ^ tryagain == 'I');
                n = (tryagain == 'n' ^ tryagain == 'N');
                if (y == true) { tryagain = 'i'; }
                else if (n == true) { tryagain = 'n'; }
                switch (tryagain)
                {
                    case 'i':
                        Start();
                        break;
                    case 'n':
                        Exit();
                        break;
                }
            }
            if (playerScore == 5)
            {
                Console.WriteLine("\nGratulálunk! Nyertél! \nA Játékos: {0}:{1} -ra/-re nyert!", compScore, playerScore);
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
                    g.Kezdes();
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
