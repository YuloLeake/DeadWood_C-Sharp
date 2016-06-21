/*
 *  Interface for player state machine that dictates what actions player can and cannot take
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;

namespace Deadwood.Model.PlayerStates
{
    interface IPlayerState
    {
        IPlayerState Act(Player p);
        IPlayerState Rehearse(Player p);
        IPlayerState Move(Player p, string destination);
        IPlayerState Upgrade(Player p, CurrencyType type, int rank);
        IPlayerState TakeRole(Player p, string rolename);
    }
}
