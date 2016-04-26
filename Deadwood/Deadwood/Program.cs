/*
 *  Main Deadwood driver source code
 *  Copyright (c) Yulo Leake 2016
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



            while (true)
            {

            }
        }
    }
}
