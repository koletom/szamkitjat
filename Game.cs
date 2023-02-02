using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using szamkitjatiterfaces;

namespace szamkitjat
{
    public class Game : IGameController
    {
        private List<IGame> _games = new List<IGame>();

        private IGameUI _gameUI;
        private IServiceProvider _services;
        public Game(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException();
            _gameUI = _services.GetService<IGameUI>() ?? throw new ArgumentNullException();
            _services.GetServices<IGame>().ToList().ForEach(g => { Add(g); });
        }

        public void Kezdes()
        {
            //int wins = 0;
            _gameUI.Clear(ConsoleColor.DarkBlue, ConsoleColor.Cyan);
            _gameUI.Sound(SoundTipes.Music);
            _gameUI.PrintLN("Üdv a Játékok Univerzumában\n");
            _gameUI.Sound(SoundTipes.Music);
            if (_games is null || _games.Count == 0)
            {
                _gameUI.PrintLN("Nincs érték");
                return;
            }

            char valasztas;
            do
            {
                sbyte jatekmod = -1;

                _gameUI.Clear(ConsoleColor.DarkBlue, ConsoleColor.Cyan);

                _gameUI.PrintLN($"Az alábbi {_games.Count} játékmód közül lehet válsztani\n");

                for (int i = 0; i < _games.Count; i++)
                {
                    _gameUI.PrintLN($"{i} -> {_games[i].Name}");
                }

                _gameUI.PrintLN("\nX -> Kilépés a játék univerzumból\n");
                _gameUI.PrintLN($"Válassz játékmódot / Add meg a játékmód számát (0-{_games.Count - 1})");

                valasztas = _gameUI.ReadKeyTrue;

                if (sbyte.TryParse(((char)valasztas).ToString(), out jatekmod))
                {
                    if (jatekmod >= 0 && jatekmod < _games.Count)
                    {
                        PlayGame(_games[jatekmod]);
                    }
                }
                _gameUI.Clear();
            } while (char.ToUpper(valasztas) != 'X');
        }

        public void Ending()
        {
            _gameUI.PrintLN("Viszlát");
        }

        private void PlayGame(IGame selectedGame)
        {
            char c;
            do
            {
                selectedGame.Start();
                selectedGame.Play();
                selectedGame.End();

                _gameUI.PrintLN($"Akarsz újra {selectedGame.Name} játékkal játszani? (i/n)");

                c = _gameUI.ReadKeyTrue;
            } while (char.ToUpper(c) == 'I');

            _gameUI.Sound(SoundTipes.Music);
        }

        public IGameController Add(IGame game)
        {
            if (_games == null)
            {
                throw new NullReferenceException();
            }
            _games.Add(game);
            return this;
        }
    }
}