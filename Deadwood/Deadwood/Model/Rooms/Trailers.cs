/*
 *  Class that represents the Trailers room on the board.
 *  Since there can be only one Trailers in the game, it is a Singleton.
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Exceptions;

using System.Collections.Generic;
using System;

namespace Deadwood.Model.Rooms
{
    class Trailers : Room
    {
        // Singleton Constructor
        private Trailers() : base("Trailers")
        {
        }

        private static Trailers instance;
        public static Trailers mInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Trailers();
                }
                return instance;
            }
        }

        // Inherited methods
        public override void Act(Role r)
        {
            throw new IllegalRoomActionException("\"Hey, are you blind? No acting in the Trailers!\"\n(You cannot act in the Trailers)");
        }

        public override void Rehearse(Role r)
        {
            throw new IllegalRoomActionException("\"Take your Shakespeare out of here!\"\n(You cannot rehearse in the Trailers)");
        }

        public override List<Role> GetAllAvailableRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Trailers.");
        }

        public override List<Role> GetAllRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Trailers.");
        }

        public override Role GetRole(string roleName)
        {
            throw new IllegalRoomActionException("\"Are you looking for somebody?\"\n(You cannot take up a role in the Trailers)");
        }

        public override void Upgrade(Player p, int cr, int level)
        {
            throw new IllegalRoomActionException("\"The Casting Office is on the other side of the map.\"\n(You can only upgrade in the Casting Office, AKA not in the Trailers)");
        }

        public override void AssignScene(Scene scene)
        {
            throw new IllegalRoomActionException("You cannot assign a scene to Trailer");
        }
    }
}
