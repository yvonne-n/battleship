using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Coordinates
{
    public class PlayerBoard
    {
        public int[,] coordinates { get; set; }

        /// <summary>
        /// The PlayerBoard constructor.
        /// </summary>
        public PlayerBoard()
        {
            coordinates = new int[10,10];
            coordinates = setUpDefaultValues();
        }

        /// <summary>
        /// This sets up the base board for the user to play on.
        /// </summary>
        /// <returns>A board with all slots listed as empty (i.e. 0)</returns>
        private int[,] setUpDefaultValues()
        {
            for (int row = 0; row < coordinates.GetLength(0); row++)
            {
                for (int col = 0; col < coordinates.GetLength(1); col++)
                {
                    coordinates[row, col] = 0;
                }
            }

            return coordinates;
        }

        /// <summary>
        /// This method adds a ship to the current board.
        /// </summary>
        /// <param name="row">The row</param>
        /// <param name="col">The column</param>
        /// <returns></returns>
        public int[,] addShip(int row, int col)
        {
            coordinates[row, col] = 1;

            return coordinates;
        }

        /// <summary>
        /// This method attacks a specific coordinate on the board and returns the result.
        /// </summary>
        /// <param name="row">The row</param>
        /// <param name="col">The column</param>
        /// <returns></returns>
        public int[,] attack(int row, int col)
        {
            // if the attack has been done on a tile without a ship
            if ((coordinates[row, col] != 1))
            {
                Console.WriteLine("You missed.");
                coordinates[row, col] = 2;
            }
            else
            {
                Console.WriteLine("You hit!");
                coordinates[row, col] = 3;
            }

            return coordinates;
        }

        /// <summary>
        /// This method checks if the user has won or lost the game.
        /// </summary>
        /// <returns>A boolean stating true if the user has lost</returns>
        public bool checkIfLost()
        {
            bool hasLost = true;

            for (int row = 0; row < coordinates.GetLength(0); row++)
            {
                for (int col = 0; col < coordinates.GetLength(1); col++)
                {
                    if(coordinates[row, col] == 1)
                    {
                        hasLost = false;
                    }
                }
            }
            return hasLost;
        }
    }
}