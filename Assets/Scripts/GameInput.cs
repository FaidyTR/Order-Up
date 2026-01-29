using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateEvent;
    private PlayerInputAction playerInputAction;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Enable();
        playerInputAction.Player.Interact.performed += Intercat; 
        playerInputAction.Player.InteractAlternate.performed += IntercatAlternate;
    }
    private void Intercat(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (OnInteractAction != null)
        {
            OnInteractAction(this, EventArgs.Empty);
        }
    }
    private void IntercatAlternate(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (OnInteractAlternateEvent != null)
        {
            OnInteractAlternateEvent(this, EventArgs.Empty);
        }
    }

    public Vector2 GetInputVector()
    {
        return playerInputAction.Player.Move.ReadValue<Vector2>();
    }
}
