using UnityEngine;
using System;

public class CuttingCounter : BaseCounter,IHasProgress
{
    public EventHandler OnCutAnimation;
    public static  EventHandler OnAnyCut;
    public event EventHandler <IHasProgress.OnProgressChangedEventArgs> OnProgress;
    [SerializeField] private CuttingRecipesSO[] cuttingRecipesArray;
    private int cuttingProgress;


    public override void Interact(IKitchenObjectParent player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    CuttingRecipesSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    cuttingProgress = 0;
                    if (OnProgress != null)
                    {
                        OnProgress(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            cuttingProgressNormalized = (float)cuttingProgress / cuttingRecipeSO.CuttingProgressMax
                        });
                    }

                }
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
            }
        }

    }
    public override void InteractAlternate(IKitchenObjectParent player)
    {
        if ( HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            CuttingRecipesSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            cuttingProgress++;
            if (OnCutAnimation != null) 
            {
                OnCutAnimation(this, EventArgs.Empty);
            }
            OnAnyCut?.Invoke(this, EventArgs.Empty);

            if (OnProgress != null)
            {
                OnProgress(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    cuttingProgressNormalized = (float)cuttingProgress / cuttingRecipeSO.CuttingProgressMax
                });
            }
            OnCutAnimation?.Invoke(this, EventArgs.Empty);

            if (cuttingProgress >= cuttingRecipeSO.CuttingProgressMax)
            {
                KitchenObjectSO outputKitchenOjectSO = GetOutputKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputKitchenOjectSO, this);
            }
        }

    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipesSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        return cuttingRecipeSO != null;
    }
    private KitchenObjectSO GetOutputKitchenObjectSO(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipesSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.Output;
        }
        return null;
    }
    private CuttingRecipesSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipesSO cuttingRecipeSO in cuttingRecipesArray)
        {
            if (cuttingRecipeSO.Input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }


}
