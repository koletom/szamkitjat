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

        object _readResult = null;
        public object ReadResult
        {
            get => _readResult;
            set { _readResult = value; }
        }

        public string ReadLine
        {
            get
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                TestSteps.Add($"{m.Name}");
                return ReadResult as string ?? "";
            }
        }

        public char ReadKeyTrue 
        {
            get
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                TestSteps.Add($"{m.Name}");
                return (char)(ReadResult ?? ' ');
            }
        }

        public void Clear()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}");
        }

        public void Clear(ConsoleColor foreground, ConsoleColor background)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:fg:{foreground}|bg:{background}");
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
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}");
        }

        public bool? ReadKey(char trueChar = 'y', char falseChar = 'n')
        {
            return ReadResult as bool?;
        }

        public uint? ReadNumber()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}");
            return ReadResult as uint?;
        }

        public string ReadString(int stringLength)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}");
            return ReadResult as string;
        }

        public string ReadString(string[] validStrings)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{string.Join(";", validStrings)}");
            return ReadResult as string;
        }

        public void Sound(SoundTipes sound)
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            TestSteps.Add($"{m.Name}:{sound}");
        }
    }
}
