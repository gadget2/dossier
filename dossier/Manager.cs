using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace dossier
{
    public partial class Manager : Form
    {
        private Player _player;
        private Monster _currentmonster;
        public Manager()
        {
            InitializeComponent();
            _player = new Player(10, 10, 20, 0, 1);
            labelHP.Text = _player.CurrentHP.ToString();
            labelGold.Text = _player.Gold.ToString();
            labelEXP.Text = _player.Experience.ToString();
            labelLevel.Text = _player.Level.ToString();
            
        }

        private void MoveTo(Location newLocation)
        {
            // Check to determine if the location has any items required to enter
            //if (newLocation.ItemRequired != null)
            //{
            //    bool playerHasItem = false;
            //    // Check each item in invetory and compare their IDs
            //    foreach (InventoryItem item in _player.Inventory)
            //    {
            //        if (item.Details.ID == newLocation.ItemRequired.ID)
            //        {
            //            playerHasItem = true;
            //            break;                    
            //        }
            //    }
            //    // If the item wasn't found in inventory
            //    if (!playerHasItem)
            //    {
            //        rtbMessages.Text = "You must have " + newLocation.ItemRequired.Name + " to enter here." + Environment.NewLine;
            //        return;
            //    }
            //}
                if (!_player.HasRequiredItemToEnter(newLocation))
                {
                    rtbMessages.Text += "You must have a " + newLocation.ItemRequired.Name + " to enter this location." + Environment.NewLine;
                    return;
                }           
            
            // Set current location of player to the new location, assuming item requirements are met
            _player.CurrentLocation = newLocation;

            // Set visibility of directional buttons
            btnNorth.Visible = (newLocation.LocationNorth != null);
            btnSouth.Visible = (newLocation.LocationSouth != null);
            btnWest.Visible = (newLocation.LocationWest != null);
            btnEast.Visible = (newLocation.LocationEast != null);

            // Display current player location with accompanying description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            // This logic will enable zone changes to completely heal the player. Should exclude this as it's 
            // ridiculously cheesable
            //_player.CurrentHP = _player.MaxHP;
            //passiveLabelHP.Text = _player.CurrentHP.ToString();

            // Check locations if there is an available quest there
            if (newLocation.QuestAvailable != null)
            {
                bool playerHasQuest = false;
                bool playerHasCompletedQuest = false;

                // Check each quest in the players quest log via ID comparison
                foreach (PlayerQuest quest in _player.Quests)
                {
                    if(quest.Details.ID == newLocation.QuestAvailable.ID)
                    {
                        playerHasQuest = true;
                        // Check for completion
                        if (quest.IsCompleted == true)
                        {
                            playerHasCompletedQuest = true;
                        }
                    }
                }
                // If the player has the quest, but is yet to complete it, run this routine
                if (playerHasQuest)
                {
                    if (!playerHasCompletedQuest)
                    {
                        bool playerHasItemsToComplete = true;
                        // Check quest items for quests available in the location
                        bool playerHasAllItemsToComplete = _player.HasAllItemsToComplete(newLocation.QuestAvailable);
                        // If the player has all items to complete the quest
                        if (playerHasItemsToComplete)
                        {
                            // Print result to manager
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailable.Name + " completed" + Environment.NewLine;

                            // Remove quest items from player inventory, iterate through the required items
                            // for the quest existing in the zone
                            _player.RemoveQuestItems(newLocation.QuestAvailable);

                            // Quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            // XP 
                            rtbMessages.Text += newLocation.QuestAvailable.RewardXP.ToString() + " experience points" + Environment.NewLine;
                            // Gold
                            rtbMessages.Text += newLocation.QuestAvailable.RewardGold.ToString() + " gold" + Environment.NewLine;
                            // Items
                            rtbMessages.Text += newLocation.QuestAvailable.RewardItem.Name.ToString() + Environment.NewLine;
                            // Append experience and gold to player instances
                            _player.Experience += newLocation.QuestAvailable.RewardXP;
                            _player.Gold += newLocation.QuestAvailable.RewardGold;

                            // Add any items gained as a reward to the player inventory
                            _player.AddItemToInventory(newLocation.QuestAvailable.RewardItem);
                            // Mark quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvailable);
                        }
                    }
                }
                // If the player does NOT have the quest, run this routine
                else
                {
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailable.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailable.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete, return with " + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailable.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;
                    // Add quest to the players quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailable));
                }
            }
            // if a monster exists in this zone, 
            if (newLocation.MonsterHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterHere.Name + Environment.NewLine;
                // Init monster, pull values from World instance
                Monster standardMonster = World.MonsterByID(newLocation.MonsterHere.ID);
                _currentmonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaxDamage, 
                    standardMonster.RewardXP, standardMonster.RewardGold, standardMonster.CurrentHP, standardMonster.MaxHP);
                // Pull loot table values to monster
                foreach (LootItem lootitem in standardMonster.LootTable)
                {
                    _currentmonster.LootTable.Add(lootitem);
                }
                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUsePotion.Visible = true;
                btnUseWeapon.Visible = true;
            }
            // If monster doesn't exist in this zone. set to null
            else
            {
                _currentmonster = null;
                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
                btnUseWeapon.Visible = false;
            }
            // Refresh inventory list
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";
            dgvInventory.Rows.Clear();

            foreach(InventoryItem item in _player.Inventory)
            {
                if (item.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { item.Details.Name, item.Quantity.ToString() });
                }
            }

            // Refresh quest list
            dgvQuests.RowHeadersVisible = false;
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Done?";

            dgvInventory.Rows.Clear();

            foreach (PlayerQuest quest in _player.Quests)
            {
                dgvQuests.Rows.Add(new[] { quest.Details.Name, quest.IsCompleted.ToString() });             
            }

            // Refresh combo box for players weapons
            List<Weapon> weapons = new List<Weapon>();
            foreach (InventoryItem item in _player.Inventory)
            {
                if (item.Details is Weapon)
                {
                    if (item.Quantity > 0)
                    {
                        weapons.Add((Weapon)item.Details);
                    }                 
                }
            }
            // If player has no weapons, hide combobox and use button
            if (weapons.Count == 0)
            {
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
                cboWeapons.SelectedIndex = 0;
            }

            // Refresh healing potions combo box
            List<HealingPotion> potions = new List<HealingPotion>();
            foreach (InventoryItem item in _player.Inventory)
            {
                if (item.Details is HealingPotion)
                {
                    if (item.Quantity > 0)
                    {
                        potions.Add((HealingPotion)item.Details);
                    }
                }
            }
            // If player has no potions, hide combobox and use button
            if (potions.Count == 0)
            {
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else              
            {             
                cboPotions.DataSource = potions;
                cboPotions.DisplayMember ="Name";               
                cboPotions.ValueMember = "ID";               
                cboPotions.SelectedIndex = 0;
            }
        }
        private void btnUseWeapon_Click(object sender, EventArgs e)
        {

        }
        private void btnUsePotion_Click(object sender, EventArgs e)
        {

        }
    }
}
