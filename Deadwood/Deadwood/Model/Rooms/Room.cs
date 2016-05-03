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

        public abstract void act(Role r);
        public abstract void rehearse(Role r);
        public abstract void upgrade(Player p, int cr, int level);
        public abstract Role takeRole(String roleName);
        public abstract List<Role> getAllRoles();
        public abstract List<Role> getAllAvailableRoles();
        
        // Event triggered when a player moves into a room
        public virtual void MoveInto() { }
    }
}
