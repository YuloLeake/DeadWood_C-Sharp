/*
 *  Main Deadwood driver source code
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model;
using Deadwood.Model.Exceptions;
using Deadwood.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deadwood
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Deadwood!");
            // Handle player count argument
            int playerCount  = 0;
            string userInput = "";
            if (args.Length < 1)
            {
                Console.WriteLine("How many players [2, 8]? ");
                Console.Write("> ");
                userInput = Console.ReadLine();
            }
            else
            {
                userInput = args[0];
            }
            try
            {
                playerCount = int.Parse(userInput);
            }
            catch (System.FormatException e)
            {
                Console.Error.WriteLine("Error: Argument given was not an integer.\nPlease pass in an integer [2, 8]");
                Environment.Exit(1);
            }
            if(2 > playerCount || playerCount > 8)
            {
                Console.Error.WriteLine("Error: Player size has to be in range of [2, 8]");
                Environment.Exit(1);
            }
            Console.WriteLine(playerCount + " palyers are starting Deadwood");

            Deadwood game = new YuloDeadwood(playerCount);
            string input;
            do
            {
                input = Console.ReadLine();
                processUserInput(game, input.ToLower());
            }
            while (input != null && !game.IsGameOver());
            Console.WriteLine("Exiting Deadwood");
        }

        static void processUserInput(Deadwood game, string cmd)
        {
            switch (cmd)
            {
                case "who":
                    game.Who();
                    break;
                case "where":
                    game.Where();
                    break;
                case "act":
                    game.Act();
                    break;
                case "rehearse":
                    game.Rehearse();
                    break;
                case "end":
                    game.End();
                    break;

                case "list":
                    game.List();
                    break;
                case "listall":
                    game.ListAll();
                    break;
                case "adj":
                    game.PrintAdjacentsRooms();
                    break;

                case "move":
                    game.Move();
                    break;
                case "work":
                    //Console.WriteLine("Input role name");
                    //string role = Console.ReadLine().ToLower().Trim();
                    game.Work();
                    break;
                case "upgrade":
                    Console.WriteLine("");
                    break;

                case "help":
                    game.PrintHelp();
                    break;
                case "quit":
                    game.QuitGame();
                    break;

                default:
                    Console.Error.WriteLine("Unknown command \"" + cmd + "\" given.\nType \"help\" to see all available commands");
                    break;
            }
        }
    }

    /*
     *  Abstract Deadwood class to implement the game logic
     */
    abstract class Deadwood
    {
        public abstract bool IsGameOver();
        public abstract void Who();
        public abstract void Where();
        public abstract void Move();
        public abstract void Work();
        public abstract void Rehearse();
        public abstract void Act();
        public abstract void End();
        public abstract void List();
        public abstract void ListAll();
        public abstract void PrintAdjacentsRooms();
        public abstract void UpgradeDollars(int level);
        public abstract void UpgradeCredits(int level);

        public void QuitGame()
        {
            Console.WriteLine("Are you sure you want to quit? y/n");
            string input = Console.ReadLine().ToLower().Trim();
            switch (input)
            {
                case "y":
                    Environment.Exit(0);
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Input unknown, not ending game.");
                    break;
            }
        }

        public void PrintHelp()
        {
            Console.WriteLine("List of available commands:");
            Console.WriteLine("\twho           | Display information about current player.");
            Console.WriteLine("\twhere         | Display information about current player's whereabout.");

            Console.WriteLine("\tmove          | Prompt the game to move.");
            Console.WriteLine("\tmove room     | Move current player to given room (if valid).");

            Console.WriteLine("\twork          | Prompt the game to work a role.");
            Console.WriteLine("\twork role     | Take up a given role in current room.");

            Console.WriteLine("\tupgrade       | Prompt the game to upgrade current player.");
            Console.WriteLine("\tupgrade $ lvl | Upgrade current player using money.");
            Console.WriteLine("\tupgrade c lvl | Upgrade current player using credit points.");

            Console.WriteLine("\tact           | Act current role.");
            Console.WriteLine("\trehearse      | Rehearse current role.");
            Console.WriteLine("\tend           | End this turn.");

            Console.WriteLine("\tadj           | Display a list of adjacent rooms.");
            Console.WriteLine("\tlist          | Display a list of available roles in current room.");
            Console.WriteLine("\tlistall       | Display a list of all roles in current room.");

            Console.WriteLine("\thelp          | Display available commands.");
            Console.WriteLine("\tquit          | Quit the game.");
        }
    }

    /*
     *  Dummy Deadwood class that prints stuff based on user input
     */
    class DummyDeadwood : Deadwood
    {
        private bool isGameOver = false;
        public override bool IsGameOver()
        {
            return isGameOver;
        }

        public override void Act()
        {
            Console.WriteLine("Acting deals with very delicate emotions.");
            Console.WriteLine("It is not putting up a mask.");
            Console.WriteLine("Each time an actor acts he does not hide; he exposes himself.");
            Console.WriteLine("                                        ---Rodney Dangerfield");
        }

        public override void End()
        {
            Console.WriteLine("But all the magic I have known");
            Console.WriteLine("I've had to make myself.");
            Console.WriteLine("           ---Shel Silverstein");
            isGameOver = true;
        }

        public override void List()
        {
            Console.WriteLine("List roles in current room");
        }

        public override void ListAll()
        {
            Console.WriteLine("List roles in all room");
        }

        public override void Move()
        {
            Console.WriteLine("We keep moving forward, opening new doors, and doing new things,    ");
            Console.WriteLine("because we're curious and curiosity keeps leading us down new paths.");
            Console.WriteLine("                                                      ---Walt Disney");
        }

        public override void PrintAdjacentsRooms()
        {
            Console.WriteLine("List adjacent Rooms");
        }

        public override void Rehearse()
        {
            Console.WriteLine("Life is not a dress rehearsal.");
            Console.WriteLine("              ---Rose Tremain");
        }

        public override void UpgradeCredits(int level)
        {
            Console.WriteLine("Upgrade to {0} with credits\n", level);
        }

        public override void UpgradeDollars(int level)
        {
            Console.WriteLine("Upgrade to {0} with dollars\n", level);
        }

        public override void Where()
        {
            Console.WriteLine("If you don't know where you are going,");
            Console.WriteLine("you might wind up someplace else.     ");
            Console.WriteLine("                         ---Yogi Berra");
        }

        public override void Who()
        {
            Console.WriteLine("Who...are...you?\n ---The Caterpillar");
        }

        public override void Work()
        {
            Console.WriteLine("Coming together is a beginning;");
            Console.WriteLine("keeping together is progress;  ");
            Console.WriteLine("working together is success.   ");
            Console.WriteLine("                  ---Henry Ford");
        }
    }

    /*
     *  Main Deadwood implementation
     */
    class YuloDeadwood : Deadwood
    {
        private Board board;
        public YuloDeadwood(int playerCount)
        {
            board = Board.mInstance;
            Random rng = new Random();
            board.SetUpBoard(playerCount, rng); 
        }

        private bool isGameOver = false;
        public override bool IsGameOver()
        {
            return isGameOver;
        }

        public override void Act()
        {
            board.Act();
        }

        public override void End()
        {
            board.EndTurn();
        }

        public override void List()
        {
            try
            {
                // Get both starring and extra roles
                string roomname = board.currentPlayer.room.name;
                List<Role> stars = board.GetAvailableStarringRoles(roomname);
                List<Role> extras = board.GetAvailableExtraRoles(roomname);
                Console.WriteLine("All available roles in \"{0}\"", roomname);
                // Print starring roles first
                ListRoles(stars, "\t{0}). Star - {1}", 1);

                // Print extra roles
                ListRoles(extras, "\t{0}). Extra - {1}", stars.Count + 1);
            }
            catch(IllegalRoomActionException e)
            {
                Console.WriteLine(e.msg);
            }
        }

        public override void ListAll()
        {
            try
            {
                // Get both starring and extra roels
                string roomname = board.currentPlayer.room.name;
                List<Role> stars = board.GetAllStarringRoles(roomname);
                List<Role> extras = board.GetAllExtraRoles(roomname);
                Console.WriteLine("All roles in \"{0}\"", roomname);
                // Print starring roles first
                ListRoles(stars, "\t{0}). Star - {1}", 1);

                // Print extra roles
                ListRoles(extras, "\t{0}). Extra - {1}", stars.Count + 1);
            }
            catch (IllegalRoomActionException e)
            {
                Console.WriteLine(e.msg);
            }
        }

        // Move user to another room
        public override void Move()
        {
            // Print all adjacent rooms
            List<Room> list = board.GetAdjacentRooms();
            Console.WriteLine("Move player to:");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("\t{0}). {1}", i + 1, list[i].name);
            }
            Console.WriteLine("\t0). Cancel");
            
            // Get roomname user wants to move
            Console.Write("> ");
            string roomname = Console.ReadLine();

            // see if an input is numerical
            int num = 0;
            bool isNumeric = int.TryParse(roomname, out num);
            if (isNumeric)
            {
                // numerical input, use position in list
                if(num == 0)
                {
                    // User wishes to cancel out of the move.
                    return;
                }
                else if(num < 0 || num > list.Count)
                {
                    Console.WriteLine("Error: Numeric input out of index (make sure it's between 1 and {0})", list.Count);
                    return;
                }
                roomname = list[num - 1].name;
            }

            // Check to see if user wishes to cancel move
            if (roomname.Equals("Cancel"))
            {
                return;
            }

            // Move user
            board.Move(roomname);
        }

        public override void PrintAdjacentsRooms()
        {
            string currentRoom = board.currentPlayer.room.name;
            List<Room> list = board.GetAdjacentRooms();
            Console.WriteLine("Adjacent rooms to \"{0}\" are:", currentRoom);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("\t{0}). {1}", i + 1, list[i].name);
            }
        }

        public override void Rehearse()
        {
            board.Rehearse();
        }

        public override void UpgradeCredits(int level)
        {
            throw new NotImplementedException();
        }

        public override void UpgradeDollars(int level)
        {
            throw new NotImplementedException();
        }
        
        // Print where the current user is at
        public override void Where()
        {
            Player player = board.currentPlayer;
            Console.WriteLine("Player \"{0}\" is currently at \"{1}\".", player.name, player.room.name);
        }

        // Print Current user's info
        public override void Who()
        {
            Player p = board.currentPlayer;
            Console.WriteLine("Player \"{0}\".", p.name);
            Console.WriteLine("\tRoom: \"{0}\"", p.room.name);
            if (p.role == null)
            {
                Console.WriteLine("\tRole: No role");
            }
            else
            {
                Console.WriteLine("\tRole: \"{0}\"", p.role.name);
            }
            Console.WriteLine("\tRank: {0}", p.rank);
            Console.WriteLine("\tCredit: {0}cr", p.credit);
            Console.WriteLine("\tMoney: ${0}", p.money);
        }

        // List roles with given format and offset
        private void ListRoles(List<Role> roles, string format, int offset)
        {
            for (int i = 0; i < roles.Count; i++)
            {
                Console.WriteLine(format, i + offset, roles[i]);
            }
        }

        // User take a role
        public override void Work()
        {
            // Get available roles (stars and extras) and list them
            Player player = board.currentPlayer;
            string roomname = player.room.name;
            List<Role> stars;
            List<Role> extras;
            try
            {
                stars = board.GetAvailableStarringRoles(roomname);
                extras = board.GetAvailableExtraRoles(roomname);
            }
            catch (IllegalRoomActionException e)
            {
                // Empty roles, print error and return
                Console.WriteLine(e.msg);
                return;
            }

            // List available roles
            Console.WriteLine("Available roles:");
            ListRoles(stars, "\t{0}). Star - {1}", 1);
            ListRoles(extras, "\t{0}). Extra - {1}", stars.Count + 1);
            Console.WriteLine("\t0). Cancel");

            // Get user input for the part
            Console.Write("> ");
            string rolename = Console.ReadLine();
            List<Role> roles = stars.Concat(extras).ToList();   // Small enough lists, so no need to use AddRange()

            // see if an input is numerical
            int num = 0;
            bool isNumeric = int.TryParse(rolename, out num);
            if (isNumeric)
            {
                // numerical input, use position in list
                if (num == 0)
                {
                    // User wishes to cancel out of the move.
                    rolename = "Cancel";
                }
                else if (num < 0 || num > roles.Count)
                {
                    // Out of bound, print Error 
                    Console.WriteLine("Error: Numeric input out of index (make sure it's between 1 and {0})", roles.Count);
                    return;
                }
                else
                {
                    // Get the actual rolename
                    rolename = roles[num - 1].name;
                }
            }

            if (rolename.Equals("Cancel"))
            {
                // User wishes to cancel, print message and return
                Console.WriteLine("\tYou have canceled the selection");
                return;
            }

            // Take the part
            board.TakeRole(rolename);
        }
    }
}
