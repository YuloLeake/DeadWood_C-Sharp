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
        public abstract void Upgrade(Player p, CurrencyType type, int rank);
        public abstract Role GetRole(String roleName);
        public abstract List<Role> GetAllExtraRoles();
        public abstract List<Role> GetAvailableExtraRoles();
        public abstract List<Role> GetAllStarringRoles();
        public abstract List<Role> GetAvailableStarringRoles();
        public abstract void AssignScene(Scene scene);
        
        // Event triggered when a player moves into a room
        public virtual void MoveInto()
        {
            Console.WriteLine("You've moved into {0}", name);
        }
    }
}
