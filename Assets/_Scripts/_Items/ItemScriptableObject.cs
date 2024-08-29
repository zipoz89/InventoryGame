using UnityEngine;

namespace _Scripts._Items
{
    [CreateAssetMenu(menuName = "InventoryGame/Items/Item")]
    public class ItemScriptableObject : ScriptableObject
    {
        public Item Item;
    }

}