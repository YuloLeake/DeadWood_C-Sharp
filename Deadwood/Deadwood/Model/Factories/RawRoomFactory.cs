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

        // Interface methods
        public string[] CreateRoomKeys()
        {
            return roomnames;
        }

        public Room CreateRoom(string roomname)
        {
            // TODO: set up Extra Roles for each Set
            Room room = null;
            List<Role> roles = null;
            IRoleFactory factory = RawRoleFactory.mInstance;
            switch (roomname)
            {
                // Build pre-defined rooms
                case "Trailers":
                    room = Trailers.mInstance;
                    break;
                case "Casting Office":
                    room = CastingOffice.mInstance;
                    break;

                // Build Sets
                case "Train Station":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Crusty Prospector"));
                    roles.Add(factory.CreateExtraRole("Dragged by Train"));
                    roles.Add(factory.CreateExtraRole("Preacher with Bag"));
                    roles.Add(factory.CreateExtraRole("Cyrus the Gunfighter"));
                    room = new Set("Train Station", roles);
                    break;
                case "Jail":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Prisoner In Cell"));
                    roles.Add(factory.CreateExtraRole("Feller in Irons"));
                    room = new Set("Jail", roles);
                    break;
                case "General Store":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Man in Overalls"));
                    roles.Add(factory.CreateExtraRole("Mister Keach"));
                    room = new Set("General Store", roles);
                    break;
                case "Ranch":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Shot in Leg"));
                    roles.Add(factory.CreateExtraRole("Saucy Fred"));
                    roles.Add(factory.CreateExtraRole("Man Under Horse"));
                    room = new Set("Ranch", roles);
                    break;
                case "Secret Hideout":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Clumsy Pit Fighter"));
                    roles.Add(factory.CreateExtraRole("Thug with Knife"));
                    roles.Add(factory.CreateExtraRole("Dangerous Tom"));
                    roles.Add(factory.CreateExtraRole("Penny, who is lost"));
                    room = new Set("Secret Hideout", roles);
                    break;
                case "Main Street":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Railroad Worker"));
                    roles.Add(factory.CreateExtraRole("Falls off Roof"));
                    roles.Add(factory.CreateExtraRole("Woman in Black Dress"));
                    roles.Add(factory.CreateExtraRole("Mayor McGinty"));
                    room = new Set("Main Street", roles);
                    break;
                case "Saloon":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Reluctant Farmer"));
                    roles.Add(factory.CreateExtraRole("Woman in Red Dress"));
                    room = new Set("Saloon", roles);
                    break;
                case "Bank":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Suspicious Gentleman"));
                    roles.Add(factory.CreateExtraRole("Flustered Teller"));
                    room = new Set("Bank", roles);
                    break;
                case "Church":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Dead Man"));
                    roles.Add(factory.CreateExtraRole("Crying Woman"));
                    room = new Set("Church", roles);
                    break;
                case "Hotel":
                    roles = new List<Role>();
                    roles.Add(factory.CreateExtraRole("Sleeping Drunkard"));
                    roles.Add(factory.CreateExtraRole("Faro Player"));
                    roles.Add(factory.CreateExtraRole("Falls from Balcony"));
                    roles.Add(factory.CreateExtraRole("Australian Bartender"));
                    room = new Set("Hotel", roles);
                    break;
                default:
                    // TODO: raise exception
                    break;
            }
            return room;
        }
    }
}
