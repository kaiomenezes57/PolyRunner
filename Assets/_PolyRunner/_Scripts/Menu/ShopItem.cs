using PolyRunner.Core;
using PolyRunner.Items;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PolyRunner.Menu
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private TextMeshProUGUI _itemPrice;
        [SerializeField] private Image _itemImage;
        
        [Space, SerializeField] private Button _buyButton;
        private Item _currentItem;

        private async void Start()
        {
            while (_currentItem == null) { await Task.Delay(10); }
            
            if (!InventoryManager.Instance.Contains(_currentItem))
            {
                _buyButton.interactable = true;
                _buyButton.onClick.AddListener(() => {
                    if (_currentItem == null) { return; }
                    WarningScreen.Instance.ShowWarningScreen(
                        "Buy Item", 
                        $"You sure you want to buy {_currentItem.itemName} by {_currentItem.itemPrice:F2} BHC?", 
                        () => { WarningScreen.Instance.HideWarningScreen(); Shop.Instance.Buy(_currentItem); } );
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

            _itemPrice.text = $"{item.itemPrice:F2} BHC";

            _currentItem = item;
        }
    }
}
