using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Player;
using UnityEngine;

public class Resource : MonoBehaviour, IInteractable
{
    private int yield = 1; 
    private int currentResources = 1; 
    [SerializeField] private int maxResources = 1;

    private void Start()
    {
        currentResources = maxResources;
    }
    
    public bool Interact(PlayerInteractionController playerController)
    {
        playerController.CollcetItem();
        return true;
    }
}
