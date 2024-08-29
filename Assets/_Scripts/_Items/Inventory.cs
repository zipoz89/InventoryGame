using UnityEngine;

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
                if (inventorySlots[i].item != null && inventorySlots[i].item.Name == item.Name)
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

        public bool ContainsAllIngredients(ScriptableItems[] Ingredients)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                if (!Contrains(Ingredients[i].item.Item, Ingredients[i].Amount))
                {
                    return false;
                }
            }

            return true;
        }

        
        public bool ConsumeItems(CraftingRecipe recpie)
        {
            if (!ContainsAllIngredients(recpie.Ingredients))
            {
                return false;
            }
            foreach (var items in recpie.Ingredients)
            {
                if (!ConsumeItem(items.item.Item,items.Amount))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ConsumeItem(Item item, int amount)
        {
            int amountConsumed = 0;
            for (int i = inventorySlots.Length - 1; i >= 0; i--)
            {
                
                
                ItemSlot inventorySlot = inventorySlots[i];

                if (inventorySlot.item != null && inventorySlot.item.Name == item.Name)
                {
                    int amountToConsume = 0;
                    if (amount - amountConsumed > inventorySlot.Amount)
                    {
                        amountToConsume = inventorySlot.Amount;
                    }
                    else
                    {
                        amountToConsume = amount - amountConsumed;
                    }

                    inventorySlot.ConsumeGreedy(amountToConsume);

                    amountConsumed += amountToConsume;
                }

                if (amountConsumed >= amount)
                {
                    return true;
                }

            }

            return false;
        }
    }
}