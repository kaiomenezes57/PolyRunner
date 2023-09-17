using PolyRunner.Core;
using PolyRunner.Items;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PolyRunner.Menu
{
    public class Shop : Singleton<Shop>
    {
        [SerializeField] private ShopItem _shopItemPrefab;
        [SerializeField] private Transform _contentTransform;

        [SerializeField] private List<Item> _itemList = new();
        private List<ShopItem> _spawnedShopItemList = new();

        private void Start()
        {
            ClearAllItemsOnShop();
            SpawnAllItemsOnShop();
        }

        public void Buy(Item item)
        {
            if (CoinManager.Instance.CoinAmount < item.itemPrice) { return; }
            
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

    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private Image _itemImage;
        
        [Space, SerializeField] private Button _buyButton;
        private Item _currentItem;

        private async void Start()
        {
            while (_currentItem == null) { await Task.Delay(10); }
            
            if (InventoryManager.Instance.Contains(_currentItem))
            {
                _buyButton.interactable = true;
                _buyButton.onClick.AddListener(() => {
                    if (_currentItem == null) { return; }
                    Shop.Instance.Buy(_currentItem);
                });

                return;
            }

            _buyButton.interactable = false;
        }

        public void Setup(Item item)
        {
            _itemName.text = item.name;
            _itemDescription.text = item.itemDescription;
            _itemImage.sprite = item.itemImage;

            _currentItem = item;
        }
    }
}
