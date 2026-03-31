using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
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
