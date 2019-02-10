using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Battleship.Coordinates;
using Battleship.Ships;

namespace Battleships.Players
{
    public class Player : IPlayer
    {
        PlayerBoard board = new PlayerBoard();
        bool isHorizontal;

        /// <summary>
        /// The constructor for Player.
        /// </summary>
        public Player()
        {
            Console.WriteLine("----You are now entering \"ADD\" mode----");
            AddShipToBoard();

            Console.WriteLine("----You are now entering \"ATTACK\" mode----");
            
            /*
             * Iterating through 5 times as there is no persistence layer.
             * This allows the user to potentially have their whole ship attacked and therefore lose the game.
             */
            for (int i = 0; i < 5; i++)
            {
                AttackPosition();
            }

            Console.WriteLine("----All moves have now been played. Checking the result.----");
            string result = board.checkIfLost() ? "You did not win this round." : "Congratulations! You won!";
            Console.WriteLine(result);
        }

        /// <summary>
        /// This method is used to add a ship to the board.
        /// </summary>
        public void AddShipToBoard()
        {

            Console.WriteLine("Please enter the ship type below.");
            string shipType = Console.ReadLine();
            #region Data Validation
            // Validate the response before continuing
            if (string.IsNullOrEmpty(shipType))
                    throw new ArgumentNullException("The provided ship type cannot be null or empty. Please try again.");

            if (!shipType.ToLower().Equals("cr") &&
                !shipType.ToLower().Equals("ca") &&
                !shipType.ToLower().Equals("b") &&
                !shipType.ToLower().Equals("d") &&
                !shipType.ToLower().Equals("s"))
            {
                Console.WriteLine("wrong ship type");
                throw new ArgumentOutOfRangeException(
                    string.Format("The shipType \"{0}\" falls out of the accepted range. Please try again.", shipType));
            }

            /*
             * For the user's experience this could be turned to use a switch statement (as one example)
             * to pull the full name of the chosen ship type.
            */
            Console.WriteLine("The chosen ship type is: " + shipType);
            #endregion

            Console.WriteLine("Please note as Y or N if the ship will be added horizontally:");
            string response = Console.ReadLine();
            #region Data Validation
            // Validate the response before continuing
            if (string.IsNullOrEmpty(response))
                    throw new ArgumentNullException("The provided response cannot be null or empty. Please try again.");

            if (!response.ToUpper().Equals("Y") &&
                !response.ToUpper().Equals("N"))
                throw new ArgumentOutOfRangeException(
                    string.Format("The response \"{0}\" falls out of the accepted range. Please try again.", response.ToUpper()));

            isHorizontal = (response.ToUpper().Equals("Y")) ? true : false;
            #endregion

            string row, column;
            int rowID, columnID;

            /*
             * These statements iterate through and return the size of the current type of ship, so
             * that the user can place the right number of pieces onto the board.
             * This was done intentionally so that if the size was to change in the derived ship classes,
             * then this code would not need to be modified.
             * 
             * Keeping in mind all Console.ReadLine's could have data validation included, I have for the
             * purposes of this test tried to keep things simple and only included validation at the very
             * beginning, as well as a try-catch here should any step fail while parsing the data.
            */
            try
            {
                if (shipType.ToLower().Equals("ca"))
                {
                    Carrier carrier = new Carrier();

                    if (isHorizontal)
                    {
                        Console.WriteLine("Please enter the first number for your selected row: ");
                        row = Console.ReadLine();
                        rowID = int.Parse(row);
                        Console.WriteLine("This will now remain the row that you can add items to.");

                        // Add as many items as necessary
                        for (int i = 0; i < carrier.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            column = Console.ReadLine();
                            columnID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter the first NUMBER for your selected column: ");
                        column = Console.ReadLine();
                        columnID = int.Parse(column);
                        Console.WriteLine("This will now remain the column that you can add items to.");

                        for (int i = 0; i < carrier.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            row = Console.ReadLine();
                            rowID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                }
                else if (shipType.ToLower().Equals("cr"))
                {
                    Cruiser cruiser = new Cruiser();

                    if (isHorizontal)
                    {
                        Console.WriteLine("Please enter the first number for your selected row: ");
                        row = Console.ReadLine();
                        rowID = int.Parse(row);
                        Console.WriteLine("This will now remain the row that you can add items to.");

                        for (int i = 0; i < cruiser.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            column = Console.ReadLine();
                            columnID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter the first NUMBER for your selected column: ");
                        column = Console.ReadLine();
                        columnID = int.Parse(column);
                        Console.WriteLine("This will now remain the column that you can add items to.");

                        for (int i = 0; i < cruiser.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            row = Console.ReadLine();
                            rowID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                }
                else if (shipType.ToLower().Equals("b"))
                {
                    TheBattleship battleship = new TheBattleship();

                    if (isHorizontal)
                    {
                        Console.WriteLine("Please enter the first number for your selected row: ");
                        row = Console.ReadLine();
                        rowID = int.Parse(row);
                        Console.WriteLine("This will now remain the row that you can add items to.");

                        for (int i = 0; i < battleship.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            column = Console.ReadLine();
                            columnID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter the first NUMBER for your selected column: ");
                        column = Console.ReadLine();
                        columnID = int.Parse(column);
                        Console.WriteLine("This will now remain the column that you can add items to.");

                        for (int i = 0; i < battleship.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            row = Console.ReadLine();
                            rowID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                }
                else if (shipType.ToLower().Equals("d"))
                {
                    Destroyer destroyer = new Destroyer();

                    if (isHorizontal)
                    {
                        Console.WriteLine("Please enter the first number for your selected row: ");
                        row = Console.ReadLine();
                        rowID = int.Parse(row);
                        Console.WriteLine("This will now remain the row that you can add items to.");

                        for (int i = 0; i < destroyer.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            column = Console.ReadLine();
                            columnID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter the first NUMBER for your selected column: ");
                        column = Console.ReadLine();
                        columnID = int.Parse(column);
                        Console.WriteLine("This will now remain the column that you can add items to.");

                        for (int i = 0; i < destroyer.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            row = Console.ReadLine();
                            rowID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                }
                else if (shipType.ToLower().Equals("s"))
                {
                    Submarine submarine = new Submarine();

                    if (isHorizontal)
                    {
                        Console.WriteLine("Please enter the first number for your selected row: ");
                        row = Console.ReadLine();
                        rowID = int.Parse(row);
                        Console.WriteLine("This will now remain the row that you can add items to.");

                        for (int i = 0; i < submarine.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            column = Console.ReadLine();
                            columnID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter the first NUMBER for your selected column: ");
                        column = Console.ReadLine();
                        columnID = int.Parse(column);
                        Console.WriteLine("This will now remain the column that you can add items to.");

                        for (int i = 0; i < submarine.size; i++)
                        {
                            Console.WriteLine("Please enter the next NUMBER for your selected column: ");
                            row = Console.ReadLine();
                            rowID = int.Parse(column);

                            board.addShip(rowID, columnID);
                        }
                    }
                    Console.WriteLine("You've updated your board.");
                    Console.WriteLine(String.Format("The board coordinates are as follows:\n{0}", board.coordinates));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Allows the user to attack a specific tile.
        /// 
        /// This method does not ask for whether you are attacking horizontally/ vertically,
        /// as it is assumed the user can attack whatever coordinate they would like.
        /// </summary>
        public void AttackPosition()
        {
            Console.WriteLine("Please choose the row that you would like to attack.");
            string row = Console.ReadLine();
            int rowID = int.Parse(row);

            Console.WriteLine("Please choose the column that you would like to attack.");
            string column = Console.ReadLine();
            int columnID = int.Parse(column);

            board.attack(rowID, columnID);
        }
    }
}