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

        public void Rehearse(int budget)
        {
            // TODO: implement rehearse logic
        }

        public void AssignPlayer(Player actor)
        {
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
