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
        // TODO: make this read from a text file at initialization
        static readonly string[] roomnames = new string[]{"Trailers", "Casting Office",
                                                                 "Train Station", "Jail", "General Store",
                                                                 "Ranch", "Secret Hideout",
                                                                 "Main Street", "Saloon",
                                                                 "Bank", "Church", "Hotel"};

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

        public static string[] GetRoomNames()
        {
            return roomnames;
        }

        // Interface methods
        public Room CreateRoom(string roomname)
        {
            Room room = null;
            Dictionary<string, Role> roles = null;
            IRoleFactory factory = RawRoleFactory.mInstance;
            int shotCount = 0;
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
                    shotCount = 3;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Jail":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Prisoner In Cell");
                    AddRole(factory, roles, "Feller in Irons");
                    shotCount = 1;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "General Store":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Man in Overalls");
                    AddRole(factory, roles, "Mister Keach");
                    shotCount = 2;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Ranch":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Shot in Leg");
                    AddRole(factory, roles, "Saucy Fred");
                    AddRole(factory, roles, "Man Under Horse");
                    shotCount = 2;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Secret Hideout":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Clumsy Pit Fighter");
                    AddRole(factory, roles, "Thug with Knife");
                    AddRole(factory, roles, "Dangerous Tom");
                    AddRole(factory, roles, "Penny, who is lost");
                    shotCount = 3;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Main Street":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Railroad Worker");
                    AddRole(factory, roles, "Falls off Roof");
                    AddRole(factory, roles, "Woman in Black Dress");
                    AddRole(factory, roles, "Mayor McGinty");
                    shotCount = 3;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Saloon":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Reluctant Farmer");
                    AddRole(factory, roles, "Woman in Red Dress");
                    shotCount = 2;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Bank":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Suspicious Gentleman");
                    AddRole(factory, roles, "Flustered Teller");
                    shotCount = 1;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Church":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Dead Man");
                    AddRole(factory, roles, "Crying Woman");
                    shotCount = 2;
                    room = new Set(roomname, roles, shotCount);
                    break;
                case "Hotel":
                    roles = new Dictionary<string, Role>();
                    AddRole(factory, roles, "Sleeping Drunkard");
                    AddRole(factory, roles, "Faro Player");
                    AddRole(factory, roles, "Falls from Balcony");
                    AddRole(factory, roles, "Australian Bartender");
                    shotCount = 3;
                    room = new Set(roomname, roles, shotCount);
                    break;
                default:
                    // TODO: raise exception
                    break;
            }
            return room;
        }

        private void AddRole(IRoleFactory factory, Dictionary<string, Role> dict, string roleName)
        {
            // TODO: set up delegates for extra roles.
            Role role = factory.CreateExtraRole(roleName);
            role.RegisterRewardCallback(OnExtraRoleRewards);
            dict[roleName] = role;
        }

        // If success, player gets 1 money and 1 credit
        // Otherwise, give 1 money
        void OnExtraRoleRewards(bool success, Player p)
        {
            // TODO: Maybe put this into Role Factory or separate class, since it'll be redundent when doing XML
            Console.WriteLine("Extra role reward for {0} and it was {1}", p.name, success);
            if (success)
            {
                p.ChangeMoney(1);
                p.ChangeCredit(1);
            }
            else
            {
                p.ChangeMoney(1);
            }

        }
    }
}
