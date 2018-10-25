using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    interface IWalkAway //Naming convention is to start interfaces always with an uppercase letter.
    {
        void WalkAway(Player player);
    }
}
