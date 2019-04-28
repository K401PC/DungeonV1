using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungonLibrary;
using MonsterLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            short killCount = 0;
            //Console.Title = "DUNGEON OF DOOM!"; instructor
            //Console.Title = "_|_| WELCOME TO >>> YOUR EPIC DEATH|_|_";
            //Console.Write("Welcome, hero! Enter your name: ");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Race playerRace = Race.Human;
            Console.WriteLine("Choose your race: \nH)Human\nE)Elf\nD)Dwarf\n");
            ConsoleKey raceChoice = Console.ReadKey(true).Key;
            switch (raceChoice)
            {
                case ConsoleKey.H:
                    playerRace = Race.Human;
                    break;

                case ConsoleKey.E:
                    playerRace = Race.Elf;
                    break;

                case ConsoleKey.D:
                    playerRace = Race.Dwarf;
                    break;               

                default:
                    Console.WriteLine("That was not a valid choice. You will be a human.");
                    playerRace = Race.Human;
                    break;
            }
            Console.Clear();
            Weapon battleAxe = new Weapon("Rusty Battle Axe", 6, 1, 5, true);
            Weapon bastardSword = new Weapon("Shiny blade", 6, 2, 10, false);
            Weapon stick = new Weapon("A peice of wood", 5, 1, 20, false);
            Weapon bow = new Weapon("I forgot my harp", 7, 1, 15, true);
            Weapon spear = new Weapon("Pointy stick", 6, 1, 10, true);
            List<Weapon> weapons = new List<Weapon>() { battleAxe, bastardSword, stick, bow, spear };
            Weapon playerWeapon = stick;
            Console.Write("Select Your Weapon:\n1) Battle Axe\n2) Bastard Sword\n3) Bow\n" +
                "4) Spear");
            ConsoleKey weaponChoice = Console.ReadKey(true).Key;
            switch (weaponChoice)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    playerWeapon = battleAxe;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    playerWeapon = bastardSword;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    playerWeapon = bow;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    playerWeapon = spear;
                    break;
                default:
                    playerWeapon = stick;
                    Console.WriteLine("Since you can't choose. Use a stick.");
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Welcome, {name}! Your juorney begins...");
            //Console.WriteLine("Your journey begins...\n"); instructor
            //Console.WriteLine("You rub your eyes only to find...");
            //Create a Player

            //Player player = new Player(name, 70, 15, 50, 50, Race.DescendantOfHigherPlain, battleAxe);
            Player player = new Player(name, 70, 15, 50, 50, playerRace, playerWeapon);
            //Player player = new Player("Leeeeeeeeeroy Jenkins!",70,15,50,50,Race.DescendantOfHigherPlain,battleAxe);
            // Player player = new Player("Leeeeeeeeeroy Jenkins!",60,15,40,40,Race.DescendantOfHigherPlain,battleAxe);
            //twiked stats after creating dragon
            //Character c1 = new Character();
            List<Circle> circles = new List<Circle>();
            circles.Add(Circle.Envy);
            circles.Add(Circle.Gluttnoy);
            circles.Add(Circle.Greed);
            circles.Add(Circle.Lust);
            circles.Add(Circle.Pride);
            circles.Add(Circle.Sloth);
            circles.Add(Circle.Wrath);
            Circle circle = circles[new Random().Next(circles.Count)];
            bool exit = false;

            do
            {

                //Get a room descrition
                Console.WriteLine(GetRoom());
                //Create a monster
                Succubus s1 = new Succubus("Lily", 20, 20, 3, 9, 10, 50, circle, ($"Well, hello the pesky {raceChoice}"));
                Lawyer law1 = new Lawyer("Phoenix Wright", 10,10,80,10,1,1,"OBJECTION!!!!",true);
                Lawyer law2 = new Lawyer("Drunken Highlander",30,30,50,10,5,5,"Where's the beer and pretzels at? HIc.",false);
                Dragon d1 = new Dragon("Young Dragon", 20, 20, 50, 10, 1, 8, "An angry red dragon", false);
                Dragon d2 = new Dragon("Huge Red Dragon",40,40,60,10,2,10,"A terrible, evil wrym",true);
                //Beacause all of our creatures will be of type monster. they can be put into a collection of Monsters:
                List<Monster> monsters = new List<Monster>(){ d1, d1, d1, d1, d2, law2, law2, law1, s1, s1, s1};
                Monster monster = monsters[new Random().Next(monsters.Count)];

                Console.WriteLine("In this room: " + monster.Name);
                bool reload = false;
                do
                {
                    Console.Title = string.Format($"Kills: {killCount}      Life: {player.Life}");
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) RUN AWAY!\n" +
                        "P) Player Stats\n" +
                        "M) Monster Stats\n" +
                        "X) Exit");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //Console.WriteLine("Attack fuctionality goes here");
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                killCount++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You killed {monster.Name}!");
                                Console.ResetColor();
                                reload = true;
                            }//end if// loot, exp stuff goes here

                            //ToDO Handle if Player kills Monster
                            //TODO Handle if Monste kill Player
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("Run Away");
                            //TODO Monster get a free attack
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            //Console.WriteLine($"Monsters killed: {killCount}");
                            // Display Player Info
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            // Display Monster Stats
                            break;

                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Thou has chosen an improper option" +
                                "\nTries thou again");
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Thou Hast been slain.");
                        exit = true;
                    }//end if

                } while (!exit && !reload);


            } while (!exit);

            Console.WriteLine($"GAME OVER\nYou killed {killCount} monsters.");
        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
                {
                    "A cluster of low crates surrounds a barrel in the center of this chamber. Atop the barrel lies a \n" +
                    "stack of copper coins and two stacks of cards, one face up. Meanwhile, atop each crate rests a fan \n" +
                    "of five face-down playing cards. A thin layer of dust covers everything. Clearly someone meant to \n" +
                    "return to their game of cards.",
                    "A pit yawns open before you just on the other side of the door's threshold. The entire floor of the \n" +
                    "room has fallen into a second room beneath it. Across the way you can spy a door in the wall now 15 \n" +
                    "feet off the rubble-strewn floor, and near the center of the room stands a thick column of mortared \n" +
                    "stone that appears to hold the spiral staircase that leads down to what was the lower level.",
                    "This chamber of well-laid stones holds a wide bas-relief of a pastoral scene. In it you see a mountain \n" +
                    "like Mount Waterdeep, except that Castle Waterdeep and the city are missing. Instead, a small fishing \n" +
                    "village is a short way from a walled complex with several tall towers.",
                    "A large forge squats against the far wall of this room, and coals glow dimly inside. Before the forge \n" +
                    "stands a wide block of iron with a heavy-looking hammer lying atop it, no doubt for use in pounding out \n" +
                    "shapes in hot metal. Other forge tools hang in racks nearby, and a barrel of water and bellows rest on \n" +
                    "the floor nearby.",
                    "You open the door to a scene of carnage. Two male humans, a male elf, and a female dwarf lie in drying \n" +
                    "pools of their blood. It seems that they might once have been wearing armor, except for the elf, who \n" +
                    "remains dressed in a blue robe. Clearly they lost some battle and victors stripped them of their valuables.",
                    "A glow escapes this room through its open doorways. The masonry between every stone emanates an \n" +
                    "unnatural orange radiance. Glancing quickly about the room, you note that each stone bears the \n" +
                    "carving of someone's name.",
                    "A stone throne stands on a foot-high circular dais in the center of this cold chamber. The throne and \n" +
                    "dais bear the simple adornments of patterns of crossed lines -- a pattern also employed around each \n" +
                    "door to the room.",
                    "This room is hung with hundreds of dusty tapestries. All show signs of wear: moth holes, scorch marks, \n" +
                    "dark stains, and the damage of years of neglect. They hang on all the walls and hang from the ceiling \n" +
                    "to brush against the floor, blocking your view of the rest of the room.",
                    "A dim bluish light suffuses this chamber, its source obvious at a glance. Blue-glowing lichen and \n" +
                    "violet-glowing moss cling to the ceiling and spread across the floor. It even creeps down and up each \n" +
                    "wall, as if the colonies on the floor and ceiling are growing to meet each other. Their source seems \n" +
                    "to be a glowing, narrow crack in the ceiling, the extent of which you cannot gauge from your position. \n" +
                    "The air in the room smells fresh and damp.",
                    "You open the door and a gout of flame rushes at your face. A wave of heat strikes you at the same time \n" +
                    "and light fills the hall. The room beyond the door is ablaze! An inferno engulfs the place, clinging \n" +
                    "to bare rock and burning without fuel.",
                    "The manacles set into the walls of this room give you the distinct impression that it was used as a \n" +
                    "prison and torture chamber, although you can see no evidence of torture devices. One particularly large \n" +
                    "set of manacles -- big enough for an ogre -- have been broken open.",
                    "You open the door to confront a room of odd pillars. Water rushes down from several holes in the \n" +
                    "ceiling, and each hole is roughly a foot wide. The water pours in columns that fall through similar \n" +
                    "holes in the floor, flowing down to some unknown depth. Each of the eight pillars of water drops as \n" +
                    "much liquid as a stream in winter thaw. The floor is damp and looks slippery.",
                    "This small chamber seems divided into three parts. The first has several hooks on the walls from which \n" +
                    "hang dusty robes. An open curtain separates that space from the next, which has a dry basin set in the \n" +
                    "floor. Beyond that lies another parted curtain behind which you can see several straw mats in a semicircle \n" +
                    "pointing toward a statue of a dog-headed man.",
                    " Unlike the flagstone common throughout the dungeon, this room is walled and floored with black marble \n" +
                    "veined with white. The ceiling is similarly marbled, but the thick pillars that hold it up are white. " +
                    "A brown stain drips down one side of a nearby pillar."
                };
            //Random rand = new Random();
            //int indexNbr = rand.Next(rooms.Length);
            //string roomDescription = rooms[indexNbr];
            //return roomDescription;
            return rooms[new Random().Next(rooms.Length)]; //same as four line above
        }//end GetRooms()
    }//end Class    
}//end namespace
