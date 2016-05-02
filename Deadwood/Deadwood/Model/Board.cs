/*
 *  Board class that is in charge of keeping game and player informations.
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;
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

        // Player fields
        private List<Player> playerList;
        public Player currentPlayer { get; private set; }
        public int playerCount { get; private set; }

        private Random rng;

        // Room fields
        Dictionary<string, int> roomToIndexDict;
        Dictionary<string, Room> roomNameToRoomDict;
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

            playerMocLoc = roomToIndexDict["Trailers"];
        }

        private void SetUpRooms()
        {
            // TODO: define room names in XML or something
            roomnames = new string[]{"Trailers", "Casting Office",
                                     "Train Station", "Jail", "General Store",
                                     "Ranch", "Secret Hideout",
                                     "Main Street", "Saloon", 
                                     "Bank", "Church", "Hotel" };
            roomToIndexDict = new Dictionary<string, int>(roomnames.Length);
            for (int i = 0; i < roomnames.Length; i++)
            {
                roomToIndexDict.Add(roomnames[i], i);
            }

            roomNameToRoomDict = new Dictionary<string, Room>(roomnames.Length);
            roomNameToRoomDict["Trailers"] = Trailers.mInstance;
            roomNameToRoomDict["Casting Office"] = Trailers.mInstance;
            for(int i = 2; i < roomnames.Length; i++)
            {
                // Skips Trailers and Casting Office, make all other Sets
                roomNameToRoomDict[roomnames[i]] = new Set(roomnames[i]);
            }
        }

        private void SetUpAdjMat()
        {
            // TODO: define room adjacency in XML or something
            // TODO: probably move this responsibility to the actual Room class
            roomAdjMat = new bool[roomnames.Length, roomnames.Length];

            int i = roomToIndexDict["Train Station"];
            List<int> list = new List<int>(3);
            list.Add(roomToIndexDict["Jail"]);
            list.Add(roomToIndexDict["General Store"]);
            list.Add(roomToIndexDict["Casting Office"]);
            foreach(int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Jail"];
            list.Clear();
            list.Add(roomToIndexDict["Main Street"]);
            list.Add(roomToIndexDict["General Store"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Main Street"];
            list.Clear();
            list.Add(roomToIndexDict["Saloon"]);
            list.Add(roomToIndexDict["Trailers"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["General Store"];
            list.Clear();
            list.Add(roomToIndexDict["Ranch"]);
            list.Add(roomToIndexDict["Saloon"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Saloon"];
            list.Clear();
            list.Add(roomToIndexDict["Bank"]);
            list.Add(roomToIndexDict["Trailers"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Trailers"];
            list.Clear();
            list.Add(roomToIndexDict["Hotel"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Casting Office"];
            list.Clear();
            list.Add(roomToIndexDict["Ranch"]);
            list.Add(roomToIndexDict["Secret Hideout"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Ranch"];
            list.Clear();
            list.Add(roomToIndexDict["Bank"]);
            list.Add(roomToIndexDict["Secret Hideout"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Bank"];
            list.Clear();
            list.Add(roomToIndexDict["Hotel"]);
            list.Add(roomToIndexDict["Church"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Secret Hideout"];
            list.Clear();
            list.Add(roomToIndexDict["Church"]);
            foreach (int j in list)
            {
                roomAdjMat[i, j] = true;
                roomAdjMat[j, i] = true;
            }

            i = roomToIndexDict["Church"];
            list.Clear();
            list.Add(roomToIndexDict["Hotel"]);
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

            switch (count)
            {
                case 2:
                case 3:
                    Console.WriteLine("Special Rule: Only 3 days instead of 4");
                    // TODO: pop 10 scene cards
                    break;
                case 5:
                    Console.WriteLine("Special Rule: Every player starts with 2 credits..");
                    startingCred = 2;
                    break;
                case 6:
                    Console.WriteLine("Special Rule: Every player starts with 4 credits.");
                    startingCred = 4;
                    break;
                case 7:
                case 8:
                    Console.WriteLine("Special Rule: Every player starts with rank 2.");
                    startingRank = 2;
                    break;
            }

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
            if (roomToIndexDict.ContainsKey(roomname) == false)
            {
                Console.Error.WriteLine("Error: room \"{0}\" does not exist", roomname);
                return null;
            }

            // Create list and add all adjacent rooms
            List <string> list = new List<string>();
            int i = roomToIndexDict[roomname];
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
            if (roomToIndexDict.ContainsKey(dst) == false)
            {
                Console.Error.WriteLine("Error: room \"{0}\" does not exist", dst);
                return;
            }

            // TODO: Actually move player (implemented within player)
            if (roomAdjMat[playerMocLoc, roomToIndexDict[dst]])
            {
                // Destination room is adjacent, move player there
                playerMocLoc = roomToIndexDict[dst];
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
