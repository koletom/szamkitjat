using Microsoft.Extensions.DependencyInjection;
using System;
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
            IServiceProvider serviceProvider = null;
            var services = new ServiceCollection();

            services.AddSingleton<ISound, Hang>()
                    .AddSingleton<IGameUI, UI>()
                    .AddSingleton<IGame, Amoba>()
                    .AddSingleton<IGame, Kitalalos>()
                    .AddSingleton<IGame, HuszonegyKartya>()
                    .AddSingleton<IGame, KoPapirOllo>()
                    .AddSingleton<IGameController, Game>(x => new Game(serviceProvider));

            serviceProvider = services.BuildServiceProvider();

            var gamecontroll = serviceProvider.GetRequiredService<IGameController>();
            IGameUI ui = serviceProvider.GetRequiredService<IGameUI>();

            gamecontroll.Kezdes();
            ui.Sound(SoundTipes.Music);
            gamecontroll.Ending();
            ui.Sound(SoundTipes.Music);
        }
    }
}