using UnityEngine;

namespace _Scripts._Items
{
    [CreateAssetMenu(menuName = "InventoryGame/Items/Crafting Recipe"), System.Serializable]
    public class CraftingRecipe : ScriptableObject
    {
        public ScriptableItems[] Ingredients;
        public ScriptableItems[] Result;

        [Range(0, 100)] public float CraftingChance = 100f;

        public bool CheckIfCraftable(Inventory inventory)
        {
            foreach (var ingredient in Ingredients)
            {
                if (!inventory.Contrains(ingredient.item.Item, ingredient.Amount))
                {
                    return false;
                }
            }
            
            return true;
        }
    }


}