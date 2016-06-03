/*
 *  Factory that builds scene based on raw manual string. 
 *  What a horrible way to do this!
 *
 *  Copyright (c) Yulo Leake 2016
 */

using System.Collections.Generic;

namespace Deadwood.Model.Factories
{
    class RawSceneFactory : ISceneFactory
    {
        // Singleton Constructor
        private static ISceneFactory instance = null;
        public static ISceneFactory mInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RawSceneFactory();
                }
                return instance;
            }
        }

        private RawSceneFactory() { }


        // Interface methods
        public Scene MakeScene(string sceneName)
        {
            string name = "";
            string desc = "";
            int budget  = 0;
            int sceneNum = 0;
            string imgSrc = ""; // Used later to get the image of the scene card
            Dictionary<string, Role> starRoleDict = new Dictionary<string, Role>();
            IRoleFactory factory = RawRoleFactory.mInstance;

            switch (sceneName)
            {
                // TODO: double check names and budget and scene number
                case "Evil Wears a Hat":
                    name = sceneName;
                    desc = "Calhoun is separated from the group during a white-knuckled chase near Desperation Bluff.";
                    budget = 4;
                    imgSrc = "01.png";
                    sceneNum = 7;
                    AddRole(factory, starRoleDict, "Defrocked Priest");
                    AddRole(factory, starRoleDict, "Marshal Canfield");
                    AddRole(factory, starRoleDict, "One-Eyed Man");
                    break;
                case "Law and the Old West":
                    name = sceneName;
                    desc = "Charlie \"Three Guns\" Henderson cooperates with Johnny Law and reluctantly enters the witless protection program.";
                    budget = 3;
                    imgSrc = "02.png";
                    sceneNum = 20;
                    AddRole(factory, starRoleDict, "Rug Merchant");
                    AddRole(factory, starRoleDict, "Banker");
                    AddRole(factory, starRoleDict, "Talking Mule");
                    break;
                case "The Life and Times of John Skywater":
                    name = sceneName;
                    desc = "Disheartened by his lack of business acumen and his poor choice of investment partners, John Skywater sets off into the Cree Nation to convince them to kidnap his wife.";
                    budget = 5;
                    imgSrc = "03.png";
                    sceneNum = 22;
                    AddRole(factory, starRoleDict, "Auctioneer");
                    AddRole(factory, starRoleDict, "General Custer");
                    break;
                case "eMy Yars on the Prairie":
                    name = sceneName;
                    desc = "Virgil and Stacy set out at midnight to track down the stray cows, unaware that they are being pursued by inch - high aliens from outer space.";
                    budget = 5;
                    imgSrc = "04.png";
                    sceneNum = 32;
                    AddRole(factory, starRoleDict, "Drunk");
                    AddRole(factory, starRoleDict, "Librarian");
                    AddRole(factory, starRoleDict, "Man with Hay");
                    break;
                case "Buffalo Bill: The Lost Years":
                    name = sceneName;
                    desc = "Buffalo Bill's companion Marty disappears in a freak electrical storm. Bill enlists the aid of the Sidekick Friends network.";
                    budget = 4;
                    imgSrc = "05.png";
                    sceneNum = 12;
                    AddRole(factory, starRoleDict, "Hollering Boy");
                    AddRole(factory, starRoleDict, "Drink Farmer");
                    AddRole(factory, starRoleDict, "Meek Little Sarah");
                    break;
                case "Square Deal City":
                    name = sceneName;
                    desc = "Douglas and Katherine confront Aunt Martha about her missing pies. Devin sulks quietly in a side room.";
                    budget = 6;
                    imgSrc = "06.png";
                    sceneNum = 14;
                    AddRole(factory, starRoleDict, "Squaking Boy");
                    AddRole(factory, starRoleDict, "Pharaoh Imhotep");
                    AddRole(factory, starRoleDict, "Aunt Martha");
                    break;
                case "Davy Crockett: A Drunkard's Tale":
                    name = sceneName;
                    desc = "Robert enlists the aid of several farm animals in order to ascertain the efficacy of his new hangover remedy.";
                    budget = 4;
                    imgSrc = "07.png";
                    sceneNum = 31;
                    AddRole(factory, starRoleDict, "The Duck");
                    AddRole(factory, starRoleDict, "His Brother");
                    break;
                case "The Way the West Was Run":
                    name = sceneName;
                    desc = "Jose explains patiently, but with thinly veiled contempt, the intricacies of Arizona bureaucracy, as though speaking to a simple and distracted child.";
                    budget = 4;
                    imgSrc = "08.png";
                    sceneNum = 34;
                    AddRole(factory, starRoleDict, "Town Drunk");
                    AddRole(factory, starRoleDict, "Squinting Miner");
                    AddRole(factory, starRoleDict, "Poltergeist");
                    break;
                case "Down in the Valley":
                    name = sceneName;
                    desc = "A tripped waiter is the spark igniting a brawl of cataclysmic proportions.Walter is injured in the neck.";
                    budget = 3;
                    imgSrc = "09.png";
                    sceneNum = 24;
                    AddRole(factory, starRoleDict, "Angry Barber");
                    AddRole(factory, starRoleDict, "Woman with Board");
                    AddRole(factory, starRoleDict, "Man in Fire");
                    break;
                case "Ol' Shooter and Little Doll":
                    name = sceneName;
                    desc = "Shooter discovers that he has been proceeding for days with no trousers. This causes him no small embarrassment as he searches for them with Little Doll.";
                    budget = 5;
                    imgSrc = "10.png";
                    sceneNum = 14;
                    AddRole(factory, starRoleDict, "Sleeping Man");
                    AddRole(factory, starRoleDict, "Man with Pig");
                    AddRole(factory, starRoleDict, "Shooter");
                    break;
                case "The Robbers of Trains":
                    name = sceneName;
                    desc = "Coogan confronts the toughest thug in his gang, Big Jake, in an abbreviated knife fight.Coogan settles the dispute with fearless guil and a kick in the family jewels.";
                    budget = 4;
                    imgSrc = "11.png";
                    sceneNum = 19;
                    AddRole(factory, starRoleDict, "Buster");
                    AddRole(factory, starRoleDict, "Man Reading Paper");
                    AddRole(factory, starRoleDict, "Fat Pete");
                    break;
                case "Beyond the Pail: Life without Lactose":
                    name = sceneName;
                    desc = "Henry discovers for the first time that his ability to digest cream has disappeared along with his hair.Other cowboys attempt to console him.";
                    budget = 2;
                    imgSrc = "12.png";
                    sceneNum = 12;
                    AddRole(factory, starRoleDict, "Martin");
                    break;
                case "A Man Called 'Cow'":
                    name = sceneName;
                    desc = "Nothing will settle the debates among the skeptical locals, short of a demonstration of Hector's special talents.";
                    budget = 3;
                    imgSrc = "13.png";
                    sceneNum = 16;
                    AddRole(factory, starRoleDict, "Preacher");
                    AddRole(factory, starRoleDict, "Amused Witness");
                    break;
                case "Taffy Commercial":
                    name = sceneName;
                    desc = "Jackson encourages the children to eat only taffy, because gum can kill them stone dead.";
                    budget = 2;
                    imgSrc = "14.png";
                    sceneNum = 2;
                    AddRole(factory, starRoleDict, "Curious girl");
                    AddRole(factory, starRoleDict, "Ghost of Plato");
                    break;
                case "Gum Commercial":
                    name = sceneName;
                    desc = "Inspector Pete speaks to a riveted audience about the many hidden dangers of taffy, not the least of which is that taffy can kill you stone dead.";
                    budget = 2;
                    imgSrc = "15.png";
                    sceneNum = 3;
                    AddRole(factory, starRoleDict, "Surprised Bison");
                    AddRole(factory, starRoleDict, "Man with Horn");
                    break;
                case "Jesse James: Man of Action":
                    name = sceneName;
                    desc = "Jesse's brothers Jed and Henry throw him a surprise birthday party. Jesse's nerves get the better of him when the birthday cake explodes.";
                    budget = 5;
                    imgSrc = "16.png";
                    sceneNum = 8;
                    AddRole(factory, starRoleDict, "Shot in Back");
                    AddRole(factory, starRoleDict, "Shot in Leg");
                    AddRole(factory, starRoleDict, "Leaps into Cake");
                    break;
                case "Disaster at Flying J":
                    name = sceneName;
                    desc = "After the mine explosion, the traveling circus takes time out to get drunk and start a fight.";
                    budget = 5;
                    imgSrc = "17.png";
                    sceneNum = 6;
                    AddRole(factory, starRoleDict, "Piano Player");
                    AddRole(factory, starRoleDict, "Man in Turban");
                    AddRole(factory, starRoleDict, "Falls on Hoe");
                    break;
                case "Shakespear in Lubbock":
                    name = sceneName;
                    desc = "William decides that it is time to be movin' on.  Julia convinces him to stick around just long enough to get into big trouble.";
                    budget = 3;
                    imgSrc = "18.png";
                    sceneNum = 23;
                    AddRole(factory, starRoleDict, "Falls from Tree");
                    AddRole(factory, starRoleDict, "Laughing Woman");
                    AddRole(factory, starRoleDict, "Man with Whistle");
                    break;
                case "Go West, You!":
                    name = sceneName;
                    desc = "Susan and Peter encounter some of the perils of the Badlands: rutted mud roads, torrential rain storms, and a bad case of \"grumbly tummy.\"";
                    budget = 3;
                    imgSrc = "19.png";
                    sceneNum = 30;
                    AddRole(factory, starRoleDict, "Ex-Convict");
                    AddRole(factory, starRoleDict, "Man with Onion");
                    break;
                case "The Life and Times of John Skywater (Part 2)":
                    name = sceneName;
                    desc = "John discovers his long-lost sister Marcie, and instructs her in the ways of gunfighting and whiskey distillation.";
                    budget = 5;
                    imgSrc = "20.png";
                    sceneNum = 15;
                    AddRole(factory, starRoleDict, "Staggering Man");
                    AddRole(factory, starRoleDict, "Woman with Beer");
                    AddRole(factory, starRoleDict, "Marcie");
                    break;
                case "Gun!The Musical":
                    name = sceneName;
                    desc = "A song and dance extravaganza, \"Hunka Hunka Burnin' Lead.\"";
                    budget = 6;
                    imgSrc = "21.png";
                    sceneNum = 25;
                    AddRole(factory, starRoleDict, "Looks like Elvis");
                    AddRole(factory, starRoleDict, "Singing Dead Man");
                    AddRole(factory, starRoleDict, "Apothecary");
                    break;
                case "Humor at the Expense of Others":
                    name = sceneName;
                    desc = "Phil and his cohort of unfeeling smart-mouths make fun of Sancho and his great big hat.";
                    budget = 5;
                    imgSrc = "22.png";
                    sceneNum = 16;
                    AddRole(factory, starRoleDict, "Jailer");
                    AddRole(factory, starRoleDict, "Mephistopheles");
                    AddRole(factory, starRoleDict, "Breaks a Window");
                    break;
                case "The Search for Maggie White":
                    name = sceneName;
                    desc = "Alone in the wilderness, Maggie makes the best of her situation. In what seems like no time at all, she constructs a sturdy two-story house from branches and mud.";
                    budget = 6;
                    imgSrc = "23.png";
                    sceneNum = 12;
                    AddRole(factory, starRoleDict, "Film Critic");
                    AddRole(factory, starRoleDict, "Hobo with Bat");
                    break;
                case "Picante Sauce Commercial":
                    name = sceneName;
                    desc = "A dozen grizzled cowboys surround a fire. Suddenly, they exclaim, \"That's not mayonnaise!\"";
                    budget = 2;
                    imgSrc = "24.png";
                    sceneNum = 1;
                    AddRole(factory, starRoleDict, "Bewhisker'd Cowpoke");
                    AddRole(factory, starRoleDict, "Dog");
                    break;
                case "Jesse James: Man of Action (Part 2)":
                    name = sceneName;
                    desc = "A hail of gunfire results when Jesse's friend Barton marries Jesse's childhood sweetheart.";
                    budget = 5;
                    imgSrc = "25.png";
                    sceneNum = 14;
                    AddRole(factory, starRoleDict, "Shot in Head");
                    AddRole(factory, starRoleDict, "Leaps Out of Cake");
                    AddRole(factory, starRoleDict, "Shot Three Times");
                    break;
                case "One False Step for Mankind":
                    name = sceneName;
                    desc = "After a dozen failed attempts, one rocket carries Horatio and his six children to the Moon, where they enjoy a picnic and a spirited game of badminton.";
                    budget = 6;
                    imgSrc = "26.png";
                    sceneNum = 21;
                    AddRole(factory, starRoleDict, "Flustered Man");
                    AddRole(factory, starRoleDict, "Space Monkey");
                    AddRole(factory, starRoleDict, "Cowbot Dan");
                    break;
                case "Thirteen the Hard Way":
                    name = sceneName;
                    desc = "After some delay, the Pony Express arrives. Isaac, Gwen, Francis, Terry, Conrad, Brooke, Jerry, Howard, MacNeill, Jones, Spike, Cornwall and Crawford are all there.";
                    budget = 5;
                    imgSrc = "27.png";
                    sceneNum = 15; // TODO: scene number collision, fix me
                    AddRole(factory, starRoleDict, "Man in Poncho");
                    AddRole(factory, starRoleDict, "Ecstatic Housewife");
                    AddRole(factory, starRoleDict, "Isaac");
                    break;
                case "How They Get Milk":
                    name = sceneName;
                    desc = "Josie asks the Milkman how they get milk. After a thoughtful pause, he begins. \"Not like you'd expect!\"";
                    budget = 4;
                    imgSrc = "28.png";
                    sceneNum = 2;
                    AddRole(factory, starRoleDict, "Cow");
                    AddRole(factory, starRoleDict, "St. Clement of Alexandria");
                    AddRole(factory, starRoleDict, "Josie");
                    break;
                case "My Years on the Prairie":
                    name = sceneName;
                    desc = "Louise takes instruction from Henry, the neighbor boy, in an absurdly suggestive explanation of how to plow a field.";
                    budget = 5;
                    imgSrc = "29.png";
                    sceneNum = 27;
                    AddRole(factory, starRoleDict, "Willard");
                    AddRole(factory, starRoleDict, "Leprechaun");
                    AddRole(factory, starRoleDict, "Startled Ox");
                    break;
                case "Davy Crockett: A Drunkard's Tale (Part 2)":
                    name = sceneName;
                    desc = "In an absurd dream sequence, Crockett recalls an episode of fear and chaos in which his childhood friend Timmy was trapped at the bottom of a well.";
                    budget = 4;
                    imgSrc = "30.png";
                    sceneNum = 12;
                    AddRole(factory, starRoleDict, "Voice of God");
                    AddRole(factory, starRoleDict, "Hands of God");
                    AddRole(factory, starRoleDict, "Jack Kemp");
                    break;
                case "Czechs in the Sonora":
                    name = sceneName;
                    desc = "Bob reverts to his ancestral ways in a short fight over a disembodied hand.";
                    budget = 4;
                    imgSrc = "31.png";
                    sceneNum = 25;
                    AddRole(factory, starRoleDict, "Opice (Monkey)");
                    AddRole(factory, starRoleDict, "Man with Gun");
                    break;
                case "Swing 'em Wide":
                    name = sceneName;
                    desc = "Black Jack invites Dixon and The Captain to a late-night poker game.Little do they know that Gertrude and Isabella await them at the table.";
                    budget = 6;
                    imgSrc = "32.png";
                    sceneNum = 19;
                    AddRole(factory, starRoleDict, "Thrifty Mike");
                    AddRole(factory, starRoleDict, "Sober Physician");
                    AddRole(factory, starRoleDict, "Man on Floor");
                    break;
                case "Swing 'em Wide (Part 2)": // TODO: see if this is actually part 2, since the scenes doesn't seem connected...
                    name = sceneName;
                    desc = "Hector makes a surprising discovery behind the Chinese grocery store.";
                    budget = 6;
                    imgSrc = "33.png";
                    sceneNum = 35;
                    AddRole(factory, starRoleDict, "Liberated Nun");
                    AddRole(factory, starRoleDict, "Witch Doctor");
                    AddRole(factory, starRoleDict, "Voice of Reason");
                    break;
                case "Trials of the First Pioneers":
                    name = sceneName;
                    desc = "A fire breaks out in the town livery. Before long, the surrounding buildings are engulfed in flame.The world falls into chaos.";
                    budget = 4;
                    imgSrc = "34.png";
                    sceneNum = 5;
                    AddRole(factory, starRoleDict, "Burning Man");
                    AddRole(factory, starRoleDict, "Cheese Vendor");
                    AddRole(factory, starRoleDict, "Hit with Table");
                    break;
                case "How the Grinch Stole Texas":
                    name = sceneName;
                    desc = "The doe-eyed citizens of El Paso gather together around a warm fire and pray for the safety of those poor souls in Oklahoma.It almost works.";
                    budget = 5;
                    imgSrc = "35.png";
                    sceneNum = 9;
                    AddRole(factory, starRoleDict, "Detective");
                    AddRole(factory, starRoleDict, "File Clerk");
                    AddRole(factory, starRoleDict, "Cindy Lou");
                    break;
                case "J. Robert Lucky, Man of Substance":
                    name = sceneName;
                    desc = "Horace and Mathilde discover that the mysterious orange powder filling Doctor Lucky's air vents is neither Agent Orange nor weaponized Tang, but a rare form of cheese mold.";
                    budget = 4;
                    imgSrc = "36.png";
                    sceneNum = 13;
                    AddRole(factory, starRoleDict, "Man with Rope");
                    AddRole(factory, starRoleDict, "Svetlana");
                    AddRole(factory, starRoleDict, "Accidental Victim");
                    break;
                case "Thirteen the Hard Way (Part 2)":
                    name = sceneName;
                    desc = "After operating for only six minutes, the Pony Express disbands and gives way to the international Telegraph and Railroad systems. Little boys cry.";
                    budget = 5;
                    imgSrc = "37.png";
                    sceneNum = 17;
                    AddRole(factory, starRoleDict, "Very Wet Man");
                    AddRole(factory, starRoleDict, "Dejected Housewife");
                    AddRole(factory, starRoleDict, "Man with Box");
                    break;
                case "How They Get Milk (Part 2)":
                    name = sceneName;
                    desc = "Josie is thoroughly off milk at this point. The Milkman shows her one more way that she might not have heard of before.";
                    budget = 4;
                    imgSrc = "38.png";
                    sceneNum = 8;
                    AddRole(factory, starRoleDict, "Marksman");
                    AddRole(factory, starRoleDict, "Postal Worker");
                    AddRole(factory, starRoleDict, "A Horse");
                    break;
                case "Breakin' in Trick Ponies":
                    name = sceneName;
                    desc = "Uncle Stewart reveals what to do when all else fails.";
                    budget = 3;
                    imgSrc = "39.png";
                    sceneNum = 19;
                    AddRole(factory, starRoleDict, "Fraternity Pledge");
                    AddRole(factory, starRoleDict, "Man with Sword");
                    break;
                case "Custer's Other Stands":
                    name = sceneName;
                    desc = "General George Armstrong Custer clinches another victory at the battle of Little Sands. His trusty steed Cairo is not so lucky.";
                    budget = 5;
                    imgSrc = "40.png";
                    sceneNum = 40;
                    AddRole(factory, starRoleDict, "Farmer");
                    AddRole(factory, starRoleDict, "Exploding Horse");
                    AddRole(factory, starRoleDict, "Jack");
                    break;
                default:
                    // TODO: throw exception
                    break;
            }

            return new Scene(name, desc, sceneNum, budget, starRoleDict);
        }

        private void AddRole(IRoleFactory factory, Dictionary<string, Role> dict, string roleName)
        {
            // TODO: actually add roles (after implementing CreateStarringRole
            //dict[roleName] = factory.CreateStarringRole(roleName);
        }
    }
}
