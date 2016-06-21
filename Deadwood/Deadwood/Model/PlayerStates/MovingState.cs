/*
 *  Class representing the Moving state in player's state machine (can move, upgrade, or take role)
 *  Limits Player's action to Move(), Upgrade(), and TakeRole()
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;
using Deadwood.Model.Exceptions;

namespace Deadwood.Model.PlayerStates
{
    class MovingState : IPlayerState
    {
        // Legal Moves

        // Move player to destination, move state to moved
        public IPlayerState Move(Player p, string destination)
        {
            // Check if current room and destination is adjacent
            Board b = Board.mInstance;
            if (b.AreRoomsAdjacent(p.room.name, destination) == false)
            {
                throw new IllegalUserActionException(string.Format("Error: \"{0}\" and \"{1}\" are not adjacent.\nYou cannot move to \"{1}\"",
                                                                    p.room.name, destination));
            }

            // src and dst rooms are adjacent, move player to dst room
            Room dstRoom = b.GetRoom(destination);
            p.SetRoom(dstRoom);
            dstRoom.MoveInto();

            return new MovedState();
        }

        // Give the role to player, move state to terminal
        public IPlayerState TakeRole(Player p, string rolename)
        {
            // Get role from current room
            Role role = null;
            try
            {
                role = p.room.GetRole(rolename);
            }
            catch (IllegalUserActionException)
            {
                throw;
            }
            role.AssignPlayer(p);

            return new TerminalState();
        }

        // Upgrade player's rank, keep the state
        public IPlayerState Upgrade(Player p, CurrencyType type, int rank)
        {
            p.room.Upgrade(p, type, rank);
            return this;
        }

        // Illegal Moves

        public IPlayerState Act(Player p)
        {
            throw new IllegalUserActionException("\"How can you have any act if you don't have yer role?\"\n(You cannot act without playing a role)");
        }

        public IPlayerState Rehearse(Player p)
        {
            throw new IllegalUserActionException("\"If you don't have yer role, you can't have any rehearsing!\"\n(You cannot rehearse without playing a role)");
        }
    }
}
