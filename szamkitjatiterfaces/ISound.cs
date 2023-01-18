using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamkitjatiterfaces
{
    public interface ISound
    {
        void Lose();
        void Bad();
        void Win();
        void Good();
        void Tie();
        void Step();
        void Error();
        void Music();
    }
}
