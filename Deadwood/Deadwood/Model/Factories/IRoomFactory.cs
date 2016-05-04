/*
 *  Interface for Factories that makes Room.
 *  e.g.
 *      RawRoomFactory: makes room based on raw manual string
 *      XMLRoomFactory: makes room based on XML file
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;

using System.Collections.Generic;

namespace Deadwood.Model.Factories
{
    interface IRoomFactory
    {
        string[] CreateRoomKeys();  // Returns roomnames (key to the dict)
        Room CreateRoom(string roomname);
    }
}
