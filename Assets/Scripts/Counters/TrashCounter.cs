using UnityEngine;

public class TrashCounter : BaseCounter
{

    public override void Interact(IKitchenObjectParent player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
