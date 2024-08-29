using UnityEngine;

namespace _Scripts._Items
{

    [System.Serializable]
    public class Item
    {
        public string Name;
        public Sprite UiSprite;
        public int MaxStackSize = 64;
        
        public override bool Equals ( object obj )
        {
            return this.Name == (obj as Item)?.Name;
        }

    }
}
