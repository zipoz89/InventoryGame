using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Items;
using _Scripts._Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.VFX;

public class Resource : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemScriptableObject itemDrop;

    [SerializeField] private UnityEvent onPickup;
    private int currentResources = 1; 
    [SerializeField] private int maxResources = 1;

    private void Start()
    {
        currentResources = maxResources;
    }
    
    public bool Interact(PlayerInteractionController playerController)
    {
        if (currentResources < 1)
        {
            return false;
        }

        if(playerController.TryCollectItem(new Item(itemDrop.Item)))
        {
            currentResources--;
            onPickup.Invoke();
            return true;
        }

        return false;
    }
}
