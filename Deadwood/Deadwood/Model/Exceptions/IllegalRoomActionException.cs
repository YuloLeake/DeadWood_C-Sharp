/*
 *  Exception that is thrown when an illegal action in a room.
 *  e.g. 
 *      Trying to act in Trailers or Casting Office
 *      Trying to move to non-adjacent room
 *  Copyright (c) Yulo Leake 2016
 */

using System;

namespace Deadwood.Model.Exceptions
{
    class IllegalRoomActionException: Exception
    {
        public IllegalRoomActionException(string msg)
            : base(msg)
        {
        }
    }
}
