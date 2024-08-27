using System.Collections;
using System.Collections.Generic;
using _Scripts._Player;
using UnityEngine;

public interface IInteractable
{
    public abstract bool Interact(PlayerInteractionController playerController);
}
