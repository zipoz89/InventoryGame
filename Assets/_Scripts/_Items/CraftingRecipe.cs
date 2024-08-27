using UnityEngine;

namespace _Scripts._Items
{
    [CreateAssetMenu(menuName = "InventoryGame/Items/Crafting Recipe"), System.Serializable]
    public class CraftingRecipe : ScriptableObject
    {
        public ItemSlot[] Ingredients;
        public ItemSlot[] Result;

        [Range(0, 100)] public float CraftingChance = 100f;
    }
    

}