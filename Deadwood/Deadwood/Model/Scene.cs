/*
 *  Class that represents the Scene card of a Set.
 *  Copyright (c) Yulo Leake 2016
 */
using System;
using System.Collections.Generic;

using Deadwood.Model.Rooms;

namespace Deadwood.Model
{
    class Scene
    {
        public readonly string name;
        public readonly string desc;
        public readonly int sceneNum;
        public int budget { get; private set; }
        public bool revealed { get; private set; }
        public Dictionary<string, Role> starRoleDict { get; private set; }

        public Set set { get; private set; }

        public Scene(string name, string desc, int sceneNum, int budget, Dictionary<string, Role> starRoleDict)
        {
            this.name = name;
            this.desc = desc;
            this.sceneNum = sceneNum;
            this.budget = budget;
            this.revealed = false;
            this.starRoleDict = starRoleDict;
        }

        public void OnMoveInto()
        {
            if (!revealed)
            {
                // Reveal the Scene
                this.revealed = true;
            }
        }

        public void AssignSet(Set set)
        {
            this.set = set;
        }
    }
}
