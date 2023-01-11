using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;


//TODO: Ezt egy külön projectbe kellene átrakni egy másik namespacebe pl: szamkitjat.UI.Console
namespace szamkitjat
{
    public class UI : IGameUI
    {
        ConsoleColor _defaultForeground = ConsoleColor.White;
        ConsoleColor _defaultBackground = ConsoleColor.Black;

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

    }
}
