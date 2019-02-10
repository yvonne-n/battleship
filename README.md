
This solution was developed with the primary goal to create a Battleship framework that is simple, easily testable, extensible, and readable.

The following logic was built into this program:
	1) A single board is created for the user.
	2) A single battleship can be added to the board, and depending on the type of battleship determines the size of the ship you can add.
	3) Once a ship has been added, the user goes immediately into "Attack" mode as there is no persistence. As the user specifies which
	coordinate they want to hit, they get a response telling them whether they have hit or not.
	4) Once all 5 turns at attacking have taken place, the user is notified as to whether all battleships have been sunk (i.e. the player lost),
	or if they still have pieces surviging on the board.

The reasoning behind the 5 turns to attack is it's the size of the largest type of ship possible on the board.

Where possible I have implemented either abstract classes or interfaces to make sure that the design was following all necessary requirements.

Please note, instructions for the game (regarding sizing and general guidelines) were
taken from the following site, as well as the email: https://www.thesprucecrafts.com/the-basic-rules-of-battleship-411069

Thankyou for taking the time to review my code!