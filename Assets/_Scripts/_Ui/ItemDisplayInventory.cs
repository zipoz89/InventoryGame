using System;
using _Scripts._Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts._Ui
{
    public class ItemDisplayInventory : MonoBehaviour
    {
        [SerializeField] private Image itemSprite;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemAmount;

        private ItemSlot itemSlot;
        
        public Action<Item> OnItemDropped;

        public void SetUp(ItemSlot itemSlot)
        {
            //Debug.Log("Set up " + itemSlot.item.Name + " amopunt" + itemSlot.Amount);

            this.itemSlot = itemSlot;
            
            itemSprite.sprite = itemSlot.item.UiSprite;
            itemName.text = itemSlot.item.Name;
            itemAmount.text = itemSlot.Amount.ToString();
        }

        public void DropItem()
        {
            if (itemSlot.TryDropItem())
            {
                OnItemDropped?.Invoke(itemSlot.item);
            }

        }
    }
}
