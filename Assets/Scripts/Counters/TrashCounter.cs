using System;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static EventHandler OnAnyObjectTrashed;
    public override void Interact(IKitchenObjectParent player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
