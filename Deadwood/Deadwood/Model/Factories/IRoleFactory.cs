/*
 *  Interface for Factories that makes Roles.
 *  e.g.
 *      RawRoleFactory: makes role based on raw manual string
 *      XMLRoleFactory: makes role based on XML file
 *  TODO: Look into http://stackoverflow.com/a/29572255 for possible solution to using different data sources (raw vs xml vs json).
 *      basically, CreateStarringRole(T name) and T -> string | xml | json
 *
 *  Copyright (c) Yulo Leake 2016
 */

namespace Deadwood.Model.Factories
{
    interface IRoleFactory
    {
        Role CreateStarringRole(string name);
        Role CreateExtraRole(string name);
    }
}
