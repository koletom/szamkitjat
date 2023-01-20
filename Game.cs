using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szamkitjatiterfaces;
using szamkitjatUIs;

namespace szamkitjat
{
    public class Game : IGameController
    {
        private List<IGame> _games = new List<IGame>();
        
        IGameUI _gameUI;
        public Game(IGameUI gameUI)
        {
            _gameUI = gameUI;

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

        void PlayGame(IGame selectedGame)
        {
            char c;
            do
            {
                selectedGame.Start();
                selectedGame.Play();
                selectedGame.End();

                _gameUI.PrintLN($"Akarsz újra {selectedGame.Name} játékkal játszani? (i/n)");
                
                c = _gameUI.ReadKeyTrue;

            } while ( char.ToUpper(c) == 'I');

            _gameUI.Sound(SoundTipes.Music);
        }

        public IGameController Add(IGame game)
        {
            if (_games==null)
            {
                throw new NullReferenceException();
            }
            _games.Add (game);
            return this;
        }
    }
}
