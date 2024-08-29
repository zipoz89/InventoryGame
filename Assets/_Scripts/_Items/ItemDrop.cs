using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Items;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemDefinition;
    [SerializeField] private Item item;

    public Item Item => item;

    private void Awake()
    {
        item = itemDefinition.Item;
    }
    
}
