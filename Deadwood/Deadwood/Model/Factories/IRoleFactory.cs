/*
 *  Interface for Factories that makes Roles.
 *  e.g.
 *      RawRoleFactory: makes role based on raw manual string
 *      XMLRoleFactory: makes role based on XML file
 *  Copyright (c) Yulo Leake 2016
 */

namespace Deadwood.Model.Factories
{
    interface IRoleFactory
    {
        Role CreateStaringRole(string name);
        Role CreateExtraRole(string name);
    }
}
