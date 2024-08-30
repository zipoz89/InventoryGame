using _Scripts._Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts._Ui
{
    public class ItemDisplayCompact : MonoBehaviour
    {
        [SerializeField] private Image itemSprite;
        [SerializeField] private TextMeshProUGUI itemAmount;
        private ScriptableItems itemSlot;
        
        public void SetUp(ScriptableItems itemSlot)
        {
            //Debug.Log("Set up " + itemSlot.item.Name + " amopunt" + itemSlot.Amount);

            this.itemSlot = itemSlot;
            
            itemSprite.sprite = itemSlot.item.Item.UiSprite;
            itemAmount.text = itemSlot.Amount.ToString();
        }

    }
}