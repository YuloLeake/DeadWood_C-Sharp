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
        // Singleton Constructor
        private static IRoleFactory instance = null;
        public static IRoleFactory mInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RawRoleFactory();
                }
                return instance;
            }
        }

        private RawRoleFactory() { }

        // Interface Methods
        public Role CreateExtraRole(string name)
        {
            string desc = null;
            int rank = 0;
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
                    // TODO: throw exception
                    break;
            }
            return new Role(name, desc, rank);
        }

        public Role CreateStarringRole(string name)
        {
            string desc = null;
            int rank = 0;

            switch (name)
            {
                // Scene "Evil Wears a Hat"
                case "Defrocked Priest":
                    desc = "Look out below!";
                    rank = 2;
                    break;
                case "Marshal Canfield":
                    desc = "Hold fast!";
                    rank = 3;
                    break;
                case "One-Eyed Man":
                    desc = "Balderdash";
                    rank = 4;
                    break;

                // Scene "Law and the Old West"
                case "Rug Merchant":
                    desc = "Don't leave my store!";
                    rank = 1;
                    break;
                case "Banker":
                    desc = "Trust me.";
                    rank = 2;
                    break;
                case "Talking Mule":
                    desc = "Nice work, Johnny!";
                    rank = 4;
                    break;

                // Scene "The Life and Times of John Skywater"
                case "Auctioneer":
                    desc = "Going once!";
                    rank = 5;
                    break;
                case "General Custer":
                    desc = "Go West!";
                    rank = 6;
                    break;

                // Scene "My Years on the Prairie"
                case "Drunk":
                    desc = "Where's Willard?";
                    rank = 3;
                    break;
                case "Librarian":
                    desc = "Shhhhh!";
                    rank = 4;
                    break;
                case "Man with Hay":
                    desc = "Hey!";
                    rank = 6;
                    break;

                // Scene "Buffalo Bill: The Lost Years"
                case "Hollering Boy":
                    desc = "Over here, mister!";
                    rank = 2;
                    break;
                case "Drink Farmer":
                    desc = "Git outta me barn!";
                    rank = 3;
                    break;
                case "Meek Little Sarah":
                    desc = "He's so cute!";
                    rank = 5;
                    break;

                // Scene "Square Deal City"
                case "Squaking Boy":
                    desc = "I'll say!";
                    rank = 2;
                    break;
                case "Pharaoh Imhotep":
                    desc = "Attack, soldiers!";
                    rank = 4;
                    break;
                case "Aunt Martha":
                    desc = "You got nothin'!";
                    rank = 6;
                    break;

                // Scene "Davy Crockett: A Drunkard's Tale"
                case "The Duck":
                    desc = "Waaaak!";
                    rank = 4;
                    break;
                case "His Brother":
                    desc = "Waaaaaaaak!";
                    rank = 6;
                    break;

                // Scene "The Way the West Was Run"
                case "Town Drunk":
                    desc = "Even me!";
                    rank = 2;
                    break;
                case "Squinting Miner":
                    desc = "Sure we can!";
                    rank = 4;
                    break;
                case "Poltergeist":
                    desc = "Wooooo!";
                    rank = 5;
                    break;

                // Scene "Down in the Valley"
                case "Angry Barber":
                    desc = "Hold him still!";
                    rank = 1;
                    break;
                case "Woman with Board":
                    desc = "Nonsense, Frank!";
                    rank = 3;
                    break;
                case "Man in Fire":
                    desc = "It burns!";
                    rank = 5;
                    break;

                // Scene "Ol' Shooter and Little Doll"
                case "Sleeping Man":
                    desc = "Snnkkk snnkk snnkk.";
                    rank = 1;
                    break;
                case "Man with Pig":
                    desc = "Tally-Hooo!";
                    rank = 2;
                    break;
                case "Shooter":
                    desc = "Where's my britches?";
                    rank = 4;
                    break;

                // Scene "The Robbers of Trains"
                case "Buster":
                    desc = "One two three go!";
                    rank = 1;
                    break;
                case "Man Reading Paper":
                    desc = "Ouchie!";
                    rank = 4;
                    break;
                case "Fat Pete":
                    desc = "Nick kick, boss!";
                    rank = 5;
                    break;

                // Scene "Beyond the Pail: Life without Lactose"
                case "Martin":
                    desc = "Have you tried soy cheese?";
                    rank = 6;
                    break;

                // Scene "A Man Called 'Cow'"
                case "Preacher":
                    desc = "My word!";
                    rank = 3;
                    break;
                case "Amused Witness":
                    desc = "Tee hee hee!";
                    rank = 6;
                    break;

                // Scene "Taffy Commercial"
                case "Curious girl":
                    desc = "Are you sure?";
                    rank = 3;
                    break;
                case "Ghost of Plato":
                    desc = "It happened to me!";
                    rank = 4;
                    break;

                // Scene "Gum Commercial"
                case "Surprised Bison":
                    desc = "Mmrrrrrph!";
                    rank = 2;
                    break;
                case "Man with Horn":
                    desc = "Ta daaaa!";
                    rank = 4;
                    break;

                // Scene "Jesse James: Man of Action"
                case "Shot in Back":
                    desc = "Arrrggh!";
                    rank = 2;
                    break;
                case "Shot in Leg":
                    desc = "Ooh, lordy!";
                    rank = 4;
                    break;
                case "Leaps into Cake":
                    desc = "Dangit, Jesse!";
                    rank = 5;
                    break;

                // Scene "Disaster at Flying J"
                case "Piano Player":
                    desc = "It's a nocturne!";
                    rank = 2;
                    break;
                case "Man in Turban":
                    desc = "My stars!";
                    rank = 3;
                    break;
                case "Falls on Hoe":
                    desc = "Ow!";
                    rank = 4;
                    break;

                // Scene "Shakespear in Lubbock"
                case "Falls from Tree":
                    desc = "What ho!";
                    rank = 1;
                    break;
                case "Laughing Woman":
                    desc = "Tis to laugh!";
                    rank = 3;
                    break;
                case "Man with Whistle":
                    desc = "Tweeeeet!";
                    rank = 4;
                    break;

                // Scene "Go West, You!"
                case "Ex-Convict":
                    desc = "Never again!";
                    rank = 4;
                    break;
                case "Man with Onion":
                    desc = "Fresh Onions!";
                    rank = 6;
                    break;

                // Scene "The Life and Times of John Skywater"
                case "Staggering Man":
                    desc = "You never know!";
                    rank = 3;
                    break;
                case "Woman with Beer":
                    desc = "Howdy, stranger!";
                    rank = 5;
                    break;
                case "Marcie":
                    desc = "Welcome home!";
                    rank = 6;
                    break;

                // Scene "Gun! The Musical"
                case "Looks like Elvis":
                    desc = "Thankyouverymuch.";
                    rank = 4;
                    break;
                case "Singing Dead Man":
                    desc = "Yeah!";
                    rank = 5;
                    break;
                case "Apothecary":
                    desc = "Such drugs I have.";
                    rank = 6;
                    break;

                // Scene "Humor at the Expense of Others"
                case "Jailer":
                    desc = "You there!";
                    rank = 2;
                    break;
                case "Mephistopheles":
                    desc = "Be not afraid!";
                    rank = 4;
                    break;
                case "Breaks a Window":
                    desc = "Oops!";
                    rank = 5;
                    break;

                // Scene "The Search for Maggie White"
                case "Film Critic":
                    desc = "Implausible!";
                    rank = 5;
                    break;
                case "Hobo with Bat":
                    desc = "Nice house!";
                    rank = 6;
                    break;

                // Scene "Picante Sauce Commercial"
                case "Bewhisker'd Cowpoke":
                    desc = "Oh, sweet Lord!";
                    rank = 3;
                    break;
                case "Dog":
                    desc = "Wurf!";
                    rank = 6;
                    break;

                // Scene "Jesse James: Man of Action"
                case "Shot in Head":
                    desc = "Arrrgh!";
                    rank = 1;
                    break;
                case "Leaps Out of Cake":
                    desc = "Oh, for Pete's sake!";
                    rank = 4;
                    break;
                case "Shot Three Times":
                    desc = "Ow! Ow! Ow!";
                    rank = 6;
                    break;

                // Scene "One False Step for Mankind"
                case "Flustered Man":
                    desc = "Well, I never!";
                    rank = 1;
                    break;
                case "Space Monkey":
                    desc = "Ook!";
                    rank = 2;
                    break;
                case "Cowbot Dan":
                    desc = "Bzzzzzt!";
                    rank = 5;
                    break;

                // Scene "Thirteen the Hard Way"
                case "Man in Poncho":
                    desc = "Howdy, Jones!";
                    rank = 1;
                    break;
                case "Ecstatic Housewife":
                    desc = "This is fine!";
                    rank = 3;
                    break;
                case "Isaac":
                    desc = "The mail!";
                    rank = 5;
                    break;

                // Scene "How They Get Milk"
                case "Cow":
                    desc = "Moo.";
                    rank = 2;
                    break;
                case "St. Clement of Alexandria":
                    desc = "Peace be with you, child!";
                    rank = 3;
                    break;
                case "Josie":
                    desc = "Yikes!";
                    rank = 4;
                    break;

                // Scene "My Years on the Prairie"
                case "Willard":
                    desc = "Ain't that a sight?";
                    rank = 2;
                    break;
                case "Leprechaun":
                    desc = "Begorrah!";
                    rank = 3;
                    break;
                case "Startled Ox":
                    desc = "Mrr?";
                    rank = 5;
                    break;

                // Scene "Davy Crockett: A Drunkard's Tale"
                case "Voice of God":
                    desc = "Grab hold, son!";
                    rank = 2;
                    break;
                case "Hands of God":
                    desc = "!";
                    rank = 3;
                    break;
                case "Jack Kemp":
                    desc = "America!";
                    rank = 4;
                    break;

                // Scene "Czechs in the Sonora"
                case "Opice (Monkey)":
                    desc = "Ukk! (Ook)!";
                    rank = 5;
                    break;
                case "Man with Gu":
                    desc = "Hold it right there!";
                    rank = 6;
                    break;

                // Scene "Swing 'em Wide"
                case "Thrifty Mike":
                    desc = "Call!";
                    rank = 1;
                    break;
                case "Sober Physician":
                    desc = "Raise!";
                    rank = 3;
                    break;
                case "Man on Floor":
                    desc = "Fold!";
                    rank = 5;
                    break;

                // Scene "Swing 'em Wide" ??
                case "Liberated Nun":
                    desc = "Let me have it!";
                    rank = 3;
                    break;
                case "Witch Doctor":
                    desc = "Oogie Boogie!";
                    rank = 5;
                    break;
                case "Voice of Reason":
                    desc = "Come on, now!";
                    rank = 6;
                    break;

                // Scene "Trials of the First Pioneers"
                case "Burning Man":
                    desc = "Make it stop!";
                    rank = 2;
                    break;
                case "Cheese Vendor":
                    desc = "Opa!";
                    rank = 4;
                    break;
                case "Hit with Table":
                    desc = "Ow! A table?";
                    rank = 5;
                    break;

                // Scene "How the Grinch Stole Texas"
                case "Detective":
                    desc = "I have a hunch.";
                    rank = 3;
                    break;
                case "File Clerk":
                    desc = "My stapler!";
                    rank = 4;
                    break;
                case "Cindy Lou":
                    desc = "Dear Lord!";
                    rank = 5;
                    break;

                // Scene "J. Robert Lucky, Man of Substance"
                case "Man with Rope":
                    desc = "Look out below!";
                    rank = 1;
                    break;
                case "Svetlana":
                    desc = "Says who?";
                    rank = 2;
                    break;
                case "Accidental Victim":
                    desc = "Ow! My spine!";
                    rank = 5;
                    break;

                // Scene "Thirteen the Hard Way"
                case "Very Wet Man":
                    desc = "Sheesh!";
                    rank = 2;
                    break;
                case "Dejected Housewife":
                    desc = "Its time had come.";
                    rank = 4;
                    break;
                case "Man with Box":
                    desc = "Progress!";
                    rank = 5;
                    break;

                // Scene "How They Get Milk"
                case "Marksman":
                    desc = "Pull!";
                    rank = 4;
                    break;
                case "Postal Worker":
                    desc = "It's about time!";
                    rank = 5;
                    break;
                case "A Horse":
                    desc = "Yes Sir!";
                    rank = 6;
                    break;

                // Scene "Breakin' in Trick Ponies"
                case "Fraternity Pledge":
                    desc = "Beer me!";
                    rank = 2;
                    break;
                case "Man with Sword":
                    desc = "None shall pass!";
                    rank = 6;
                    break;

                // Scene "Custer's Other Stands"
                case "Farmer":
                    desc = "Git off a that!";
                    rank = 2;
                    break;
                case "Exploding Horse":
                    desc = "Boom!";
                    rank = 4;
                    break;
                case "Jack":
                    desc = "Here we go again!";
                    rank = 6;
                    break;

                default:
                    // TODO: throw exception
                    break;
            }
            return new Role(name, desc, rank);
        }
    }
}
