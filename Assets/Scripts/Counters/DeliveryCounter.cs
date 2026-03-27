using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(IKitchenObjectParent player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                plateKitchenObject.DestroySelf();
                RecipiesManager.Instance.DeliverRecipie(plateKitchenObject);
            }
        }
    }
}
