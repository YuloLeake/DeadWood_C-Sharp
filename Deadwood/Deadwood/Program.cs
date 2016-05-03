﻿/*
 *  Main Deadwood driver source code
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model;
using System;
using System.Collections.Generic;

namespace Deadwood
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.Error.WriteLine("Error: Not enough arguments given.\nUsage: Deadwood playerCount");
                Environment.Exit(1);
            }

            // Handle player count argument
            int playerCount = 0;
            try
            {
                playerCount = Int32.Parse(args[0]);
            }
            catch (System.FormatException e)
            {
                Console.Error.WriteLine("Error: Argument given was not an integer.\nPlease pass in an integer (2-8)");
                Environment.Exit(1);
            }
            if(2 > playerCount || playerCount > 8)
            {
                Console.Error.WriteLine("Error: Player size has to be in range of [2,8]");
                Environment.Exit(1);
            }
            Console.WriteLine(playerCount + " palyers are starting Deadwood");

            Deadwood game = new YuloDeadwood(playerCount);
            string input;
            do
            {
                input = Console.ReadLine();
                Console.WriteLine("User input = " + input);

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
                    Console.WriteLine("Input role name");
                    string role = Console.ReadLine().ToLower().Trim();
                    game.Work(role);
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

    abstract class Deadwood
    {
        public abstract bool IsGameOver();
        public abstract void Who();
        public abstract void Where();
        public abstract void Move();
        public abstract void Work(string part);
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
            Console.WriteLine("Move to the \"" + "<room>" + "\"");
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

        public override void Work(string part)
        {
            Console.WriteLine("Work the \"" + part + "\" part");
        }
    }

    class YuloDeadwood : Deadwood
    {
        private Board b;
        public YuloDeadwood(int playerCount)
        {
            b = Board.mInstance;
            Random rng = new Random();
            b.SetUpBoard(playerCount, rng); 
        }

        private bool isGameOver = false;
        public override bool IsGameOver()
        {
            return isGameOver;
        }

        public override void Act()
        {
            Console.WriteLine("<Implementation needed to Act the role>");
        }

        public override void End()
        {
            Console.WriteLine("<Implementation needed to End current turn>");
        }

        public override void List()
        {
            Console.WriteLine("<Implementation needed to List roles>");
        }

        public override void ListAll()
        {
            Console.WriteLine("<Implementation needed to List all available roles>");
        }

        public override void Move()
        {
            List<string> list = b.GetAdjacentRooms();
            Console.WriteLine("Move player to:");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("\t{0}). {1}", i + 1, list[i]);
            }
            Console.Write("\t>");
            string input = Console.ReadLine();
            // TODO: allow numerical input?
            b.Move(input);
        }

        public override void PrintAdjacentsRooms()
        {
            Console.WriteLine("<Implementation needed to Print Adjacent rooms>");
        }

        public override void Rehearse()
        {
            Console.WriteLine("<Implementation needed to Rehearse role>");
        }

        public override void UpgradeCredits(int level)
        {
            throw new NotImplementedException();
        }

        public override void UpgradeDollars(int level)
        {
            throw new NotImplementedException();
        }

        public override void Where()
        {
            Player player = Board.mInstance.currentPlayer;
            Console.WriteLine("Player \"{0}\" is currently at \"{1}\".", player.name, player.room.name);
        }

        public override void Who()
        {
            Console.WriteLine("Current player is \"{0}\".", Board.mInstance.currentPlayer.name);
        }

        public override void Work(string part)
        {
            Console.WriteLine("<Implementation needed to Take a role>");
        }
    }
}
