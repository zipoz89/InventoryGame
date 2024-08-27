using UnityEngine;
using UnityEngine.Internal;

namespace _Scripts._Items
{
 
    [CreateAssetMenu(menuName = "InventoryGame/Items/Crafting Recipe Table")]
    public class CraftingRecipeTable : ScriptableObject
    {
        [SerializeField] private CraftingRecipe[] recpies;
    }
}