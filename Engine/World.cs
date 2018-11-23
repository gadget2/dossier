using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ID_WEAPON_SHORTSWORD = 1;
        public const int ID_MONSTER_RAT = 1;
        public const int ID_QUEST_KILLBOARS = 1;
        public const int ID_LOCATION_HOME = 1;
        public const int ID_LOCATION_TOWNSHIP = 2;


        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
            
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ID_WEAPON_SHORTSWORD, "Shortsword", "Shortswords", 0, 5));

        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(ID_MONSTER_RAT,"Rat", 15, 25, 1, 10, 10);
            Monsters.Add(rat);

        }

        private static void PopulateQuests()
        {
            Quest quest_kill_boars = new Quest(ID_QUEST_KILLBOARS, "Kill boars", "Kill 10 boars", 25, 25);
            Quests.Add(quest_kill_boars);

        }

        private static void PopulateLocations()
        {
            Location home = new Location(ID_LOCATION_HOME, "Home", "Your home");
            Location township = new Location(ID_LOCATION_TOWNSHIP, "Goldshire", "Goldshire town");

            home.LocationNorth = township;
            township.LocationSouth = home;

            Locations.Add(home);
            Locations.Add(township);       
        }               

        /**
         * This block of functions serves to retrieve monsters, quests,
         * items and locations via list position.
         * 
         * Iterate the list and return null if the token doesn't exist.  
         */
        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }

            }
            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location loc in Locations)
            {
                if (loc.ID == id)
                {
                    return loc;            
                }
            }
            return null;
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
