﻿/*
 *  Exception that is thrown when an illegal action in a room.
 *  e.g. 
 *      Trying to act in Trailers or Casting Office
 *      Trying to move to non-adjacent room
 *  Copyright (c) Yulo Leake 2016
 */

using System;

namespace Deadwood.Model.Exceptions
{

    // TODO: replace these with IllegalUserActionException!
    class IllegalRoomActionException: Exception
    {
        public string msg { get; private set; }
        public IllegalRoomActionException(string msg)
            : base(msg)
        {
            this.msg = msg;
        }
    }
}
