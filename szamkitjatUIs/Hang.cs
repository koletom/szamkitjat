using Microsoft.Extensions.DependencyInjection;
using System;
using szamkitjatiterfaces;

namespace szamkitjatUIs
{
    public class Hang : ISound
    {
        private static int[] DO = new int[] { 131, 262, 523, 1046 };
        private static int[] RE = new int[] { 147, 294, 587, 1174 };
        private static int[] MI = new int[] { 165, 330, 659, 1318 };
        private static int[] FA = new int[] { 175, 349, 698, 1396 };
        private static int[] SO = new int[] { 196, 392, 784, 1568 };
        private static int[] LA = new int[] { 220, 440, 880, 1760 };
        private static int[] TI = new int[] { 247, 494, 988, 1976 };

        public void Lose()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(MI[oct2], 200);
                Console.Beep(DO[oct1], 200);
                Console.Beep(FA[oct1], 800);
            }
        }

        public void Bad()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(DO[oct1], 200);
                Console.Beep(FA[oct1], 800);
            }
        }

        public void Win()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(SO[oct1], 200);
                Console.Beep(RE[oct2], 200);
                Console.Beep(DO[oct3], 800);
            }
        }

        public void Good()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(RE[oct2], 200);
                Console.Beep(DO[oct3], 800);
            }
        }

        public void Tie()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(TI[oct1], 200);
                Console.Beep(TI[oct1], 800);
            }
        }

        public void Step()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(RE[oct3], 200);
            }
        }

        public void Error()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(TI[oct4], 300);
                Console.Beep(TI[oct4], 400);
            }
        }

        public void Music()
        {
            int oct1 = 0;
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;

            for (int i = 0; i < 1; i++)
            {
                Console.Beep(SO[oct2], 250);
                Console.Beep(SO[oct3], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(DO[oct3], 250);
                Console.Beep(DO[oct4], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(TI[oct3], 250);
                Console.Beep(RE[oct3], 250);
            }
        }
    }
}