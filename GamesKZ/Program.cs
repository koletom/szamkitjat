using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjat;
using szamkitjatUIs;
using szamkitjatUIs.UI;
using szamkitjatiterfaces;

namespace szamkitjat
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameUI ui = new UI(new Hang()); 

            var gamecontroll = new Game(ui);

            gamecontroll.Add(new Amoba(ui))
            .Add(new Kitalalos(ui))
            .Add(new HuszonegyKartya(ui))
            .Add(new KoPapirOllo(ui));

            gamecontroll.Kezdes();
            ui.Sound(SoundTipes.Music);
            gamecontroll.Ending();
            ui.Sound(SoundTipes.Music);

        }
    }
}

