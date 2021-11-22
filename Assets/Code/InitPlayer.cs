using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Asteroid
{
    public class InitPlayer : IInitPlayer
    {
        public IInput Input { get; }
        public IShip Player { get; }
        public InitPlayer(IInput input, IShip player)
        {
            Input = input;
            Player = player;
        }

    }
}
