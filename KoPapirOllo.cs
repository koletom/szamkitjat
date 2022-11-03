using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace szamkitjat
{
    class KoPapirOllo : IGame
    {
        Game g = new Game(); //TODO:Ez nem kell
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

                switch (Console.ReadKey(true).KeyChar)
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
                else
                {
                    Console.WriteLine("\nNyertél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
                    compScore, ++playerScore);
                }
            } while (playerScore <= 4 && compScore != 5
                    || compScore <= 4 && playerScore != 5);
        }

       
        //TODO:Az End-be csak az eredményeket írjuk ki 

        public void End()
        {
            if (compScore == 5)
            {
                Console.WriteLine("\nVeszítettél! \nA Számítógép: {0}:{1} -ra/-re nyert!", compScore, playerScore);
                Console.WriteLine("Új próbálkozás? i/n");
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
            if (playerScore == 5)
            {
                Console.WriteLine("\nGratulálunk! Nyertél! \nA Játékos: {0}:{1} -ra/-re nyert!", compScore, playerScore);
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
