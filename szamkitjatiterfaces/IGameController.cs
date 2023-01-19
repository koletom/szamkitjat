using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjatiterfaces
{
    public interface IGameController
    {
        void Kezdes();
        void Ending();

        IGameController Add(IGame game);
    }
}
