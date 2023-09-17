using BayatGames.SaveGameFree;
using PolyRunner.Items;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace PolyRunner.Core
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        private const string _saveKey = "Inventory";
        private List<Item> _itemList = new();

        private void Awake()
        {
            if (!SaveGame.Exists(_saveKey)) { return; }
            _itemList = SaveGame.Load<List<Item>>(_saveKey);
        }

        private void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 || _itemList.Count == 0) { return; }
            foreach (Item item in _itemList)
            {
                item.PerformItemAction();
            }
        }

        public bool AddItemToInventory(Item item)
        {
            if (item == null || Contains(item)) { return false; }
            
            _itemList.Add(item);
            SaveCurrentIventory();
            return true;
        }

        public void RemoveItemFormInventory(Item item)
        {
            if (item == null || !Contains(item)) { return; }
            _itemList.Remove(item);
            SaveCurrentIventory();
        }

        public bool Contains(Item currentItem)
        {
            return _itemList.Contains(currentItem);
        }

        private void SaveCurrentIventory()
        {
            SaveGame.Save(_saveKey, _itemList);
        }
    }
}
