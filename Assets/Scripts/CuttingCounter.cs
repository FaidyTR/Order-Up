using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private CuttingRecipesSO[] cuttingRecipesArray;

    public override void Interact(IKitchenObjectParent player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() )//&& HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO() ))
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }
    public override void InteractAlternate(IKitchenObjectParent player)
    {
        if (HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(GetOutputKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO()), this);
        }

    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipesSO cuttingRecipeSO in cuttingRecipesArray)
        {
            if (cuttingRecipeSO.Input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }
    private KitchenObjectSO GetOutputKitchenObjectSO(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipesSO cuttingRecipeSO in cuttingRecipesArray)
        {
            if (cuttingRecipeSO.Input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.Output;
            }
        }
        return null;
    }

}
