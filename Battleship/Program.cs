using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Coordinates;
using Battleships.Players;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleships!");
            Player p1 = new Player();

            // Leaving this here so that the console does not close unexpectedly.
            Console.ReadLine();
        }
    }
}