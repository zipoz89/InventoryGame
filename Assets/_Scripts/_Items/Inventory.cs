namespace _Scripts._Items
{
    public class Inventory
    {
        public ItemSlot[] inventorySlots;

        public Inventory(int startingSlots)
        {
            inventorySlots = new ItemSlot[startingSlots];

            for (int i = 0; i < startingSlots; i++)
            {
                inventorySlots[i] = new ItemSlot();
            }
        }

        public bool Contrains(Item item, int amount)
        {
            int amountFound = 0;

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].item == item)
                {
                    amountFound += inventorySlots[i].Amount;
                }

                if (amountFound >= amount)
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryCollectItem(Item item)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].TryAddItem(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}