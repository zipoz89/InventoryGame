using UnityEngine.Serialization;

namespace _Scripts._Items
{
    [System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int Amount = 0;

        public bool TryAddItem(Item itemToAdd)
        {
            if (item == null || item.Name == "")
            {
                item = itemToAdd;
                Amount = 1;
                return true;
            }
            else if (item.Name == itemToAdd.Name && Amount < item.MaxStackSize)
            {
                Amount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmpty()
        {
            return item == null;
        }
    }
}