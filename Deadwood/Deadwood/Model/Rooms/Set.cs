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
        public int remainingShotCount { get; private set; }
        private readonly int shotCounts;
        public Dictionary<string, Role> extraRoleDict { get; private set; }
        public Scene scene { get; private set; } = null;

        private static Board b = Board.mInstance;

        // Constructor
        public Set(string name, Dictionary<string, Role> extraRoleDict, int shotCounts) : base(name)
        {
            this.extraRoleDict = extraRoleDict;
            this.shotCounts = shotCounts;
            this.remainingShotCount = shotCounts;
        }

        // Inherited methods
        public override void Act(Role r)
        {
            int budget = this.scene.budget;
            int bonus  = r.rehearsePoint;
            int roll   = b.rng.Next(1, 7);  // Rolling the die [1,6], maybe change it to a function in Board class

            // TODO: for now, take it out later
            Console.WriteLine("Rolled {0:d} ({1:d} + {2:d}) against {3:d}.", (roll+ bonus), roll, bonus, budget);

            // Evaluate player's roll
            if(roll + bonus >= budget)
            {
                // Success, decrease remaining shot count and give reward to player
                Console.WriteLine("\tSuccess!");
                remainingShotCount--;

                // TODO: Give reward to player

                if(remainingShotCount == 0)
                {
                    // The Scene is wrap, distribute bonuses
                    // TODO: distribute bonuses
                }

            }
            else
            {
                // Failure
                Console.WriteLine("\tFailure!");

                // TODO: Give reward to player
            }
        }

        public override void Rehearse(Role r)
        {
            try
            {
                int budget = this.scene.budget;
                r.Rehearse(budget);
                // TODO: temp
                Console.WriteLine("You have {0:d} rehearse points (max of {1:d} points)", r.rehearsePoint, budget - 1);
            }
            catch
            {
                throw;
            }
        }

        public override List<Role> GetAllAvailableRoles()
        {
            List<Role> list = new List<Role>();
            // TODO: get starring roles from scene

            foreach(Role r in extraRoleDict.Values)
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

            foreach (Role r in extraRoleDict.Values)
            {
                list.Add(r);
            }

            return list;
        }

        public override Role GetRole(string roleName)
        {
            // TODO: Take in account for Starring Roles
            // Check if role exists
            if (extraRoleDict.ContainsKey(roleName) == false)
            {
                // Given role does not exist, throw error
                throw new IllegalUserActionException(string.Format("Given role name \"{0}\" does not exist in {1}", roleName, this.name));
            }
            return extraRoleDict[roleName];
        }

        public override void Upgrade(Player p, int cr, int level)
        {
            throw new IllegalRoomActionException("\"Hey you! Take your fancy spreadsheet to the Casting Office!\"\n(You can only upgrade in the Casting Office, AKA not here.)");
        }

        public override void MoveInto()
        {
            base.MoveInto();
            if(this.scene == null)
            {
                // TODO: use better exception class
                throw new IllegalRoomActionException("Set has no scene to flip");
            }

            this.scene.OnMoveInto();
        }

        // Assign the given scene to this Set and assign this Set to the given scene
        // Then reset the remainingShotCount since this will be called at the start of the day
        public override void AssignScene(Scene scene)
        {
            if(this.scene != null)
            {
                throw new IllegalRoomActionException(string.Format("Error: {0} already has a scene {1}, shouldn't happen", this.name, this.scene.name));
            }

            // Assigning scene to this and this to scene
            this.scene = scene;
            scene.AssignSet(this);

            // Reset remainingShotCount
            this.remainingShotCount = this.shotCounts;
        }
    }
}
