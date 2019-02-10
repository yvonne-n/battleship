using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Players
{
    /// <summary>
    /// This is a simple Interface used to create a Player.
    /// </summary>
    interface IPlayer
    {
        void AddShipToBoard();
        void AttackPosition();
    }
}