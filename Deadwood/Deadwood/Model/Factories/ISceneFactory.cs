/*
 *  Interface for Factories that makes Scenes.
 *  e.g.
 *      RawSceneFactory: makes scene based on raw manual string
 *      XMLSceneFactory: makes scene based on XML file
 *  Copyright (c) Yulo Leake 2016
 */
 
namespace Deadwood.Model.Factories
{
    interface ISceneFactory
    {
        Scene MakeScene(string scene);
    }
}
