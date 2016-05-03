/*
 *  Player class that keeps information about a player.
 *  Copyright (c) Yulo Leake 2016
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Deadwood.Model.Rooms;

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

        }

        public void Move(string dst)
        {
            // TODO: put this in Moving State of the Player
            Board b = Board.mInstance;
            if(b.areRoomsAdjacent(room.name, dst) == false)
            {
                // TODO: raise exception
                return;
            }
            // src and dst rooms are adjacent, move player to dst room
            Room dstRoom = b.getRoom(dst);
            this.room = dstRoom;
            dstRoom.MoveInto();
        }

        public void TakeRole(string role)
        {

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
