/*
 *  Class representing the Acting state in player's state machine (Can only act or rehearse the part)
 *  Limits Player's action to Act() and Rehearse()
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;
using Deadwood.Model.Exceptions;

namespace Deadwood.Model.PlayerStates
{
    class ActingState : IPlayerState
    {
        // Legal actions
        
        // Have the player act, move the state to terminal
        public IPlayerState Act(Player p)
        {   
            p.room.Act(p.role);
            return new TerminalState();
        }

        // Have the player rehearse, move the state to terminal
        public IPlayerState Rehearse(Player p)
        {
            p.room.Rehearse(p.role);
            return new TerminalState();
        }

        // Illegal actions, throw an error

        public IPlayerState Move(Player p, string destination)
        {
            throw new IllegalUserActionException("\"Hey, where are you going? The show must go on!\"\n(You cannot move while playing a role)");
        }

        public IPlayerState TakeRole(Player p, string rolename)
        {
            throw new IllegalUserActionException("\"You cannot take the role \'Dr. Evil\'\"\n(You cannot take a new role while playing a role)");
        }

        public IPlayerState Upgrade(Player p, CurrencyType type, int rank)
        {
            throw new IllegalUserActionException("\"Hey! Put away your Sudoku book!\"\n(You cannot upgrade while acting)");
        }
    }
}
