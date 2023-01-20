using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace UnitTest
{
    //TODO: ennek az osztálynak üresnek kellett volna maradni de legalábbis Console -al nem kellene semmit csinálnia
    public class FakeUI : IGameUI
    {
        public string ReadLine => Console.ReadLine();

        public char ReadKeyTrue => _ = Console.ReadKey(true).KeyChar;

        public void Clear()
        {
            Console.Clear();
        }

        public void Clear(ConsoleColor foreground, ConsoleColor background)
        {
            Console.Clear();
        }

        public void Print(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            Console.WriteLine();
        }

        public void Print(string szoveg)
        {
            Console.WriteLine();
        }

        public void Print(string szoveg, ConsoleColor foreground)
        {
            Console.WriteLine();
        }

        public void PrintBcg(string szoveg, ConsoleColor background)
        {
            Console.WriteLine();
        }

        public void PrintLN(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            Console.WriteLine();
        }

        public void PrintLN(string szoveg)
        {
            Console.WriteLine();
        }

        public void PrintLN(string szoveg, ConsoleColor foreground)
        {
            Console.WriteLine();
        }

        public void PrintLNBcg(string szoveg, ConsoleColor background)
        {
            Console.WriteLine();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }

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

        public string ReadString(int stringLength)
        {
            if (stringLength == 1)
            {
                Console.ReadLine();
            }
            return null;
        }

        public string ReadString(string[] validStrings)
        {
            string[] validString = { "yes", "no" };
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
            
        }
    }
}
