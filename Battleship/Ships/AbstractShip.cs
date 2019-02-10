using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Coordinates;

namespace Battleship.Ships
{
    /// <summary>
    /// Creating an abstract class to use for generation of ship models.
    /// 
    /// The reasoning behind using an abstract and not an interface is to allow future inclusion
    /// of generic, shared methods to be added here.
    /// </summary>
    public abstract class AbstractShip
    {
        public string title { get; set; }
        public int size { get; set; }

        // To work on this later
        PlayerBoard coords = new PlayerBoard();

        public bool hasSunk(int size, int hitCount)
        {
            return (size >= hitCount) ? true : false;
        }
    }
}