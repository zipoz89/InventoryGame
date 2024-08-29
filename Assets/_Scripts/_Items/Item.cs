using UnityEngine;

namespace _Scripts._Items
{

    [System.Serializable]
    public class Item
    {
        public string Name;
        public Sprite UiSprite;
        public int MaxStackSize = 64;

        public Item(Item item)
        {
            this.Name = item.Name;
            this.UiSprite = item.UiSprite;
            this.MaxStackSize = item.MaxStackSize;
        }

    }
}
