/*
 *  Main Deadwood driver source code
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model;
using System;

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

            Deadwood game = new DummyDeadwood();
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
                    Console.WriteLine("Are you sure you want to quit? y/n");
                    string input = Console.ReadLine().ToLower().Trim();
                    switch (input)
                    {
                        case "y":
                            game.EndGame();
                            break;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Input unknown, not ending game.");
                            break;
                    }
                    break;

                case "list":
                    game.List();
                    break;
                case "listall":
                    game.ListAll();
                    break;
                case "adj":
                    game.PrintAdjacents();
                    break;
                case "help":
                    game.PrintHelp();
                    break;

                case "move":
                    Console.WriteLine("Input room name");
                    string room = Console.ReadLine().ToLower().Trim();
                    game.Move(room);
                    break;
                case "work":
                    Console.WriteLine("Input role name");
                    string role = Console.ReadLine().ToLower().Trim();
                    game.Work(role);
                    break;
                case "upgrade":
                    Console.WriteLine("");
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
        public abstract void Move(string to);
        public abstract void Work(string part);
        public abstract void Rehearse();
        public abstract void Act();
        public abstract void EndGame();
        public abstract void List();
        public abstract void ListAll();
        public abstract void PrintAdjacents();
        public abstract void UpgradeDollars(int level);
        public abstract void UpgradeCredits(int level);

        public void PrintHelp()
        {
            Console.WriteLine("List of available commands:");
            Console.WriteLine("\t<cmd> | <What it does>");
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

        public override void EndGame()
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

        public override void Move(string to)
        {
            Console.WriteLine("Move to the \"" + to + "\"");
        }

        public override void PrintAdjacents()
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
            throw new NotImplementedException();
        }

        public override void EndGame()
        {
            throw new NotImplementedException();
        }

        public override void List()
        {
            throw new NotImplementedException();
        }

        public override void ListAll()
        {
            throw new NotImplementedException();
        }

        public override void Move(string to)
        {
            throw new NotImplementedException();
        }

        public override void PrintAdjacents()
        {
            throw new NotImplementedException();
        }

        public override void Rehearse()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void Who()
        {
            throw new NotImplementedException();
        }

        public override void Work(string part)
        {
            throw new NotImplementedException();
        }
    }
}
