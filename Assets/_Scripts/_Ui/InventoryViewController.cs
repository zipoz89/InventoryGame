using System;
using System.Collections.Generic;
using _Scripts._Items;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts._Ui
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private Transform itemsContentPanel;
        [FormerlySerializedAs("itemDisplayPrefab")] [SerializeField] private ItemDisplayInventory itemDisplayInventoryPrefab;

        private List<ItemDisplayInventory> itemSlotsDisplay;
        
        public Action<Item> OnItemDropped;
        
        public void RebuildInventoryView(Inventory inventory)
        {
            ClearInventoryView();
            
            Debug.Log("Rebuilduje?");
            
            for (int i = 0; i < inventory.inventorySlots.Length; i++)
            {
                if (!inventory.inventorySlots[i].IsEmpty())
                {
                    var display = GenericObjectPooler.SpawnObject(itemDisplayInventoryPrefab.gameObject, Vector3.zero, Quaternion.identity, GenericObjectPooler.PoolType.ItemDisplay).GetComponent<ItemDisplayInventory>();
                    display.gameObject.SetActive(true);
                    display.transform.SetParent(itemsContentPanel);
                    itemSlotsDisplay.Add( display);
                    display.OnItemDropped += ItemDropped;
                    
                    display.SetUp(inventory.inventorySlots[i]);
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
                    itemSlotsDisplay[i].OnItemDropped -= ItemDropped;
                    GenericObjectPooler.ReturnObjectToPool(itemSlotsDisplay[i].gameObject);
                }
                itemSlotsDisplay = new();
            }


        }
    }
}
