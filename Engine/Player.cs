using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests;
        public Location CurrentLocation { get; set; }

        public Player(int currentHP, int maxHP, int gold, int xp, int level) : base(currentHP, maxHP)
        {
            Gold = gold;
            Experience = xp;
            Level = level;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        // Check for zone item requirements
        public bool HasRequiredItemToEnter(Location location)
        {
            if (location.ItemRequired == null)
            {
                return true;

            }
            foreach (InventoryItem item in Inventory)
            {
                if (item.Details.ID == location.ItemRequired.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasAllItemsToComplete(Quest quest)
        {
            foreach(QuestCompletionItem qci in quest.QuestCompletionItems){
                bool foundInInventory = false;
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        foundInInventory = true;
                        if (ii.Quantity < qci.Quantity)
                        {
                            return false;                       
                        }
                    }
                }
                if (!foundInInventory)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveQuestItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        ii.Quantity -= qci.Quantity;
                        break;

                    }

                }

            }

        }

        public void AddItemToInventory(Item additem)
        {
            foreach(InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == additem.ID)
                {
                    // Increase item quantity if the item already exists in inventory
                    ii.Quantity++;
                    return;
                }
            }
            Inventory.Add(new InventoryItem(additem, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            foreach(PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    pq.IsCompleted = true;
                    return;
                }
            }
        }
    }
}
