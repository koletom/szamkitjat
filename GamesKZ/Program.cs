using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using szamkitjat;
using szamkitjatiterfaces;
using szamkitjatUIs;
using szamkitjatUIs.UI;

namespace GameKZ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ISound, Hang>();
                    services.AddSingleton<IGameUI, UI>();

                    services.AddSingleton<IGame, Amoba>();
                    services.AddSingleton<IGame, Kitalalos>();
                    services.AddSingleton<IGame, HuszonegyKartya>();
                    services.AddSingleton<IGame, KoPapirOllo>();
                    
                    services.AddSingleton<IGameController, Game>(x => new Game(services.BuildServiceProvider()));

                }).Build();

            var gamecontroll = builder.Services.GetRequiredService<IGameController>();
            IGameUI ui = (builder.Services.GetRequiredService<IGameUI>());

            gamecontroll.Kezdes();
            ui.Sound(SoundTipes.Music);
            gamecontroll.Ending();
            ui.Sound(SoundTipes.Music);
        }

    }
}