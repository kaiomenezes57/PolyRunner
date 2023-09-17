using UnityEngine;

namespace PolyRunner.Item
{
    [CreateAssetMenu(menuName = "Scriptables/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public string itemDescription;

        [Space]
        public Sprite itemImage;
        public double itemPrice;

        [Space]
        public ItemAction itemAction;

        public void PerformItemAction()
        {
            if (itemAction == null) { return; }
            itemAction.PerformAction();
        }
    }
}
