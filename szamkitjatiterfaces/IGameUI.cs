using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjatiterfaces
{
    public interface IGameUI
    {
        void Clear();
        void Clear(ConsoleColor foreground, ConsoleColor background);
        void Print(string szoveg, ConsoleColor foreground, ConsoleColor background); 
        void Print(string szoveg);
        void Print(string szoveg, ConsoleColor foreground);
        void PrintBcg(string szoveg, ConsoleColor background);
        void PrintLN(string szoveg, ConsoleColor foreground, ConsoleColor background);
        void PrintLN(string szoveg);
        void PrintLN(string szoveg, ConsoleColor foreground);
        void PrintLNBcg(string szoveg, ConsoleColor background);
        string ReadLine { get; }

        void ReadKey();
        char ReadKeyTrue { get; }

        //TODO:
        bool ReadKey(char trueChar = 'y', char falseChar = 'n');
        uint ReadNumber();

        string ReadString(int stringLength);
        string ReadString(string[] validStrings);
    }
}
