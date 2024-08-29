using _Scripts._InputSystem;
using _Scripts._Items;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts._Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int startingSlots = 10;
        [SerializeField] private GameObject inventoryView;
        
        [FormerlySerializedAs("items")] [SerializeField] private ItemSlot[] itemSlots;
        
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
        }
        
        public bool TryCollectItem(Item item)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].TryAddItem(item))
                {
                    return true;
                }
            }

            return false;
        }

        private void SwitchInventory(bool pressed)
        {
            Debug.Log(pressed);
            if (pressed)
            {
                if (isInventoryOpen)
                {
                    isInventoryOpen = false;
                    inventoryView.SetActive(isInventoryOpen);

                    _inputProvider.UpdateMouseDelta = !isInventoryOpen;
                    
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
  
                }
                else
                {
                    isInventoryOpen = true;
                    inventoryView.SetActive(isInventoryOpen);
                    
                    _inputProvider.UpdateMouseDelta = !isInventoryOpen;

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}