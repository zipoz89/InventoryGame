using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Items;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemDefinition;
    [SerializeField] private Item item;
    [SerializeField] private Rigidbody rb;

    public Rigidbody Rb => rb;

    public Item Item
    {
        get => item;
        set => item = value;
    }

    

    private void Awake()
    {
        if (itemDefinition)
        {
            item = itemDefinition.Item;
            itemDefinition = null;
        }

    }
    
}
