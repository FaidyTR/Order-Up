using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ContainerCounterVisual containerCounterVisual;



    public override void Interact (IKitchenObjectParent player)
    {
        if (!player.HasKitchenObject())
        {
            containerCounterVisual.OpenContainerAnimation();

            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
        }

    }
    

}
