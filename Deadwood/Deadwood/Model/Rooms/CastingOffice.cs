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
    // Types of currency it supports to rank up
    public enum CurrencyType { Money, Credit };

    class CastingOffice : Room
    {
        // Singleton Constructor
        private CastingOffice() : base("Casting Office") {}

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

        // TODO: Maybe read this from XML or something
        public readonly int[] UPGRADE_MONEY  = { 4, 10, 18, 28, 40 };
        public readonly int[] UPGRADE_CREDIT = { 5, 10, 15, 20, 25 };

        // Inherited methods
        public override void Act(Role r)
        {
            throw new IllegalRoomActionException("\"Shh, please reframe from being dramatic in the Casting Office.\"\n(You cannot act in the Casting Office)");
        }

        public override void Rehearse(Role r)
        {
            throw new IllegalRoomActionException("\"Shh, please be quiet in the Casting Office.\"\n(You cannot rehearse in the Casting Office)");
        }

        public override Role GetRole(string roleName)
        {
            throw new IllegalRoomActionException("\"I am afraid I cannot let you do that\"\n(You cannot take up a role in the Casting Office)");
        }

        // Upgrade player's rank to given rank using a valid currency type
        public override void Upgrade(Player p, CurrencyType type, int rank)
        {   // Check if requested rank within bound, throw error if not
            if(rank < 2 || rank > 6)
            {
                throw new IllegalUserActionException(
                    string.Format("\"I'm afraid we cannot let you do that, {0},\nThe rank requested ({1:d}) is out of bound [{2:d}, {3:d}.\"", 
                                  p.name, rank, 2, 6));
            }

            // Check if requested rank is less, if so throw an error
            if(p.rank >= rank)
            {
                throw new IllegalUserActionException("\"There's only one way, and that's up, honey.\"\n(You cannot downgrade your rank)");
            }

            switch (type)
            {
                case CurrencyType.Money:
                    Console.WriteLine("Using money to upgrade");
                    if(p.money >= UPGRADE_MONEY[rank - 2])
                    {   // Player has enough money to upgrade
                        p.ChangeMoney(-UPGRADE_MONEY[rank - 2]);
                        p.RankUp(rank);
                    }
                    else
                    {   // Player doesn't have enough money to upgrade
                        throw new IllegalUserActionException("\"Come back when you have a real job!\n(You do not have enough money to upgrade)");
                    }
                    break;
                case CurrencyType.Credit:
                    Console.WriteLine("Using credit to upgrade");
                    if (p.credit >= UPGRADE_CREDIT[rank - 2])
                    {   // Player has enough money to upgrade
                        p.ChangeCredit(-UPGRADE_CREDIT[rank - 2]);
                        p.RankUp(rank);
                    }
                    else
                    {   // Player doesn't have enough money to upgrade
                        throw new IllegalUserActionException("\"No free lunch!\n(You do not have enough credit to upgrade)");
                    }
                    break;
                default:
                    throw new IllegalUserActionException("\"We don't take that kind of thing here.\"\n(That currency is not supported here)");
            }
        }

        public override void AssignScene(Scene scene)
        {
            throw new IllegalRoomActionException("You cannot assign a scene to Casting Office");
        }

        public override List<Role> GetAllExtraRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Casting Office.");
        }

        public override List<Role> GetAvailableExtraRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Casting Office.");
        }

        public override List<Role> GetAllStarringRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Casting Office.");
        }

        public override List<Role> GetAvailableStarringRoles()
        {
            throw new IllegalRoomActionException("There are no roles in the Casting Office.");
        }
    }
}
