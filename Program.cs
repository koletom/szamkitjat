using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjat;
using szamkitjatiterfaces;

namespace SzamKitJat
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Üdv a játékban");
            Console.WriteLine("Négy játékód közül lehet válsztani");
            Console.WriteLine("1- Amőba");
            Console.WriteLine("2- Kitalálós");
            Console.WriteLine("3- Huszonegy");
            Console.WriteLine("4- Kő, Papír, Olló");
            Console.WriteLine("Válassz játékmódot");


            int s = Console.ReadKey(true).KeyChar - 1;
            //if ()
            //{
            //}

            IGame[] games = new IGame[4];

            games[0] = new Amoba();
            games[1] = new Kitalalos();
            games[2] = new HuszonegyKartya();
            games[3] = new KoPapirOllo();

            var n = new Game(games);
            
            n.Kezdes();
            n.Ending();
        }
    }
}
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        START:
//            Console.WriteLine("Válassz játékmódot");
//            Console.WriteLine("1 - Te gondolsz egy számra");
//            Console.WriteLine("2 - A számítógép gondol egy számra");
//            Console.WriteLine("3 - Kő, Papír, Olló");
//            Console.WriteLine("4 - 21 kártyajáték");



//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case '1': goto Player;
//                case '2': goto Computer;
//                case '3': goto KPO;
//                case '4': goto Huszonegy;
//            }

//        Player:
//            Console.WriteLine("Gondolj egy számra! (1 - 100)");
//            Console.ReadLine();

//            Random p = new Random();
//            int i = 0;
//            int x = 50;
//            int min = 0;
//            int max = 100;
//            while (i < 5)
//            {
//                Console.WriteLine("A számítógép szerint a szám {0}", x);
//                Console.WriteLine("Szerinted? (k/n/e)");
//                switch (Console.ReadKey(true).KeyChar)
//                {
//                    case 'k':
//                        if (i == 3)
//                            x = p.Next(min, x);
//                        else
//                        {
//                            max = x;
//                            x -= (max - min) / 2;
//                        }
//                        break;
//                    case 'n':
//                        if (i == 3)
//                            x = p.Next(x + 1, max);
//                        else
//                        {
//                            min = x;
//                            x += (max - min) / 2;
//                        }
//                        break;
//                    case 'e':
//                        Console.WriteLine("A számítógép nyert!");
//                        goto End;
//                }
//                ++i;
//            }
//            Console.WriteLine("A számítógép nem tudta kitalálni a számot.");

//            goto End;


//        Computer:
//            Console.WriteLine("\nA gép gondolt egy számra 0-100-ig");
//            Random r = new Random();
//            int number = r.Next(100);
//            int c = 0;
//            int y = 0;
//            while (c < 5)
//            {
//                Console.WriteLine("\nA tipped: ");
//                y = int.Parse(Console.ReadLine());

//                if (y < number)
//                {
//                    Console.WriteLine("A szám ennél nagyobb!");
//                }
//                else if (y > number)
//                {
//                    Console.WriteLine("A szám ennél kisebb!");
//                }
//                else
//                {
//                    Console.WriteLine("Nyertél!");
//                    goto End;
//                }
//                ++c;

//            }
//            Console.WriteLine("\nVesztettél, a szám {0} volt.", number);
//            goto End;

//        KPO:
//            Console.WriteLine("\nA játék 5 pontig megy!");

//            int j = 0;

//            Random kpo = new Random();

//            string compChoice = "";
//            string playerChoice = "";
//            int compScore = 0;
//            int playerScore = 0;

//            while (j < 30)
//            {
//                Console.WriteLine("Mit választasz? (k/p/o)");

//                switch (Console.ReadKey(true).KeyChar)
//                {
//                    case 'k':
//                        playerChoice = "kő";
//                        break;
//                    case 'p':
//                        playerChoice = "papír";
//                        break;
//                    case 'o':
//                        playerChoice = "olló";
//                        break;
//                }
//                switch (kpo.Next(0, 3))
//                {
//                    case 0:
//                        compChoice = "kő";
//                        break;
//                    case 1:
//                        compChoice = "papír";
//                        break;
//                    case 2:
//                        compChoice = "olló";
//                        break;
//                }

//                if (
//                    (playerChoice == "kő" && compChoice == "papír")
//                    ||
//                    (playerChoice == "papír" && compChoice == "olló")
//                     ||
//                     (playerChoice == "olló" && compChoice == "kő")
//                   )
//                {
//                    Console.WriteLine("\nVeszítettél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
//                    ++compScore, playerScore);
//                }
//                else if (playerChoice == compChoice)
//                {
//                    Console.WriteLine("\nDöntetlen! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
//                    compScore, playerScore);
//                }
//                else
//                {
//                    Console.WriteLine("\nNyertél! Az állás:\nSzámítógép: {0}\nJátékos:{1}",
//                    compScore, ++playerScore);
//                }
//                if (compScore == 5)
//                {
//                    Console.WriteLine("\nVeszítettél! \nA Számítógép: {0}:{1} -ra/-re nyert!", compScore, playerScore);
//                    Console.WriteLine("Új próbálkozás? i/n");
//                    switch (Console.ReadKey(true).KeyChar)
//                    {
//                        case 'i':
//                            goto KPO;
//                        case 'n':
//                            goto End;
//                    }
//                }
//                if (playerScore == 5)
//                {
//                    Console.WriteLine("\nGratulálunk! Nyertél! \nA Játékos: {0}:{1} -ra/-re nyert!", compScore, playerScore);
//                    Console.WriteLine("Új játék? i/n");
//                    switch (Console.ReadKey(true).KeyChar)
//                    {
//                        case 'i':
//                            goto KPO;
//                        case 'n':
//                            goto End;
//                    }
//                }
//                ++j;
//            }


//        Huszonegy:

//            Console.WriteLine("\nAz nyer akinek nagyobb száma van vagy előbb lesz 21-e.\nHa valakinek több mint 21 az veszít");

//            int gepkez = 0;
//            int jatekoskez = 0;

//            int huszonegy = 0;


//            Console.WriteLine("Új lap húzása? i/n");
//            while (huszonegy < 25)
//            {
//                Random h1 = new Random();
//                int ujlap;
//                gepkez = gepkez + (ujlap = h1.Next(1, 11));
//                switch (Console.ReadKey(true).KeyChar)
//                {
//                    case 'i':
//                        Random hh = new Random();
//                        int jatekos = hh.Next(1, 11);
//                        jatekoskez = jatekoskez + jatekos;
//                        Console.WriteLine("\nA gnép kezében {0} van.\nA játékos kezében {1} van", gepkez, jatekoskez);

//                        break;
//                    case 'n':
//                        goto Osszeg;
//                }

//                Console.WriteLine("Új lap húzása? i/n");


//                if (gepkez == 21 || jatekoskez > 21)
//                {
//                    Console.WriteLine("\nVeszítettél!");
//                    goto Osszeg;
//                }
//                else if (gepkez > 21 || jatekoskez == 21)
//                {
//                    Console.WriteLine("\nNyertél");
//                    goto Osszeg;
//                }
//                else
//                {

//                }

//                ++huszonegy;
//            }
//        Osszeg:
//            Console.WriteLine("\nA gép kezében {0} van.\nA játékos kezében {1} van", gepkez, jatekoskez);

//            if (gepkez == 21 || jatekoskez > 21)
//            {
//                Console.WriteLine("Veszítettél!");
//            }
//            else if (gepkez == jatekoskez)
//            {
//                Console.WriteLine("Döntetlen!");
//            }
//            else if (gepkez > 21 || jatekoskez == 21)
//            {
//                Console.WriteLine("Nyertél");
//            }
//            else if (gepkez > jatekoskez)
//            {
//                Console.WriteLine("Veszítettél!");
//            }
//            else
//            {
//                Console.WriteLine("Nyertél");
//            }
//            Console.WriteLine("Új játék? i/n");
//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case 'i':
//                    goto Huszonegy;
//                case 'n':
//                    goto End;
//            }

//        End:
//            Console.WriteLine("\nAkarsz még játszani? i/n");
//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case 'i': goto START;
//                case 'n': break;
//                default: goto End;
//            }
//        }
//    }


