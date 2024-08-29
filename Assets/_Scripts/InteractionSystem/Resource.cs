using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Items;
using _Scripts._Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Resource : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemScriptableObject itemDrop;

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
            return true;
        }

        return false;
    }
}
