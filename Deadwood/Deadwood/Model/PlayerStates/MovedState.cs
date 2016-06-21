/*
 *  Class representing the Moved state in player's state machine (player has moved, but can upgrade or take role)
 *  Limits Player's action to Upgrade() and TakeRole()
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;
using Deadwood.Model.Exceptions;

namespace Deadwood.Model.PlayerStates
{
    class MovedState : IPlayerState
    {
        // Legal moves

        // Give role to player, move the state to terminal
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

        // Upgrade player, keep the state
        public IPlayerState Upgrade(Player p, CurrencyType type, int rank)
        {
            p.room.Upgrade(p, type, rank);
            return this;
        }

        // Illegal actions, throw an error

        public IPlayerState Act(Player p)
        {
            throw new IllegalUserActionException("\"How can you have any act if you don't have yer role?\"\n(You cannot act without playing a role)");
        }

        public IPlayerState Move(Player p, string destination)
        {
            throw new IllegalUserActionException("\"You seem exhausted, wait a bit, will ya?\"\n(You can only move once in a turn)");
        }

        public IPlayerState Rehearse(Player p)
        {
            throw new IllegalUserActionException("\"If you don't have yer role, you can't have any rehearsing!\"\n(You cannot rehearse without playing a role)");
        }
    }
}
