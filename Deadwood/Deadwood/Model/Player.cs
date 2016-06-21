/*
 *  Player class that keeps information about a player.
 *  Copyright (c) Yulo Leake 2016
 */

#define DEBUG

using System;
using System.Collections.Generic;

using Deadwood.Model.Rooms;
using Deadwood.Model.Exceptions;
using Deadwood.Model.PlayerStates;

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
        private IPlayerState state;

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

        // Method called at the start of this player's turn
        public void StartOfTurn()
        {
            // Set up the state 
            if(role == null)
            {
                this.state = new MovingState();
            }
            else
            {
                this.state = new ActingState();
            }
        }

        // Change the money this player has by given value
        // Throw an exception if it goes below 0
        public void ChangeMoney(int dm)
        {
            int temp = money + dm;
            if(temp < 0)
            {   // Make sure player does not go into debt
                throw new IllegalUserActionException("You cannot spend more money than you have.");
            }

            this.money = temp;
#if (DEBUG)
            Console.WriteLine("{0} got ${1:d} and now has ${2:d}", name, dm, money);
#endif
        }

        // Change the credit this player has by given value
        // Throw an exception if it goes below 0
        public void ChangeCredit(int dc)
        {
            int temp = credit + dc;
            if (temp < 0)
            {   // Make sure player does not go into credit debt
                throw new IllegalUserActionException("You cannot spend more credit than you have.");
            }

            this.credit = temp;
#if (DEBUG)
            Console.WriteLine("{0} got {1:d}cr and now has {2:d}cr", name, dc, credit);
#endif
        }

        public void RankUp(int rank)
        {
            if(this.rank >= rank)
            {   // Throw error, since player is trying to rank down
                throw new IllegalUserActionException("You cannot downgrade a player's rank!");
            }
            this.rank = rank;
        }

        public void Act()
        {
            try
            {
                this.state = this.state.Act(this);
            }
            catch (IllegalUserActionException)
            {
                throw;
            }
        }

        public void Rehearse()
        {
            try
            {
                this.state = this.state.Rehearse(this);
            }
            catch (IllegalUserActionException)
            {
                throw;
            }
        }

        public void Move(string dst)
        {
            try
            {
                this.state = this.state.Move(this, dst);
            }
            catch (IllegalUserActionException)
            {
                throw;
            }
        }

        public void TakeRole(string rolename)
        {
            try
            {
                this.state = this.state.TakeRole(this, rolename);
            }
            catch (IllegalUserActionException)
            {
                throw;
            }
        }

        public void Upgrade(CurrencyType type, int rank)
        {
            try
            {
                this.state = this.state.Upgrade(this, type, rank);
            }
            catch (IllegalUserActionException)
            {
                throw;
            }
        }

        public void SetRole(Role role)
        {
            Console.WriteLine("Took the role \"{0}\"", role.name);
            this.role = role;
        }

        public void SetRoom(Room room)
        {
            this.room = room;
        }

        public void FreeRole()
        {
            if(this.role != null)
            {   // temp
                Console.WriteLine("Freeing the role \"{0}\"", role.name);
                this.role = null;
            }
        }
           
        // static methods
        public static void BrandNewDay(List<Player> players)
        {
            foreach(Player p in players)
            {
                p.room = Trailers.mInstance;
                p.FreeRole();
            }
        }
    }
}
