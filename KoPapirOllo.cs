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
        IGameUI _gameUI;
        public KoPapirOllo(IGameUI gameUI)
        {
            _gameUI = gameUI;
        }
        public void KPOSzinek()
        {
            _gameUI.PrintLN("", ConsoleColor.DarkBlue, ConsoleColor.Cyan);
        }
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "KPO";
        #endregion propertiregion
        public void Start()
        {
            Hang.Good();
            _gameUI.Clear();
            _gameUI.PrintLN("Válassz a három lehetőség közül! kő, papír, olló (k/p/o)");
            _gameUI.PrintLN("\nA játék 5 pontig megy!");
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
                _gameUI.PrintLN("");
                _gameUI.PrintLN("Mit választasz? (k/p/o)");
                char valaszt;
                bool ko;
                bool papir;
                bool ollo;
                valaszt = _gameUI.ReadKeyTrue;
                Hang.Lepes();
                System.Threading.Thread.Sleep(500);
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
                    _gameUI.Clear();
                    _gameUI.PrintLN($"Játékos:{playerChoice} vs. Gép:{compChoice}");
                    _gameUI.PrintLN("\nVesztettél!", ConsoleColor.Red);
                    KPOSzinek();
                    _gameUI.PrintLN($" Az állás:\nSzámítógép: {++compScore}\nJátékos:{playerScore}");
                    Hang.Bad();
                }
                else if (playerChoice == compChoice)
                {
                    _gameUI.Clear();
                    _gameUI.PrintLN($"Játékos:{playerChoice} vs. Gép:{compChoice}");
                    _gameUI.PrintLN("\nDöntetlen!", ConsoleColor.Yellow);
                    KPOSzinek();
                    _gameUI.PrintLN($" Az állás:\nSzámítógép: {compScore}\nJátékos:{playerScore}");
                    Hang.Tie();
                }
                else if (
                    (compChoice == "kő" && playerChoice == "papír")
                    ||
                    (compChoice == "papír" && playerChoice == "olló")
                     ||
                     (compChoice == "olló" && playerChoice == "kő")
                   )
                {
                    _gameUI.Clear();
                    _gameUI.PrintLN($"Játékos:{playerChoice} vs. Gép:{compChoice}");
                    _gameUI.PrintLN("\nNyertél!", ConsoleColor.DarkGreen);
                    KPOSzinek();
                    _gameUI.PrintLN($" Az állás:\nSzámítógép: {compScore}\nJátékos:{++playerScore}");
                    Hang.Good();
                }
                else
                {
                    _gameUI.Clear();
                    Hang.Hiba();
                    _gameUI.PrintLN($"Játékos:{playerChoice} vs. Gép:{compChoice}");
                    _gameUI.PrintLN("Csak az alábbi lehetőségek közül lehet választani: (k/p/o)");
                }
            } while (playerScore <= 4 && compScore != 5
                    || compScore <= 4 && playerScore != 5);
            System.Threading.Thread.Sleep(500);
        }

       
        //TODO:Az End-be csak az eredményeket írjuk ki 

        public void End()
        {
            if (compScore == 5)
            {
                Hang.Lose();
                _gameUI.PrintLN("\nVesztettél!", ConsoleColor.Red);
                    KPOSzinek();
                _gameUI.PrintLN($" \nA Számítógép: {compScore}:{playerScore} -ra/-re nyert!\n");
            }
            if (playerScore == 5)
            {
                Hang.Win();
                _gameUI.PrintLN("\nGratulálunk! Nyertél!", ConsoleColor.DarkGreen);
                KPOSzinek();
                _gameUI.PrintLN($" \nA Játékos: {compScore}:{playerScore} -ra/-re nyert!\n");
            }
            compScore = 0;
            playerScore = 0;
        }       
            
    }
}
