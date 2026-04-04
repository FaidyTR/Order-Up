using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {  get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateEvent;
    public event EventHandler OnPauseAction;
    private PlayerInputAction playerInputAction;

    private void Awake()
    {
        Instance = this;

        playerInputAction = new PlayerInputAction();
        playerInputAction.Enable();
        playerInputAction.Player.Interact.performed += Intercat; 
        playerInputAction.Player.InteractAlternate.performed += IntercatAlternate;
        playerInputAction.Player.Pause.performed += Pause_performed;
    }
    private void OnDestroy()
    {
        playerInputAction.Player.Interact.performed -= Intercat;
        playerInputAction.Player.InteractAlternate.performed -= IntercatAlternate;
        playerInputAction.Player.Pause.performed -= Pause_performed;
        playerInputAction.Dispose();
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
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
