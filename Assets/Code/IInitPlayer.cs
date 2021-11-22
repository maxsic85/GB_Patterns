using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Asteroid
{
    public interface IInitPlayer
    {
        IInput Input { get; }
        IShip Player { get; }
    }
}