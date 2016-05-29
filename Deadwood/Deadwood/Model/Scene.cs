/*
 *  Class that represents the Scene card of a Set.
 *  Copyright (c) Yulo Leake 2016
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadwood.Model
{
    class Scene
    {
        public readonly string name;
        public readonly string desc;
        public int budget { get; private set; }
        public bool revealed { get; private set; }
        public Dictionary<string, Role> starRoleDict { get; private set; }

        public Scene(string name, string desc, int budget, Dictionary<string, Role> starRoleDict)
        {
            this.name = name;
            this.desc = desc;
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

    }
}
