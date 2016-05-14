/*
 *  Class that represents the Set rooms on the board.
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Exceptions;

using System;
using System.Collections.Generic;

namespace Deadwood.Model.Rooms
{
    class Set : Room
    {
        // Fields
        public int shotCount { get; private set; }
        public List<Role> extraRoleList { get; private set; }

        // Constructor
        public Set(string name, List<Role> extraRoleList) : base(name)
        {
            this.extraRoleList = extraRoleList;
        }

        // Inherited methods
        public override void Act(Role r)
        {
            // TODO: implement
            Console.WriteLine("<Implementation of acting needed>");
        }

        public override void Rehearse(Role r)
        {
            // TODO: implement
            Console.WriteLine("<Implementation of rehearsing needed>");
        }

        public override List<Role> GetAllAvailableRoles()
        {
            List<Role> list = new List<Role>();
            // TODO: get starring roles from scene

            foreach(Role r in extraRoleList)
            {
                if (r.IsTaken() == false)
                {
                    list.Add(r);
                }
            }
            return list;
        }

        public override List<Role> GetAllRoles()
        {
            List<Role> list = new List<Role>();
            // TODO: get starring roles from scene

            foreach (Role r in extraRoleList)
            {
                list.Add(r);
            }

            return list;
        }

        public override Role TakeRole(string roleName)
        {
            Role role = null;
            // TODO: implement
            Console.WriteLine("<Implementation of taking a role needed>");
            return role;
        }

        public override void Upgrade(Player p, int cr, int level)
        {
            throw new IllegalRoomActionException("\"Hey you! Take your fancy spreadsheet to the Casting Office!\"\n(You can only upgrade in the Casting Office, AKA not here.)");
        }

        public override void MoveInto()
        {
            base.MoveInto();
            Console.WriteLine("You've moved into {0}", name);
            // TODO: flip the scene card if it exists if it hasn't yet
        }
    }
}
