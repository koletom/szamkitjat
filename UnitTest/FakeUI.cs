using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;

namespace UnitTest
{
    //TODO: ennek az osztálynak üresnek kellett volna maradni de legalábbis Console -al nem kellene semmit csinálnia
    public class FakeUI : IGameUI
    {
        List<string> _testSteps = new List<string>();
        public List<string> TestSteps => _testSteps;
        public string ReadLine => "";

        public char ReadKeyTrue => ' ';

        public void Clear()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}");
        }

        public void Clear(ConsoleColor foreground, ConsoleColor background)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:|bg:{background}");
        }

        public void Print(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}|fg:{foreground}|bg:{background}");
        }

        public void Print(string szoveg)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}");
        }

        public void Print(string szoveg, ConsoleColor foreground)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}|fg:{foreground}");
        }

        public void PrintBcg(string szoveg, ConsoleColor background)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}|bg:{background}");
        }

        public void PrintLN(string szoveg, ConsoleColor foreground, ConsoleColor background)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}|fg:{foreground}|bg:{background}");
        }

        public void PrintLN(string szoveg)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}");
        }

        public void PrintLN(string szoveg, ConsoleColor foreground)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}|fg:{foreground}");
        }

        public void PrintLNBcg(string szoveg, ConsoleColor background)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{szoveg}|bg:{background}");
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
