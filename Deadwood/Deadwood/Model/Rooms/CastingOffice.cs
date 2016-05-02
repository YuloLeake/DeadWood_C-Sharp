/*
 *  Class that represents the Casting Office room on the board.
 *  Since there can be only one Casting Office in the game, it is a Singleton.
 *  It exists only to allow players to upgrade their rank.
 *  Copyright (c) Yulo Leake 2016
 */
using Deadwood.Model.Exceptions;
using System;
using System.Collections.Generic;

namespace Deadwood.Model.Rooms
{
    class CastingOffice : Room
    {
        // Singleton Constructor
        private CastingOffice() : base("Casting Office")
        {
        }

        private static CastingOffice instance;
        public static CastingOffice mInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CastingOffice();
                }
                return instance;
            }
        }

        // Inherited methods
        // Inherited methods
        public override void act(Role r)
        {
            throw new IllegalRoomActionException("\"Shh, please reframe from being dramatic in the Casting Office.\"\n(You cannot act in the Casting Office)");
        }

        public override void rehearse(Role r)
        {
            throw new IllegalRoomActionException("\"Shh, please be quiet in the Casting Office.\"\n(You cannot rehearse in the Casting Office)");
        }

        public override List<Role> getAllAvailableRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Casting Office.");
        }

        public override List<Role> getAllRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Casting Office.");
        }

        public override Role takeRole(string roleName)
        {
            throw new IllegalRoomActionException("\"I am afraid I cannot let you do that\"\n(You cannot take up a role in the Casting Office)");
        }

        public override void upgrade(Player p, int cr, int level)
        {
            // TODO: implement
            Console.WriteLine("<Implement upgrade>");
        }
    }
}
