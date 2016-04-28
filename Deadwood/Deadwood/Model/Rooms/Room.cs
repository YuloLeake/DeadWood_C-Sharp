/*
 *  Main Deadwood driver source code
 *  Copyright (c) Yulo Leake 2016
 *
 *  This is an abstract Class that various Rooms in the game will inherit. 
 */

using System;
using System.Collections.Generic;

namespace Deadwood.Model.Room
{
    abstract class Room
    {
        protected readonly string name;

        public Room(String name)
        {
            this.name = name;
        }

        public abstract void act(Role r);
        public abstract void rehearse(Role r);
        public abstract void upgrade(Player p, int cr, int level);
        public abstract Role takeRole(String roleName);
        public abstract List<Role> getExtraRoles();
        public abstract List<Role> getAllAvailableRoles();
    }
}
