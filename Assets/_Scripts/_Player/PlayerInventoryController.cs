using _Scripts._InputSystem;
using _Scripts._Items;
using _Scripts._Ui;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Scripts._Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onCraftingSuccessful;
        [SerializeField] private UnityEvent onCraftingUnsuccessful;
        
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

        public void RebuildInventory()
        {
            inventoryViewController.RebuildInventoryView(inventory);
            craftingViewController.RebuildCraftingView(inventory);
        }

        private void ItemDropped(Item item)
        {
            RebuildInventory();

            var itemDrop = GenericObjectPooler.SpawnObject(itemDropPrefab.gameObject, this.transform.position + this.transform.TransformDirection(dropPosition), quaternion.identity,
                GenericObjectPooler.PoolType.ItemDrop).GetComponent<ItemDrop>();
            itemDrop.Item = item;
            itemDrop.Rb.AddForce(this.transform.forward * throwPower);
        }

        public bool TryCollectItem(Item item)
        {
            var collected = inventory.TryCollectItem(item);
            if (true)
            {
                RebuildInventory();
            }

            return collected;
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
                    RebuildInventory();
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
            inventory.ConsumeItems(recpie);
            RebuildInventory();
            if (Random.Range(0, 100f) < recpie.CraftingChance) //Crafting success
            {
                Debug.Log("Crafting success ");
                
                foreach (var results in recpie.Result)
                {
                    for (int i = 0; i < results.Amount; i++)
                    {
                        var collected = inventory.TryCollectItem(new Item(results.item.Item));

                        if (!collected)
                        {
                            ItemDropped(results.item.Item);
                        }
                    }
                }
                
                RebuildInventory();
                
                onCraftingSuccessful?.Invoke();
            }
            else //Crafting failed
            {
                Debug.Log("Crafting failed");
                
                RebuildInventory();
                
                onCraftingUnsuccessful?.Invoke();
            }
            
        }
    }
}