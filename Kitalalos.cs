using System;
using szamkitjatiterfaces;

namespace szamkitjat
{
    //TODO: Bővült az interface!!!
    public class Kitalalos : IGame
    {
        private IGameUI _gameUI;

        public Kitalalos(IGameUI gameUI)
        {
            _gameUI = gameUI ?? throw new NullReferenceException();
        }

        #region propertiregion

        private int gamercount { get; set; }
        public string Name => "Kitalalos";

        #endregion propertiregion

        private int gamer = 0;

        //Csak a játék módot kérje be, le kell ellenőrizni, hogy jó-e a readkeybe beolvasott karakter.
        //Ne innen legyen meghívva a play, a vissza a főmenübe esetén se legyen a g.Kezdés meghívva

        private int cc = 0;

        public void Start()
        {
            _gameUI.Sound(SoundTipes.Good);
            _gameUI.Clear(ConsoleColor.DarkRed, ConsoleColor.Yellow);
            _gameUI.PrintLN("Válassz játékmódot", ConsoleColor.DarkRed, ConsoleColor.Yellow);
            _gameUI.PrintLN("1 - Te gondolsz egy számra", ConsoleColor.DarkRed, ConsoleColor.Yellow);
            _gameUI.PrintLN("2 - A számítógép gondol egy számra", ConsoleColor.DarkRed, ConsoleColor.Yellow);
            _gameUI.PrintLN("3 - Vissza a Főmenübe", ConsoleColor.DarkRed, ConsoleColor.Yellow);
            cc = 0;
            switch (_gameUI.ReadKeyTrue)
            {
                case '1':
                    gamer = 1;
                    //Play();
                    break;

                case '2':
                    gamer = 2;
                    //Play();
                    break;

                case '3':
                    cc = 25;
                    //End();
                    break;

                default:
                    Start();
                    break;
            }
        }

        public void Play()
        {
            _gameUI.Sound(SoundTipes.Good);
            //TODO:A readkey-ek mindehol legyenek leellenőrizve a nagy betűket is el kelle fogadni
            if (gamer == 1)//Játékos
            {
                _gameUI.Clear();
                _gameUI.PrintLN("Gondolj egy számra! (1 - 100)");
                _gameUI.PrintLN("Nyomj egy gombot ha készen állsz!");
                _gameUI.ReadKey();
                _gameUI.Sound(SoundTipes.Good);

                Random p = new Random();
                int i = 0;
                int x = 50;
                int min = 0;
                int max = 100;
                int error = 0;
                do
                {
                    char size;
                    bool lower;
                    bool higher;
                    bool equal;

                    _gameUI.Clear();
                    if (error == -1)
                    {
                        _gameUI.PrintLN("A beírt karakter nincs a lehetőségek között!");
                        error = 0;
                    }
                    _gameUI.PrintLN($"A számítógép {i + 1}. tippje.");
                    _gameUI.PrintLN($"A számítógép szerint a szám {x}");
                    _gameUI.PrintLN("Szerinted? kisebb, nagyobb, egyenlő (k/n/e)");
                    size = _gameUI.ReadKeyTrue;
                    _gameUI.Sound(SoundTipes.Step);
                    lower = (size == 'k' ^ size == 'K');
                    higher = (size == 'n' ^ size == 'N');
                    equal = (size == 'e' ^ size == 'E');

                    if (lower == true) { size = 'k'; }
                    else if (higher == true) { size = 'n'; }
                    else if (equal == true) { size = 'e'; }
                    else if (lower == false || higher == false || equal == false)
                    {
                        error = -1;
                        --i;
                    }

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
                            i = 5;
                            x = 50;
                            min = 0;
                            max = 100;
                            cc = 20;
                            //End();
                            break;
                    }
                    ++i;
                } while (cc != 20 && i < 5);
                if (i <= 5)
                {
                    cc = 5;
                    //End();
                }
            }
            if (gamer == 2) //Gep
            {
                _gameUI.Clear();
                _gameUI.PrintLN("\nA gép gondolt egy számra 0-100-ig \n5 tipped lehet!");
                Random r = new Random();
                int number = r.Next(100);
                int c = 1;
                int y = 0;
                int ok = 0;
                do
                {
                    _gameUI.PrintLN($"\n{c}. tipped: ");
                    bool isValid;
                    int? num;
                    num = (int?)_gameUI.ReadNumber();
                    //string szam = _gameUI.ReadLine;
                    //bool isValid = int.TryParse(szam, out y);
                    if (num is null)
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                        y = (int)num;
                    }

                    _gameUI.Sound(SoundTipes.Step);

                    if (y > 100 || y < 0)
                    {
                        _gameUI.PrintLN("A szám nem esik bele a (0-100) tartományba");
                        --c;
                    }

                    if (isValid == false)
                    {
                        _gameUI.PrintLN($"A beírt adat nem egy szám!");
                        --c;
                    }
                    else if (y < number)
                    {
                        _gameUI.PrintLN("A szám ennél nagyobb!");
                    }
                    else if (y > number)
                    {
                        _gameUI.PrintLN("A szám ennél kisebb!");
                    }
                    else if (y == number)
                    {
                        c = 5;
                        cc = 10;
                        ok = 100;
                    }

                    ++c;
                } while (c <= 5);
                if (c > 5)
                {
                    if (ok == 100)
                    {
                        cc = 10;
                        number = 0;
                        c = 1;
                        y = 0;
                        ok = 0;
                        //End();
                    }
                    else
                    {
                        cc = 15;
                        _gameUI.PrintLN($"\nVesztettél, a szám {number} volt.");
                        number = 0;
                        c = 1;
                        y = 0;
                        ok = 0;
                        //End();
                    }
                }
            }
        }

        public void End()
        {
            EndResult(cc);
        }

        public void EndResult(int cc)
        {
            if (cc == 5)
            {
                _gameUI.PrintLN("Nyertél! A számítógép nem tudta kitalálni a számot.", ConsoleColor.DarkGreen);
                _gameUI.Sound(SoundTipes.Win);
                _gameUI.PrintLN("Nyomj egy gombot a Kitalalos menübe való visszatéréshez");
                gamer = 0;
                cc = 0;
                _gameUI.ReadKey();
                _gameUI.PrintLN("");
                //Start();
            }
            else if (cc == 10)
            {
                _gameUI.PrintLN("Eltaláltad!\nNyertél!", ConsoleColor.DarkGreen);
                _gameUI.Sound(SoundTipes.Win);
                _gameUI.PrintLN("Nyomj egy gombot a Kitalalos menübe való visszatéréshez");
                gamer = 0;
                cc = 0;
                _gameUI.ReadKey();
                _gameUI.PrintLN("");
                //Start();
            }
            else if (cc == 15)
            {
                //Console.WriteLine("\nVesztettél, a szám {0} volt.", number);
                _gameUI.Sound(SoundTipes.Lose);
                _gameUI.PrintLN("Nyomj egy gombot a Kitalalos menübe való visszatéréshez");
                gamer = 0;
                cc = 0;
                _gameUI.ReadKey();
                _gameUI.PrintLN("");
                //Start();
            }
            else if (cc == 20)
            {
                _gameUI.PrintLN("Vesztettél, a számítógép kitalálta a számot.");
                _gameUI.Sound(SoundTipes.Lose);
                _gameUI.PrintLN("Nyomj egy gombot a Kitalalos menübe való visszatéréshez");
                gamer = 0;
                cc = 0;
                _gameUI.ReadKey();
                _gameUI.PrintLN("");
                //Start();
            }
            else if (cc == 25)
            {
                gamer = 0;
                cc = 0;
            }
        }
    }
}