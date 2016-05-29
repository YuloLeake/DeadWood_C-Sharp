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
                if (instance == null)
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
            Dictionary<string, Role> roles = null;
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
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Crusty Prospector");
                    AddRole(factory, roles, "Dragged by Train");
                    AddRole(factory, roles, "Preacher with Bag");
                    AddRole(factory, roles, "Cyrus the Gunfighter");
                    room = new Set("Train Station", roles);
                    break;
                case "Jail":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Prisoner In Cell");
                    AddRole(factory, roles, "Feller in Irons");
                    room = new Set("Jail", roles);
                    break;
                case "General Store":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Man in Overalls");
                    AddRole(factory, roles, "Mister Keach");
                    room = new Set("General Store", roles);
                    break;
                case "Ranch":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Shot in Leg");
                    AddRole(factory, roles, "Saucy Fred");
                    AddRole(factory, roles, "Man Under Horse");
                    room = new Set("Ranch", roles);
                    break;
                case "Secret Hideout":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Clumsy Pit Fighter");
                    AddRole(factory, roles, "Thug with Knife");
                    AddRole(factory, roles, "Dangerous Tom");
                    AddRole(factory, roles, "Penny, who is lost");
                    room = new Set("Secret Hideout", roles);
                    break;
                case "Main Street":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Railroad Worker");
                    AddRole(factory, roles, "Falls off Roof");
                    AddRole(factory, roles, "Woman in Black Dress");
                    AddRole(factory, roles, "Mayor McGinty");
                    room = new Set("Main Street", roles);
                    break;
                case "Saloon":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Reluctant Farmer");
                    AddRole(factory, roles, "Woman in Red Dress");
                    room = new Set("Saloon", roles);
                    break;
                case "Bank":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Suspicious Gentleman");
                    AddRole(factory, roles, "Flustered Teller");
                    room = new Set("Bank", roles);
                    break;
                case "Church":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Dead Man");
                    AddRole(factory, roles, "Crying Woman");
                    room = new Set("Church", roles);
                    break;
                case "Hotel":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Sleeping Drunkard");
                    AddRole(factory, roles, "Faro Player");
                    AddRole(factory, roles, "Falls from Balcony");
                    AddRole(factory, roles, "Australian Bartender");
                    room = new Set("Hotel", roles);
                    break;
                default:
                    // TODO: raise exception
                    break;
            }
            return room;
        }

        private void AddRole(IRoleFactory factory, Dictionary<string, Role> dict, string roleName)
        {
            dict[roleName] = factory.CreateExtraRole(roleName);
        }
    }
}
