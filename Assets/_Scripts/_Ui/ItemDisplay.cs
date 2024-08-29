using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts._Ui
{
    public class ItemDisplay : MonoBehaviour
    {
        [SerializeField] private Image itemSprite;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI itemAmount;

        public Action OnDropRequested;
    
        public void DropItem()
        {
            OnDropRequested?.Invoke();
        }
    }
}
