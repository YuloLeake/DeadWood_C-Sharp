/*
 *  Exception that is thrown when an illegal action is evoked by the user.
 *  e.g. 
 *      Trying to move to non-adjacent room
 *      Trying to act in Trailers or Casting Office
 *
 *  Copyright (c) Yulo Leake 2016
 */

using System;

namespace Deadwood.Model.Exceptions
{
    class IllegalUserActionException: Exception
    {
        public string msg { get; private set; }
        public IllegalUserActionException(string msg)
            : base(msg)
        {
            this.msg = msg;
        }
    }
}
