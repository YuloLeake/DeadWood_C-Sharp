/*
 *  Main Deadwood driver source code
 *  Copyright (c) Yulo Leake 2016
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadwood.Model
{
    class Board
    {
        // Singleton Construction
        private static Board instance;

        private Board()
        {
        }

        public static Board mInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Board();
                }
                return instance;
            }
        }

        // Setting up board and its fields
        public int playerCount { get; private set; }
        private Random rng;

        string[] roomnames;
        bool[,] roomAdjMat;

        public void SetUpBoard(int playerCount, Random rng)
        {
            this.playerCount = playerCount;
            if(rng == null)
            {
                rng = new Random();
            }
            this.rng = rng;

            SetUpRooms();
            SetUpAdjMat();
        }

        private void SetUpRooms()
        {
            roomnames = new string[]{"Train Station", "Jail", "General Store",
                                     "Ranch", "Casting Office", "Secret Hideout",
                                     "Main Street", "Saloon", "Trailers",
                                     "Bank", "Church", "Hotel" };
        }

        private void SetUpAdjMat()
        {
            roomAdjMat = new bool[roomnames.Length, roomnames.Length];
        }




    }
}
