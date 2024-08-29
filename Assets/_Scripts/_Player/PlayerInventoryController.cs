using _Scripts._InputSystem;
using _Scripts._Items;
using _Scripts._Ui;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts._Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField] private int startingSlots = 10;
        [SerializeField] private GameObject inventoryView;
        [SerializeField] private ItemDrop itemDropPrefab;
        [SerializeField] private Vector3 dropPosition = new Vector3(0,1,1);
        [SerializeField] private float throwPower = 1;
        [FormerlySerializedAs("inventoryPanelController")] [SerializeField] private InventoryViewController inventoryViewController;
        [SerializeField] private CraftingViewController craftingViewController;
        
        //[SerializeField] private ItemSlot[] itemSlots;
        [SerializeField] private Inventory inventory;
        
        private InputProvider _inputProvider;

        private bool isInventoryOpen = false;
        
        public void Initialize(InputProvider inputProvider)
        {
            _inputProvider = inputProvider;

            inventory = new(startingSlots);
            
            _inputProvider.OnInventory += SwitchInventory;
            inventoryViewController.OnItemDropped += ItemDropped;
            craftingViewController.OnRecipeCraft += CraftRecpie;
        }

        private void ItemDropped(Item item)
        {
            inventoryViewController.RebuildInventoryView(inventory);
            craftingViewController.RebuildCraftingView(inventory);

            var itemDrop = GenericObjectPooler.SpawnObject(itemDropPrefab.gameObject, this.transform.position + this.transform.TransformDirection(dropPosition), quaternion.identity,
                GenericObjectPooler.PoolType.ItemDrop).GetComponent<ItemDrop>();
            itemDrop.Item = item;
            itemDrop.Rb.AddForce(this.transform.forward * throwPower);
        }

        public bool TryCollectItem(Item item)
        {
            var result = inventory.TryCollectItem(item);
            if (true)
            {
                inventoryViewController.RebuildInventoryView(inventory);
                craftingViewController.RebuildCraftingView(inventory);
            }

            return result;
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
                    inventoryViewController.RebuildInventoryView(inventory);
                    craftingViewController.RebuildCraftingView(inventory);
                    isInventoryOpen = true;
                    inventoryView.SetActive(isInventoryOpen);
                    
                    _inputProvider.PlayerInInventory = isInventoryOpen;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        
        private void CraftRecpie(CraftingRecipe recpie)
        {
        }
    }
}