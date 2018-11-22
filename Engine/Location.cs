using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location(int id, string name, string desc, 
            Item itemReq = null, 
            Quest questHere = null,
            Monster monsterHere = null)
        {
            ID = id;
            Name = name;
            Description = desc;
            ItemRequired = itemReq;
            QuestAvailable = questHere;
            MonsterHere = monsterHere;

        }
        public Item ItemRequired { get; set; }
        public Quest QuestAvailable { get; set; }
        public Monster MonsterHere { get; set; }
        public Location LocationNorth { get; set; }
        public Location LocationSouth { get; set; }
        public Location LocationWest { get; set; }
        public Location LocationEast { get; set; }

    }
}
