using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(IKitchenObjectParent player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            // Counter has an object
            if (!player.HasKitchenObject())
            {
                // Player empty -> pick up from counter
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            else
            {
                // Both have objects -> try to combine (add ingredients to plate)
                // Try add counter object to player's plate
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject playerPlate))
                {
                    if (playerPlate.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                // Otherwise try add player's object to counter plate
                else if (GetKitchenObject().TryGetPlate(out PlateKitchenObject counterPlate))
                {
                    if (counterPlate.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        player.GetKitchenObject().DestroySelf();
                    }
                }
            }
        }

    }
}
