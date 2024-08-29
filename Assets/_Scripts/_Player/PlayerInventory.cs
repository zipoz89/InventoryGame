using _Scripts._InputSystem;
using _Scripts._Items;
using _Scripts._Ui;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts._Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int startingSlots = 10;
        [SerializeField] private GameObject inventoryView;
        [SerializeField] private ItemDrop itemDropPrefab;
        [SerializeField] private Vector3 dropPosition = new Vector3(0,1,1);
        [SerializeField] private float throwPower = 1;
        [FormerlySerializedAs("inventoryPanelController")] [SerializeField] private InventoryViewController inventoryViewController;
        
        [SerializeField] private ItemSlot[] itemSlots;
        
        private InputProvider _inputProvider;

        private bool isInventoryOpen = false;
        
        public void Initialize(InputProvider inputProvider)
        {
            _inputProvider = inputProvider;

            itemSlots = new ItemSlot[startingSlots];

            for (int i = 0; i < startingSlots; i++)
            {
                itemSlots[i] = new ItemSlot();
            }
            
            _inputProvider.OnInventory += SwitchInventory;
            inventoryViewController.OnItemDropped += ItemDropped;
        }

        private void ItemDropped(Item item)
        {
            inventoryViewController.RebuildInventoryView(itemSlots);

            var itemDrop = GenericObjectPooler.SpawnObject(itemDropPrefab.gameObject, this.transform.position + this.transform.TransformDirection(dropPosition), quaternion.identity,
                GenericObjectPooler.PoolType.ItemDrop).GetComponent<ItemDrop>();
            itemDrop.Item = item;
            itemDrop.Rb.AddForce(this.transform.forward * throwPower);
        }

        public bool TryCollectItem(Item item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].TryAddItem(item))
                {
                    inventoryViewController.RebuildInventoryView(itemSlots);
                    return true;
                }
            }

            return false;
        }

        private void SwitchInventory(bool pressed)
        {
            if (pressed)
            {
                if (isInventoryOpen)
                {
                    isInventoryOpen = false;
                    inventoryView.SetActive(isInventoryOpen);

                    _inputProvider.PlayerInInventory = isInventoryOpen;
                    
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
  
                }
                else
                {
                    inventoryViewController.RebuildInventoryView(itemSlots);
                    isInventoryOpen = true;
                    inventoryView.SetActive(isInventoryOpen);
                    
                    _inputProvider.PlayerInInventory = isInventoryOpen;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}