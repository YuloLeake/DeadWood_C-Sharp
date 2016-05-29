/*
 *  Board class that is in charge of keeping game and player informations.
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Exceptions;
using Deadwood.Model.Factories;
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
        public int playerCount { get; private set; }
        public Player currentPlayer { get; private set; }
        private int currentPlayerIdx;

        private Random rng;

        // Room fields
        private Dictionary<string, int> roomToIndexDict;
        private Dictionary<string, Room> roomNameToRoomDict;
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
            SetUpPlayers(playerCount);

            StartOfDay();
        }

        private void SetUpRooms()
        {
            IRoomFactory factory = RawRoomFactory.mInstance;
            roomnames = factory.CreateRoomKeys();

            roomToIndexDict = new Dictionary<string, int>(roomnames.Length);
            for (int i = 0; i < roomnames.Length; i++)
            {
                roomToIndexDict.Add(roomnames[i], i);
            }

            roomNameToRoomDict = new Dictionary<string, Room>(roomnames.Length);
            roomNameToRoomDict["Trailers"] = factory.CreateRoom("Trailers");
            roomNameToRoomDict["Casting Office"] = factory.CreateRoom("Casting Office");
            for (int i = 2; i < roomnames.Length; i++)
            {
                // Skips Trailers and Casting Office, make all other Sets
                roomNameToRoomDict[roomnames[i]] = factory.CreateRoom(roomnames[i]);
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
            int startingRank = 1;

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
            currentPlayerIdx = 0; ;
            currentPlayer = playerList[currentPlayerIdx];
        }

        private void StartOfDay()
        {

            Player.BrandNewDay(playerList);

        }


        // Return list of roomnames that is adjacent to current player's room
        public List<Room> GetAdjacentRooms()
        {
            string roomname = currentPlayer.room.name;
            return GetAdjacentRooms(roomname);
        }

        // Return list of room that is adjacent to given roomname
        public List<Room> GetAdjacentRooms(string roomname)
        {
            // Check if roomname given is a valid roomname
            if (roomToIndexDict.ContainsKey(roomname) == false)
            {
                Console.Error.WriteLine("Error: room \"{0}\" does not exist", roomname);
                return null;
            }

            // Create list and add all adjacent rooms
            List <Room> list = new List<Room>();
            int i = roomToIndexDict[roomname];
            for(int j = 0; j < roomnames.Length; j++)
            {
                if(roomAdjMat[i, j])
                {
                    list.Add(roomNameToRoomDict[roomnames[j]]);
                }
            }
            return list;
        }

        // Return true if src and dec are adjacent, false otherwise
        public bool areRoomsAdjacent(string src, string des)
        {
            // Handle for non-existing room cases
            if(roomToIndexDict.ContainsKey(src) == false)
            {
                throw new IllegalBoardRequestException("Error: Requested source room \"" + src + "\" does not exist.");
            }
            if(roomToIndexDict.ContainsKey(des) == false)
            {
                throw new IllegalBoardRequestException("Error: Requested destination room \"" + des + "\" does not exist.");
            }

            int srcIdx = roomToIndexDict[src];
            int desIdx = roomToIndexDict[des];
            return roomAdjMat[srcIdx, desIdx];
        }

        // Return a list of all available roles in given room
        public List<Role> GetAvailableRoles(string roomname)
        {
            // Check if roomname given is a valid roomname
            try
            {
                ValidateRoom(roomname);
            }
            catch (KeyNotFoundException e)
            {
                throw;
            }

            List<Role> list = null;
            try
            {
                list = roomNameToRoomDict[roomname].GetAllAvailableRoles();
            }
            catch (IllegalRoomActionException e)
            {
                throw;
            }
            return list;
        }

        // Return a list of all roles in given room, regardless of their availability
        public List<Role> GetAllRoles(string roomname)
        {
            // Check if roomname given is a valid roomname
            try
            {
                ValidateRoom(roomname);
            }
            catch (KeyNotFoundException e)
            {
                throw;
            }

            List<Role> list = null;
            try
            {
                list = roomNameToRoomDict[roomname].GetAllRoles();
            }
            catch (IllegalRoomActionException e)
            {
                Console.WriteLine(e.msg);
                // TODO: handle this better
                list = new List<Role>();
            }
            return list;
        }

        public Room getRoom(string roomname)
        {
            if(roomNameToRoomDict.ContainsKey(roomname) == false)
            {
                throw new IllegalBoardRequestException("Error: Requested room \"" + roomname + "\" does not exist.");
            }
            return roomNameToRoomDict[roomname];
        }

        // Player moves
        public void Move(string dst)
        {
            try
            {
                currentPlayer.Move(dst);
            }
            catch(IllegalBoardRequestException e)
            {
                Console.WriteLine(e.msg);
            }
            catch(IllegalUserActionException e)
            {
                Console.WriteLine(e.msg);
            }
        }

        // Give current player the role
        public void TakeRole(string rolename)
        {
            try
            {
                currentPlayer.TakeRole(rolename);
            }
            catch(IllegalUserActionException e)
            {
                Console.WriteLine(e.msg);
            }
        }

        // Player ends turn, switch to next player
        public void EndTurn()
        {

            currentPlayerIdx++;
            currentPlayerIdx %= playerCount;    // wrap it back
            currentPlayer = playerList[currentPlayerIdx];

        }

        public void Rehearse()
        {
            try
            {
                currentPlayer.Rehearse();
            }
            catch(IllegalUserActionException e)
            {
                Console.WriteLine(e.msg);
            }
        }

        private void ValidateRoom(string roomname)
        {
            if (roomToIndexDict.ContainsKey(roomname) == false)
            {
                throw new KeyNotFoundException(string.Format("Error: room \"{0}\" does not exist", roomname));
            }
        }
    }
}
