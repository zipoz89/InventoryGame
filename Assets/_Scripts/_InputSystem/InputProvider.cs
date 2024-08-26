using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : MonoBehaviour
{
    private InventoryGameDefaultInput input;
    
    private bool isInteractPressed = false;
    private Vector2 moveVector = Vector2.zero;

    public bool IsInteractPressed => isInteractPressed;
    public Vector2 MoveVector => moveVector; 
    
    public event Action<bool> OnInteract;

    private void Awake()
    {
        input = new InventoryGameDefaultInput();
    }
    
    private void OnEnable()
    {
        input.Enable();
        input.FPSPlayer.Move.performed += OnMovePerformed;
        input.FPSPlayer.Interact.performed += OnInteractPerformed;
        
        input.FPSPlayer.Move.canceled += OnMoveCanceled;
        input.FPSPlayer.Interact.canceled += OnInteractPerformed;
    }
    
    private void OnDisable()
    {
        input.Disable();
        input.FPSPlayer.Move.performed -= OnMovePerformed;
        input.FPSPlayer.Interact.performed -= OnInteractPerformed;
        
        input.FPSPlayer.Move.canceled -= OnMoveCanceled;
        input.FPSPlayer.Interact.canceled -= OnInteractPerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveVector = ctx.ReadValue<Vector2>();
    }
    
    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveVector = Vector2.zero;
    }
    private void OnInteractPerformed(InputAction.CallbackContext ctx)
    {
        isInteractPressed = ctx.performed && !ctx.canceled;
            
        OnInteract?.Invoke(isInteractPressed);
    }

}
