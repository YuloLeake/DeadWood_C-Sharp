/*
 *  Board class that is in charge of keeping game and player informations.
 *  Copyright (c) Yulo Leake 2016
 */

using System;
using System.Collections.Generic;

namespace Deadwood.Model
{
    class Board
    {
        // Singleton Construction
        private Board()
        {
        }

        private static Board instance;
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

        private List<Player> playerList;
        public Player currentPlayer { get; private set; }
        public int playerCount { get; private set; }

        private Random rng;

        Dictionary<string, int> roomToIndex;
        string[] roomnames;
        bool[,] roomAdjMat;

        // TODO: replace this with current player
        int playerMocLoc = 0;   // just a mock to make sure movement is working correct

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
            SetUpPlayers(playerCount);

            playerMocLoc = roomToIndex["Trailers"];
        }

        private void SetUpRooms()
        {
            // TODO: define room names in XML or something
            roomnames = new string[]{"Train Station", "Jail", "General Store",
                                     "Ranch", "Casting Office", "Secret Hideout",
                                     "Main Street", "Saloon", "Trailers",
                                     "Bank", "Church", "Hotel" };
            roomToIndex = new Dictionary<string, int>(roomnames.Length);
            for (int i = 0; i < roomnames.Length; i++)
            {
                roomToIndex.Add(roomnames[i], i);
            }
        }

        private void SetUpAdjMat()
        {
            // TODO: define room adjacency in XML or something
            // TODO: probably move this responsibility to the actual Room class
            roomAdjMat = new bool[roomnames.Length, roomnames.Length];

            int i = roomToIndex["Train Station"];
            List<int> list = new List<int>(3);
            list.Add(roomToIndex["Jail"]);
            list.Add(roomToIndex["General Store"]);
            list.Add(roomToIndex["Casting Office"]);
            foreach(int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Jail"];
            list.Clear();
            list.Add(roomToIndex["Main Street"]);
            list.Add(roomToIndex["General Store"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Main Street"];
            list.Clear();
            list.Add(roomToIndex["Saloon"]);
            list.Add(roomToIndex["Trailers"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["General Store"];
            list.Clear();
            list.Add(roomToIndex["Ranch"]);
            list.Add(roomToIndex["Saloon"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Saloon"];
            list.Clear();
            list.Add(roomToIndex["Bank"]);
            list.Add(roomToIndex["Trailers"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Trailers"];
            list.Clear();
            list.Add(roomToIndex["Hotel"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Casting Office"];
            list.Clear();
            list.Add(roomToIndex["Ranch"]);
            list.Add(roomToIndex["Secret Hideout"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Ranch"];
            list.Clear();
            list.Add(roomToIndex["Bank"]);
            list.Add(roomToIndex["Secret Hideout"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Bank"];
            list.Clear();
            list.Add(roomToIndex["Hotel"]);
            list.Add(roomToIndex["Church"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Secret Hideout"];
            list.Clear();
            list.Add(roomToIndex["Church"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndex["Church"];
            list.Clear();
            list.Add(roomToIndex["Hotel"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }
        }

        private void SetUpPlayers(int count)
        {
            this.playerList = new List<Player>(count);
            string[] colors = {"blue", "cyan", "green", "orange", "pink", "red", "violet", "yellow"}; // used as name for players
            int startingCred = 0;
            int startingRank = 0;

            // TODO: do stuff based on the number of players

            // Create prototype of Player with same starting credit and rank, clone prototype with different names
            Player proto = Player.MakePrototype(startingCred, startingRank);
            for (int i = 0; i < count; i++)
            {
                playerList.Add(proto.Clone(colors[i]));
            }
        }

        // Return list of roomnames that is adjacent to current player's room
        public List<string> GetAdjacentRooms()
        {
            // TODO: make sure to remove mock location and change to current player
            string roomname = roomnames[playerMocLoc];
            return GetAdjacentRooms(roomname);
        }

        // Return list of roomnames that is adjacent to given room name
        public List<string> GetAdjacentRooms(string roomname)
        {
            // Check if roomname given is a valid roomname
            if (roomToIndex.ContainsKey(roomname) == false)
            {
                Console.Error.WriteLine("Error: room \"{0}\" does not exist", roomname);
                return null;
            }

            // Create list and add all adjacent rooms
            List <string> list = new List<string>();
            int i = roomToIndex[roomname];
            for(int j = 0; j < roomnames.Length; j++)
            {
                if(roomAdjMat[i, j])
                {
                    list.Add(roomnames[j]);
                }
            }
            return list;
        }

        // Player moves
        public void Move(string dst)
        {
            // Check if destination room is valid
            if (roomToIndex.ContainsKey(dst) == false)
            {
                Console.Error.WriteLine("Error: room \"{0}\" does not exist", dst);
                return;
            }

            // TODO: Actually move player
            if (roomAdjMat[playerMocLoc, roomToIndex[dst]])
            {
                // Destination room is adjacent, move player there
                playerMocLoc = roomToIndex[dst];
                Console.WriteLine("Moved to \"{0}\"", dst);
            }
            else
            {
                // Destination room is NOT adjacent, throw error
                // TODO: actually throw errow?
                Console.Error.WriteLine("Error: room \"{0}\" is not adjacent to \"dst\".", dst, roomnames[playerMocLoc]);
                return;
            }
        }

    }
}
