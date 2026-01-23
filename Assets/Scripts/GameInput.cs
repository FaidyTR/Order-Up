using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputAction playerInputAction;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Enable();
        playerInputAction.Player.Interact.performed += Intercat; 
    }
    private void Intercat(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (OnInteractAction != null)
        {
            OnInteractAction(this, EventArgs.Empty);
        }
    }

    public Vector2 GetInputVector()
    {
        return playerInputAction.Player.Move.ReadValue<Vector2>();
    }
}
