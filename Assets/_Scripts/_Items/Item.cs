using UnityEngine;

namespace _Scripts._Items
{

    [System.Serializable]
    public class Item
    {
        public string Name;
        public Sprite UiSprite;
        public int MaxStackSize = 64;
    }
}
