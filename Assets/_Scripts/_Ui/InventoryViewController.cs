using System;
using System.Collections.Generic;
using _Scripts._Items;
using UnityEngine;

namespace _Scripts._Ui
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private Transform itemsContentPanel;
        [SerializeField] private ItemDisplay itemDisplayPrefab;

        private List<(ItemSlot, ItemDisplay)> itemSlotsDisplay;
        
        public Action<Item> OnItemDropped;
        
        public void RebuildInventoryView(ItemSlot[] itemSlots)
        {
            ClearInventoryView();
            
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (!itemSlots[i].IsEmpty())
                {
                    var display = GenericObjectPooler.SpawnObject(itemDisplayPrefab.gameObject, Vector3.zero, Quaternion.identity, GenericObjectPooler.PoolType.ItemDisplay).GetComponent<ItemDisplay>();
                    display.transform.SetParent(itemsContentPanel);
                    itemSlotsDisplay.Add((itemSlots[i], display));
                    display.OnItemDropped += ItemDropped;
                    
                    display.SetUp(itemSlots[i]);
                }
            }
        }

        private void ItemDropped(Item item)
        {
            OnItemDropped?.Invoke(item);
        }

        private void ClearInventoryView()
        {
            if (itemSlotsDisplay == null)
            {
                itemSlotsDisplay = new();
            }
            else
            {
                for (int i = 0; i < itemSlotsDisplay.Count; i++)
                {
                    itemSlotsDisplay[i].Item2.OnItemDropped -= ItemDropped;
                    GenericObjectPooler.ReturnObjectToPool(itemSlotsDisplay[i].Item2.gameObject);
                }
                itemSlotsDisplay = new();
            }


        }
    }
}
