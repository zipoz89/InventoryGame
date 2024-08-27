using UnityEngine;

namespace _Scripts._Items
{
    [CreateAssetMenu(menuName = "InventoryGame/Items/Crafting Recipe"), System.Serializable]
    public class CraftingRecipe : ScriptableObject
    {
        public CraftingSlot[] Ingredients;
        public CraftingSlot[] Result;

        [Range(0, 100)] public float CraftingChance = 100f;
    }
    
    [System.Serializable]
    public class CraftingSlot
    {
        public Item Item;
        public int Amount = 1;
    }
}