//namespace SzamKitJat
//{
//    public class Proba
//    {
//        static void Main(string[] args)
//        {
//            Jatek jatekok = new Jatek();
//            jatekok.metod1();
//            Jatek.Kitalalos obj2 = new Jatek.Kitalalos();
//            obj2.metod2();

//            Console.WriteLine("Válassz játékmódot");
//            Console.WriteLine("1 - Te gondolsz egy számra");
//            Console.WriteLine("2 - A számítógép gondol egy számra");
//            Console.WriteLine("3 - Kő, Papír, Olló");
//            Console.WriteLine("4 - 21 kártyajáték");

//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case '1':
//                    Console.WriteLine("Gondolj egy számra! (1 - 100)");
//                    //Console.ReadLine();
//                    //Player;
//                    return;
//                //case '2': goto Computer;
//                //case '3': goto KPO;
//                //case '4': goto Huszonegy;
//            }

//        }
//    }

//    public class Jatek
//    {
//        public void jatekok()
//        {
//            Console.WriteLine("Melyik játékkal szeretnél játszani");
//            Console.WriteLine("1 - Szám kitalálós játék");
//            Console.WriteLine("2 - Kő, Papír, Olló");
//            Console.WriteLine("3 - 21 kártyajáték");

//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case '1':
//                    int Kitalalos;
//                    return;
//                case '2':
//                    int KPO;
//                    return;
//                case '3':
//                    int Huszonegy;
//                    return;
//            }
//        }
//    }

//    public class Kitalalos : Jatek
//    {
//        public void kitalalosJatek()
//        {
//            Console.WriteLine("Válassz játékmódot");
//            Console.WriteLine("1 - Te gondolsz egy számra");
//            Console.WriteLine("2 - A számítógép gondol egy számra");

//            switch (Console.ReadKey(true).KeyChar)
//            {
//                case '1':
//                    int Player;
//                    return;
//                case '2':
//                    int Computer;
//                    return;
//            }
//                    Console.WriteLine("Kezdődjön a játék");
//        }

//    }
//    class Player : Kitalalos
//    {
//        public void kitalalosJatek()
//        {
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
//                        break;
//                }
//                ++i;
//            }
//            Console.WriteLine("A számítógép nem tudta kitalálni a számot.");
//        }
//    }

//    class Computer : Kitalalos
//    {
//        public void kitalalosJatek()
//        {
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
//                }
//                ++c;

//            }
//            Console.WriteLine("\nVesztettél, a szám {0} volt.", number);
//        }
//    }

//    class KPO : Jatek
//    {
//        public void jatekok()
//        {
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
//                            return;
//                        case 'n':
//                            break;
//                    }
//                }
//                if (playerScore == 5)
//                {
//                    Console.WriteLine("\nGratulálunk! Nyertél! \nA Játékos: {0}:{1} -ra/-re nyert!", compScore, playerScore);
//                    Console.WriteLine("Új játék? i/n");
//                    switch (Console.ReadKey(true).KeyChar)
//                    {
//                        case 'i':
//                            return;
//                        case 'n':
//                            break;
//                    }
//                }
//                ++j;
//            }
//        }
//    }

//    class Huszonegy : Jatek
//    {
//        public void jatekok()
//        {
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
//                        Osszeg;
//                        return;
//                }

//                Console.WriteLine("Új lap húzása? i/n");

//                if (gepkez == 21 || jatekoskez > 21)
//                {
//                    Console.WriteLine("\nVeszítettél!");
//                    Osszeg;
//                    return;
//                }
//                else if (gepkez > 21 || jatekoskez == 21)
//                {
//                    Console.WriteLine("\nNyertél");
//                    Osszeg;
//                    return;
//                }
//                else
//                {
//                }

//                ++huszonegy;
//            }
//        }
//    }

//    class Osszeg : Huszonegy
//    {
//        public void huszonegyossz()
//        {
//        }
//    }
//}