/*
 *  Exception that is thrown when an illegal request is made to the Board.
 *  e.g. 
 *      Trying to get information on non-existing room
 *  Maybe merge this with some other Exception in future?
 *  Copyright (c) Yulo Leake 2016
 */
using System;

namespace Deadwood.Model.Exceptions
{
    class IllegalBoardRequestException: Exception
    {
        public string msg { get; private set; }
        public IllegalBoardRequestException(string msg)
            : base(msg)
        {
            this.msg = msg;
        }
    }
}
