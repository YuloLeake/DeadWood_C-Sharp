/*
 *  Player class that keeps information about a player.
 *  Copyright (c) Yulo Leake 2016
 */

using System;
using System.Collections.Generic;

using Deadwood.Model.Rooms;
using Deadwood.Model.Exceptions;

namespace Deadwood.Model
{
    class Player
    {
        public string name { get; private set; }
        public int practicePt { get; private set; }
        public int money { get; private set; }
        public int credit { get; private set; }
        public int rank { get; private set; }
        public Role role { get; private set; }
        public Room room { get; private set; }

        public static Player MakePrototype(int credit, int rank)
        {
            return new Player("PROTO-TYPE", credit, rank);
        }

        // Construction of player done via Prototyping
        private Player(string name, int credit, int rank)
        {
            this.name = name;
            this.money  = 0;
            this.credit = credit;
            this.practicePt = 0;

            this.rank = rank;
            this.role = null;
            this.room = null;
        }

        public Player Clone(string name)
        {
            return new Player(name, this.credit, this.rank);
        }

        // Public methods
        public void Act()
        {

        }

        public void Rehearse()
        {
            // TODO: put this logic in state of the Player
            try
            {
                this.room.Rehearse(this.role);
            }
            catch
            {
                throw;
            }
        }

        public void Move(string dst)
        {
            // TODO: put this in Moving State of the Player
            Board b = Board.mInstance;
            if(b.areRoomsAdjacent(room.name, dst) == false)
            {
                throw new IllegalUserActionException(string.Format("Error: \"{0}\" and \"{1}\" are not adjacent.\nYou cannot move to \"{1}\"", 
                                                                    room.name, dst));
            }
            // src and dst rooms are adjacent, move player to dst room
            Room dstRoom = b.getRoom(dst);
            this.room = dstRoom;
            dstRoom.MoveInto();
        }

        public void TakeRole(string rolename)
        {
            // TODO: put this logic in the state of the Player
            // Check if player is already playing a role
            if(this.role != null)
            {
                // Player is already playing a role, throw exception
                throw new IllegalUserActionException(string.Format("Error: User is already playing the role \"{0}\"", this.role.name));
            }

            // Get role from current room
            Role role = null;
            try
            {
                role = this.room.GetRole(rolename);
            }
            catch(IllegalUserActionException e)
            {
                throw;
            }

            if(role == null)
            {
                //TODO: do something in this case (probably throw an exception)
                return;
            }

            // Assign player to the role
            role.AssignPlayer(this);
        }

        public void SetRole(Role role)
        {
            Console.WriteLine("Took the role \"{0}\"", role.name);
            this.role = role;
        }

        public void Upgrade()
        {

        }
           
        // static methods
        public static void BrandNewDay(List<Player> players)
        {
            foreach(Player p in players)
            {
                p.room = Trailers.mInstance;
                // TODO: free roles
            }
        }
    }
}
