using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;


//TODO: Ezt egy külön projectbe kellene átrakni egy másik namespacebe pl: szamkitjat.UI.Console
namespace szamkitjatUIs.UI
{
    public class UI : IGameUI
    {
        ConsoleColor _defaultForeground = ConsoleColor.White;
        ConsoleColor _defaultBackground = ConsoleColor.Black;
        ISound _sound;

        public UI(ISound sound)
        {
            _sound = sound;
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
        public string ReadString(int stringLength) => Console.ReadLine();
        public string ReadString(string[] validStrings) => Console.ReadLine();


        public void Sound(SoundTipes sound)
        {
            switch (sound)
            {
                case SoundTipes.Lose:
                    break;
                case SoundTipes.Bad:
                    break;
                case SoundTipes.Win:
                    break;
                case SoundTipes.Good:
                    break;
                case SoundTipes.Tie:
                    break;
                case SoundTipes.Step:
                    break;
                case SoundTipes.Error:
                    break;
                case SoundTipes.Music:
                    break;
            }
            
        }
    }
}
