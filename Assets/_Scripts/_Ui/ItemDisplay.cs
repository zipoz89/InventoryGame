using System;
using _Scripts._Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts._Ui
{
    public class ItemDisplay : MonoBehaviour
    {
        [SerializeField] private Image itemSprite;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemAmount;

        public Action OnDropRequested;

        public void SetUp(ItemSlot itemSlot)
        {
            Debug.Log("Set up " + itemSlot.item.Name + " amopunt" + itemSlot.Amount);
            
            itemSprite.sprite = itemSlot.item.UiSprite;
            itemName.text = itemSlot.item.Name;
            itemAmount.text = itemSlot.Amount.ToString();
        }

        public void DropItem()
        {
            OnDropRequested?.Invoke();
        }
    }
}
