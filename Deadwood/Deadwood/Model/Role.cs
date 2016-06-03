/*
 *  Role class that keeps information about the role.
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Exceptions;

namespace Deadwood.Model
{
    class Role
    {
        protected Player actor = null;      // actor who has taken the role (Null if nobody)
        public readonly string name;        // name of the role
        public readonly string desc;        // description of the role
        public readonly int rank;           // difficulty of the role
        protected int rehearsePoint         // rehearsePoint for this role (maybe put it to Player?)
        { get; private set; }        
        
        // Constructors
        public Role(string name, string desc, int rank)
        {
            this.name = name;
            this.desc = desc;
            this.rank = rank;
        }

        // Methods
        public bool IsTaken()
        {
            return actor != null;
        }

        /*  Rehearse
         *  Increases the rehearsePoint by 1
         *  If the player can succeed with next dice role (i.e. rehearsePoint + 1 == budget), throw an exception
         */
        public void Rehearse(int budget)
        {
            // Check if reached limit
            if(this.rehearsePoint + 1 < budget)     // add 1 since the miminum dice roll is 1
            {
                this.rehearsePoint++;
            }
            else
            {
                // Will succeed with next dice roll, so throw an exception
                throw new IllegalUserActionException("You have rehearsed enough. Act!"); 
            }
        }

        public void AssignPlayer(Player actor)
        {
            if(this.actor != null)
            {
                // somebody else is playing, throw exception
                throw new IllegalUserActionException(string.Format("The role {0} is already being played by {1}.",
                                                                    this.name, this.actor.name));
            }

            if(this.rank > actor.rank)
            {
                // actor's rank is insufficient, throw an exception
                throw new IllegalUserActionException(string.Format("\"Hey {0}! You can't handle the \"{1}\"!"+
                                                                   "(Your rank {2} is lower than the role's rank {3})", 
                                                                   actor.name, this.name, actor.rank, this.rank));
            }

            actor.SetRole(this);
            this.actor = actor;
        }

        public void FreeRole()
        {
            // TODO: implement logic to free this role

        }

        public override string ToString()
        {
            return string.Format("Rank: {0} - {1}: {2}", rank, name, desc);
        }

    }
}
