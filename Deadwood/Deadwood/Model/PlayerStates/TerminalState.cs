/*
 *  Class representing the Terminal state in player's state machine (cannot do any more actions)
 *  Player cannot do any action, but to end the turn
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;
using Deadwood.Model.Exceptions;

namespace Deadwood.Model.PlayerStates
{
    class TerminalState : IPlayerState
    {
        // Illegal actions, throw an error

        public IPlayerState Act(Player p)
        {
            throw new IllegalUserActionException("Your turn is done - you cannot act.");
        }

        public IPlayerState Move(Player p, string destination)
        {
            throw new IllegalUserActionException("Your turn is done - you cannot move.");
        }

        public IPlayerState Rehearse(Player p)
        {
            throw new IllegalUserActionException("Your turn is done - you cannot rehearse.");
        }

        public IPlayerState TakeRole(Player p, string rolename)
        {
            throw new IllegalUserActionException("Your turn is done - you cannot take a role.");
        }

        public IPlayerState Upgrade(Player p, CurrencyType type, int rank)
        {
            throw new IllegalUserActionException("Your turn is done - you cannot upgrade.");
        }
    }
}
