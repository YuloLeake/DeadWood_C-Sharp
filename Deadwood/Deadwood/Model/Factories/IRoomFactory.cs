/*
 *  Interface for Factories that makes Room.
 *  e.g.
 *      RawRoomFactory: makes room based on raw manual string
 *      XMLRoomFactory: makes room based on XML file
 *  Copyright (c) Yulo Leake 2016
 */

using Deadwood.Model.Rooms;

namespace Deadwood.Model.Factories
{
    interface IRoomFactory
    {
        string[] CreateRoomKeys();          // Returns room names
        Room CreateRoom(string roomname);   // Constuct room based on given name
    }
}
