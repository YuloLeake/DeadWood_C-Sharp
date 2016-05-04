/*
 *  Factory that builds rooms based on raw manual string. 
 *  Brrr!
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;

using System;
using System.Collections.Generic;

namespace Deadwood.Model.Factories
{
    class RawRoomFactory : IRoomFactory
    {
        // Fields
        readonly string[] roomnames = new string[]{"Trailers", "Casting Office",
                                                   "Train Station", "Jail", "General Store",
                                                   "Ranch", "Secret Hideout",
                                                   "Main Street", "Saloon", 
                                                   "Bank", "Church", "Hotel" };

        // Singleton Constructor
        private static IRoomFactory instance = null;
        public static IRoomFactory mInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RawRoomFactory();
                }
                return instance;
            }
        }

        private RawRoomFactory() { }

        public string[] CreateRoomKeys()
        {
            return roomnames;
        }

        public Room CreateRoom(string roomname)
        {
            Room room = null;
            switch (roomname)
            {
                case "Trailers":
                    room = Trailers.mInstance;
                    break;
                case "Casting Office":
                    room = CastingOffice.mInstance;
                    break;
                case "Train Station":
                    room = new Set("Train Station");
                    break;
                case "Jail":
                    room = new Set("Jail");
                    break;
                case "General Store":
                    room = new Set("General Store");
                    break;
                case "Ranch":
                    room = new Set("Ranch");
                    break;
                case "Secret Hideout":
                    room = new Set("Secret Hideout");
                    break;
                case "Main Street":
                    room = new Set("Main Street");
                    break;
                case "Saloon":
                    room = new Set("Saloon");
                    break;
                case "Bank":
                    room = new Set("Bank");
                    break;
                case "Church":
                    room = new Set("Church");
                    break;
                case "Hotel":
                    room = new Set("Hotel");
                    break;
                default:
                    // TODO: raise exception
                    break;
            }
            return room;
        }
    }
}
