/*
 *  Role class that keeps information about the role.
 *  Copyright (c) Yulo Leake 2016
 */

namespace Deadwood.Model
{
    class Role
    {
        protected Player actor = null;      // actor who has taken the role (Null if nobody)
        protected readonly string name;     // name of the role
        protected readonly string desc;     // description of the role
        protected readonly int rank;        // difficulty of the role
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
            // TODO: implement player assingment logic
        }

        public void FreeRole()
        {
            // TODO: implement logic to free this role
        }
         

    }
}
