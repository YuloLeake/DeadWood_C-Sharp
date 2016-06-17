/*
 *  Class that represents the Set rooms on the board.
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Deadwood.Model.Rooms
{
    class Set : Room
    {
        // Fields
        public int remainingShotCount { get; private set; }
        private readonly int shotCounts;
        public Dictionary<string, Role> extraRoleDict { get; private set; }
        public Scene scene { get; private set; } = null;

        private static Board board = Board.mInstance;

        // Constructor
        public Set(string name, Dictionary<string, Role> extraRoleDict, int shotCounts) : base(name)
        {
            this.extraRoleDict = extraRoleDict;
            this.shotCounts = shotCounts;
            this.remainingShotCount = shotCounts;
        }

        // Inherited methods
        public override void Act(Role role)
        {
            int budget = this.scene.budget;
            int bonus  = role.rehearsePoint;
            int roll   = board.rng.Next(1, 7);  // Rolling the die [1,6], maybe change it to a function in Board class

            // TODO: for now, take it out later
            Console.WriteLine("Rolled {0:d} ({1:d} + {2:d}) against {3:d}.", (roll+ bonus), roll, bonus, budget);

            // Evaluate player's roll
            if(roll + bonus >= budget)
            {
                // Success, decrease remaining shot count and give reward to player
                Console.WriteLine("\tSuccess!");
                role.Reward(true);
                remainingShotCount--;
                if(remainingShotCount == 0)
                {
                    // The Scene is wrap, distribute bonuses
                    Console.WriteLine("This is a wrap for \"{0}\"!", this.scene.name);
                    if (this.scene.HasStarringActor())
                    {
                        // There is at least one player that is a star, distribute bonuses
                        DistributeBonuses();
                    }
                    WrapScene();
                }
            }
            else
            {
                // Failure
                Console.WriteLine("\tFailure!");
                role.Reward(false);
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

        public override Role GetRole(string roleName)
        {
            // Check if role exists in star
            if(scene.starRoleDict.ContainsKey(roleName))
            {
                return scene.starRoleDict[roleName];
            }

            // Check if role exists in extra
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
            if(this.scene != null)
            {
                // There is a scene, call move into for that scene
                this.scene.OnMoveInto();
            }
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

        // Return all extra roles, regardless of there availability
        public override List<Role> GetAllExtraRoles()
        {
            if (this.scene == null)
            {
                // Scene is wrap, no list, throw error
                throw new IllegalRoomActionException("Scene has wrapped, come back tomorrow.");
            }
            // Simply convert it to list
            return extraRoleDict.Values.ToList();
        }

        // Return only the availabe extra roles
        public override List<Role> GetAvailableExtraRoles()
        {
            if (this.scene == null)
            {
                // Scene is wrap, no list, throw error
                throw new IllegalRoomActionException("Scene has wrapped, come back tomorrow.");
            }
            // Filter out roles that are taken, then convert it to list
            return extraRoleDict.Values.Where(role => !role.IsTaken()).ToList();
        }

        // Return all starring roles, regardless of there availablility
        public override List<Role> GetAllStarringRoles()
        {
            if(this.scene == null)
            {
                // Scene is wrap, no list, throw error
                throw new IllegalRoomActionException("Scene has wrapped, come back tomorrow.");
            }
            // Simply convert it to list
            return scene.starRoleDict.Values.ToList();
        }

        // Return only the available starring roles
        public override List<Role> GetAvailableStarringRoles()
        {
            if (this.scene == null)
            {
                // Scene is wrap, no list, throw error
                throw new IllegalRoomActionException("Scene has wrapped, come back tomorrow.");
            }
            // Filter out roles that are taken, then convert it to list
            return scene.starRoleDict.Values.Where(role => !role.IsTaken()).ToList();
        }

        // Distributes bonuses to stars
        private void DistributeBonuses()
        {
            Console.WriteLine("Bonuses!");
            // TODO: Actually implement it
        }

        // Release all roles (stars and extra)
        // Tell the board that it has wrapped a scene
        private void WrapScene()
        {
            // TODO: Actually implemnt it

            // Tell the scene to wrap the scene
            this.scene.WrapScene();

            // Free all taken extra roles
            foreach(Role r in extraRoleDict.Values)
            {
                if (r.IsTaken())
                {
                    r.FreeRole();
                }
            }

            // Tell the board that this set has wrapped its scene for a day
            board.WrapScene();
        }

        public void FreeScene()
        {
            this.scene = null;
        }

    }
}
