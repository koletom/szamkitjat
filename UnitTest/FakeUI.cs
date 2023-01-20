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
        public string ReadLine => "";

        public char ReadKeyTrue => ' ';

        public void Clear()
        {
            
        }

        public void Clear(ConsoleColor foreground, ConsoleColor background)
        {
            
        }

        public void Print(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            
        }

        public void Print(string szoveg)
        {
            
        }

        public void Print(string szoveg, ConsoleColor foreground)
        {
            
        }

        public void PrintBcg(string szoveg, ConsoleColor background)
        {
            
        }

        public void PrintLN(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            
        }

        public void PrintLN(string szoveg)
        {
            
        }

        public void PrintLN(string szoveg, ConsoleColor foreground)
        {
            
        }

        public void PrintLNBcg(string szoveg, ConsoleColor background)
        {
            
        }

        public void ReadKey()
        {
            
        }

        public bool? ReadKey(char trueChar = 'y', char falseChar = 'n')
        {
            return null;
        }

        public uint? ReadNumber()
        {
            return null;
        }

        public string ReadString(int stringLength)
        {
            return null;
        }

        public string ReadString(string[] validStrings)
        {
            return null;
        }

        public void Sound(SoundTipes sound)
        {
            
        }
    }
}
