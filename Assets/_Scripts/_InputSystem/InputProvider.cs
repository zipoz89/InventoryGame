using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : MonoBehaviour
{
    private InventoryGameDefaultInput input;
    
    private bool isInteractPressed = false;
    private bool isJumpPressed = false;
    private Vector2 moveVector = Vector2.zero;
    private Vector2 mouseDelta = Vector2.zero;
    
    public bool IsInteractPressed => isInteractPressed;
    public bool IsJumpPressed => isJumpPressed;
    public Vector2 MoveVector => moveVector; 
    public Vector2 MouseDelta => mouseDelta; 
    
    public event Action<Vector2> OnMove;
    public event Action<bool> OnInteract;
    public event Action<bool> OnJump;

    private void Awake()
    {
        input = new InventoryGameDefaultInput();
    }
    
    private void OnEnable()
    {
        input.Enable();
        input.FPSPlayer.Move.performed += OnMovePerformed;
        input.FPSPlayer.Interact.performed += OnInteractPerformed;
        input.FPSPlayer.Jump.performed += OnJumpPerformed;
        
        input.FPSPlayer.Move.canceled += OnMoveCanceled;
        input.FPSPlayer.Interact.canceled += OnInteractPerformed;
        input.FPSPlayer.Jump.canceled += OnJumpPerformed;
    }

    void Update()
    {
        mouseDelta = Mouse.current.delta.ReadValue();
    }

    private void OnDisable()
    {
        input.Disable();
        input.FPSPlayer.Move.performed -= OnMovePerformed;
        input.FPSPlayer.Interact.performed -= OnInteractPerformed;
        input.FPSPlayer.Jump.performed -= OnJumpPerformed;
        
        input.FPSPlayer.Move.canceled -= OnMoveCanceled;
        input.FPSPlayer.Interact.canceled -= OnInteractPerformed;
        input.FPSPlayer.Jump.canceled -= OnJumpPerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveVector = ctx.ReadValue<Vector2>();
        OnMove?.Invoke(moveVector);
    }
    
    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveVector = Vector2.zero;
        OnMove?.Invoke(moveVector);
    }
    private void OnInteractPerformed(InputAction.CallbackContext ctx)
    {
        isInteractPressed = ctx.performed && !ctx.canceled;
            
        OnInteract?.Invoke(isInteractPressed);
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        isJumpPressed = ctx.performed && !ctx.canceled;
        
        OnJump?.Invoke(isInteractPressed);
    }

    
}
