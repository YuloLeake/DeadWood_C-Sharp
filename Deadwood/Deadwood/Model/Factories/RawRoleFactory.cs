/*
 *  Factory that builds roles based on raw manual string. 
 *  What a horrible way to do this!
 *  Copyright (c) Yulo Leake 2016
 */

using System;

namespace Deadwood.Model.Factories
{
    class RawRoleFactory : IRoleFactory
    {
        public Role CreateExtraRole(string name)
        {
            string desc = null;
            int rank = 0;
            // TODO: give each role a lambda function for successfully acting
            switch (name)
            {
                // Roles at Train Station
                case "Crusty Prospector":
                    desc = "Aww, peaches!";
                    rank = 1;
                    break;
                case "Dragged by Train":
                    desc = "Omgeezers!";
                    rank = 1;
                    break;
                case "Preacher with Bag":
                    desc = "The Lord will provide.";
                    rank = 2;
                    break;
                case "Cyrus the Gunfighter":
                    desc = "Git to fightin' or git away!";
                    rank = 4;
                    break;

                // Roles at Secret Hideout
                case "Clumsy Pit Fighter":
                    desc = "Hit me!";
                    rank = 1;
                    break;
                case "Thug with Knife":
                    desc = "Meet Suzy, my murderin' knife.";
                    rank = 2;
                    break;
                case "Dangerous Tom":
                    desc = "There's two ways we can do this....";
                    rank = 3;
                    break;
                case "Penny, who is lost":
                    desc = "Oh, wow! for I am lost!";
                    rank = 4;
                    break;

                // Roles at Church
                case "Dead Man":
                    desc = "....";
                    rank = 1;
                    break;
                case "Crying Woman":
                    desc = "Oh, the humanity!";
                    rank = 2;
                    break;

                // Roles at Hotel
                case "Sleeping Drunkard":
                    desc = "Zzzzzzz...Whiskey!";
                    rank = 1;
                    break;
                case "Faro Player":
                    desc = "Hit me!";
                    rank = 1;
                    break;
                case "Falls from Balcony":
                    desc = "Arrrgghh!";
                    rank = 2;
                    break;
                case "Australian Bartender":
                    desc = "What'll it be, mate?";
                    rank = 3;
                    break;

                // Roles at Main Street
                case "Railroad Worker":
                    desc = "Hit me!";
                    rank = 1;
                    break;
                case "Falls off Roof":
                    desc = "Aaaaiiiigggghh!";
                    rank = 2;
                    break;
                case "Woman in Black Dress":
                    desc = "Well, I'll be!";
                    rank = 2;
                    break;
                case "Mayor McGinty":
                    desc = "People of Deadwood!";
                    rank = 4;
                    break;

                // Roles at Jail
                case "Prisoner In Cell":
                    desc = "Zzzzzzz...Whiskey!";
                    rank = 2;
                    break;
                case "Feller in Irons":
                    desc = "Ah kilt the wrong man!";
                    rank = 3;
                    break;

                // Roles at General Store
                case "Man in Overalls":
                    desc = "Looks like a storm's comin' in.";
                    rank = 1;
                    break;
                case "Mister Keach":
                    desc = "Howdy, stranger.";
                    rank = 3;
                    break;

                // Roles at Ranch
                case "Shot in Leg":
                    desc = "Ow! Me Leg!";
                    rank = 1;
                    break;
                case "Saucy Fred":
                    desc = "That's what she said.";
                    rank = 2;
                    break;
                case "Man Under Horse":
                    desc = "A little help here!";
                    rank = 3;
                    break;

                // Roles at Bank
                case "Suspicious Gentleman":
                    desc = "Can you be more specific?";
                    rank = 2;
                    break;
                case "Flustered Teller":
                    desc = "Would you like a large bill, sir?";
                    rank = 3;
                    break;

                // Roles at Saloon
                case "Reluctant Farmer":
                    desc = "I ain't so sure about that!";
                    rank = 1;
                    break;
                case "Woman in Red Dress":
                    desc = "Come up and see me!";
                    rank = 2;
                    break;

                default:
                    // TODO: set up exception
                    break;
            }
            return new Role(name, desc, rank);
        }

        public Role CreateStaringRole(string name)
        {
            // Implement this
            Console.WriteLine("<Implementation needed>");
            throw new NotImplementedException();
        }
    }
}
