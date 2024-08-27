using UnityEngine;

namespace _Scripts._Items
{
    [CreateAssetMenu(menuName = "InventoryGame/Items/Item")]
    public class Item : ScriptableObject
    {
        public string Name;
        public Sprite UiSprite;
        public int MaxStackSize = 64;
    }
}
