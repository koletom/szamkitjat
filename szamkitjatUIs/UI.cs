using System;
using szamkitjatiterfaces;

//TODO: Ezt egy külön projectbe kellene átrakni egy másik namespacebe pl: szamkitjat.UI.Console
namespace szamkitjatUIs.UI
{
    public class UI : IGameUI
    {
        private ConsoleColor _defaultForeground = ConsoleColor.White;
        private ConsoleColor _defaultBackground = ConsoleColor.Black;
        private ISound _speaker;

        IServiceProvider _serviceProvider;

        public UI(ISound speaker)
        {
            _speaker = speaker;
            if (_speaker == null)
            {
                throw new NullReferenceException();
            }
        }

        public void Clear()
        {
            Console.ForegroundColor = _defaultForeground;
            Console.BackgroundColor = _defaultBackground;
            Console.Clear();
        }

        public void Clear(ConsoleColor foreground, ConsoleColor background)
        {
            _defaultForeground = foreground;
            _defaultBackground = background;

            Console.ForegroundColor = _defaultForeground;
            Console.BackgroundColor = _defaultBackground;
            Console.Clear();
        }

        public void Print(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(szoveg);
        }

        public void Print(string szoveg)
        {
            //TODO:Hiányzik a foreground és background beállítása a default értékekre
            Console.ForegroundColor = _defaultForeground;
            Console.BackgroundColor = _defaultBackground;
            Console.Write(szoveg);
        }

        public void Print(string szoveg, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.Write(szoveg);
        }

        public void PrintBcg(string szoveg, ConsoleColor background)
        {
            Console.BackgroundColor = background;
            Console.Write(szoveg);
        }

        public void PrintLN(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(szoveg);
        }

        public void PrintLN(string szoveg)
        {
            Console.ForegroundColor = _defaultForeground;
            Console.BackgroundColor = _defaultBackground;
            Console.WriteLine(szoveg);
        }

        public void PrintLN(string szoveg, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.WriteLine(szoveg);
        }

        public void PrintLNBcg(string szoveg, ConsoleColor background)
        {
            Console.BackgroundColor = background;
            Console.WriteLine(szoveg);
        }

        //public void ReadLine(string szoveg)
        //{
        //    Console.ReadLine();
        //}
        //public void ReadLineNum(int szam)
        //{
        //    Console.ReadLine();
        //}
        //public void ReadKey(char karakter)
        //{
        //    Console.ReadKey();
        //}

        public string ReadLine => Console.ReadLine();

        public void ReadKey()
        {
            Console.ReadKey();
        }

        public char ReadKeyTrue => _ = Console.ReadKey(true).KeyChar;

        public bool? ReadKey(char trueChar = 'y', char falseChar = 'n')
        {
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == trueChar)
            {
                return true;
            }
            else if (keyInfo.KeyChar == falseChar)
            {
                return false;
            }

            return null;
        }

        public uint? ReadNumber()
        {
            uint y = 0;
            string szam = ReadLine;
            if (uint.TryParse(szam, out y))
            {
                return y;
            }
            return null;
        }

        //TODO: Ennek a metódusnak egy a stringLengthben megadott max hosszúságú stringet kellene beolvasnia
        public string ReadString(int stringLength)
        {
            if (stringLength == 1)
            {
                Console.ReadLine();
            }
            return null;
        }

        //TODO: Ennek a metódusnak a validStrings tömbben megadott stringeket lenne szabad csak elfogadnia
        private string[] validString = { "yes", "no" };

        public string ReadString(string[] validStrings)
        {
            validStrings = validString;
            if (validStrings[0] == "yes")
            {
                Console.ReadLine();
            }
            else if (validStrings[0] == "no")
            {
                Console.ReadLine();
            }

            return null;
        }

        public void Sound(SoundTipes sound)
        {
            switch (sound)
            {
                case SoundTipes.Lose:
                    _speaker.Lose();
                    break;

                case SoundTipes.Bad:
                    _speaker.Bad();
                    break;

                case SoundTipes.Win:
                    _speaker.Win();
                    break;

                case SoundTipes.Good:
                    _speaker.Good();
                    break;

                case SoundTipes.Tie:
                    _speaker.Tie();
                    break;

                case SoundTipes.Step:
                    _speaker.Step();
                    break;

                case SoundTipes.Error:
                    _speaker.Error();
                    break;

                case SoundTipes.Music:
                    _speaker.Music();
                    break;
            }
        }
    }
}