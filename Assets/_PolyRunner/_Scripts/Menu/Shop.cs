using PolyRunner.Core;
using PolyRunner.Items;
using System.Collections.Generic;
using UnityEngine;

namespace PolyRunner.Menu
{
    public class Shop : Singleton<Shop>
    {
        [SerializeField] private ShopItem _shopItemPrefab;
        [SerializeField] private Transform _contentTransform;

        [SerializeField] private List<Item> _itemList = new();
        private readonly List<ShopItem> _spawnedShopItemList = new();

        private void Start()
        {
            ClearAllItemsOnShop();
            SpawnAllItemsOnShop();
        }

        public void Buy(Item item)
        {
            if (CoinManager.Instance.CoinAmount < item.itemPrice) { WarningScreen.Instance.ShowWarningScreen("Error", "You don't have coins for it"); return; }
            
            if (InventoryManager.Instance.AddItemToInventory(item))
            {
                CoinManager.Instance.RemoveCoin(item.itemPrice);
            }
        }

        public void SpawnAllItemsOnShop()
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                ShopItem shopItem = Instantiate(_shopItemPrefab.gameObject, _contentTransform).GetComponent<ShopItem>();
                shopItem.Setup(_itemList[i]);

                _spawnedShopItemList.Add(shopItem);
            }
        }

        public void ClearAllItemsOnShop()
        {
            if (_spawnedShopItemList == null || _spawnedShopItemList.Count == 0) { return; }
            
            _spawnedShopItemList.ForEach(i => Destroy(i));
            _spawnedShopItemList?.Clear();
        }
    }
}
