using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ContainerCounterVisual containerCounterVisual;



    public override void Interact (IKitchenObjectParent player)
    {
        if (!player.HasKitchenObject())
        {
            Transform kitchenObjectSpawned = Instantiate(kitchenObjectSO.Prefab);
            kitchenObjectSpawned.localPosition = Vector3.zero;
            containerCounterVisual.OpenContainerAnimation();

            kitchenObjectSpawned.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

        }

    }
    

}
