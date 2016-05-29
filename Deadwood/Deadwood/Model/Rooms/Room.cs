/*
 *  Abstract Class that various Rooms in the game will inherit. 
 *  Copyright (c) Yulo Leake 2016
 */

using System;
using System.Collections.Generic;

namespace Deadwood.Model.Rooms
{
    abstract class Room
    {
        public readonly string name;

        public Room(String name)
        {
            this.name = name;
        }

        public abstract void Act(Role r);
        public abstract void Rehearse(Role r);
        public abstract void Upgrade(Player p, int cr, int level);
        public abstract Role GetRole(String roleName);
        public abstract List<Role> GetAllRoles();
        public abstract List<Role> GetAllAvailableRoles();
        
        // Event triggered when a player moves into a room
        public virtual void MoveInto()
        {
            Console.WriteLine("You've moved into {0}", name);
        }
    }
}
