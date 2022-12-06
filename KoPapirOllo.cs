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
        #region propertiregion
        int gamercount { get; set; }
        public string Name => "KPO";
        #endregion propertiregion
        public void Start()
        {
            var h = new Hang();
            h.Good();
            Console.Clear();
            Console.WriteLine("Válassz a három lehetőség közül! kő, papír, olló (k/p/o)");
            Console.WriteLine("\nA játék 5 pontig megy!");
        }
        
        int compScore = 0;
        int playerScore = 0;
        public void Play()
        {
            var h = new Hang();
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
                h.Lepes();
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
                    Console.Clear();
                    Console.WriteLine("Játékos:{0} vs. Gép:{1}", playerChoice, compChoice);
                    Console.WriteLine("\nVeszítettél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",++compScore, playerScore);
                    h.Bad();
                }
                else if (playerChoice == compChoice)
                {
                    Console.Clear();
                    Console.WriteLine("Játékos:{0} vs. Gép:{1}", playerChoice, compChoice);
                    Console.WriteLine("\nDöntetlen! Az állás:\nSzámítógép: {0}\nJátékos:{1}",compScore, playerScore);
                    h.Tie();
                }
                else if (
                    (compChoice == "kő" && playerChoice == "papír")
                    ||
                    (compChoice == "papír" && playerChoice == "olló")
                     ||
                     (compChoice == "olló" && playerChoice == "kő")
                   )
                {
                    Console.Clear();
                    Console.WriteLine("Játékos:{0} vs. Gép:{1}", playerChoice, compChoice);
                    Console.WriteLine("\nNyertél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",compScore, ++playerScore);
                    h.Good();
                }
                else
                {
                    Console.Clear();
                    h.Hiba();
                    Console.WriteLine("Játékos:{0} vs. Gép:{1}", playerChoice, compChoice);
                    Console.WriteLine("Csak az alábbi lehetőségek közül lehet választani: (k/p/o)");
                }
            } while (playerScore <= 4 && compScore != 5
                    || compScore <= 4 && playerScore != 5);
            System.Threading.Thread.Sleep(500);
        }

       
        //TODO:Az End-be csak az eredményeket írjuk ki 

        public void End()
        {
            var h = new Hang();
            
            if (compScore == 5)
            {
                h.Lose();
                Console.WriteLine("\nVeszítettél! \nA Számítógép: {0}:{1} -ra/-re nyert!", compScore, playerScore);
            }
            if (playerScore == 5)
            {
                h.Win();
                Console.WriteLine("\nGratulálunk! Nyertél! \nA Játékos: {0}:{1} -ra/-re nyert!", compScore, playerScore);
            }
            compScore = 0;
            playerScore = 0;
        }       
            
    }
}
