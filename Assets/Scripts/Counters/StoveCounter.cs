using System;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter,IHasProgress
{

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }

    public EventHandler <OnStateChangedEventArgs> OnStateChanged;
    public event EventHandler <IHasProgress.OnProgressChangedEventArgs> OnProgress;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }
    [SerializeField] private FryingRecipeSO[] fryingRecipesArray;
    private float fryingTimer;
    private KitchenObjectSO output;
    FryingRecipeSO fryingRecipe;
    private State state;

    private void Start()
    {
        state = State.Idle;

    }
    private void Update()
    {
        switch(state)
        {
            case State.Frying:
                fryingTimer += Time.deltaTime;
                if (fryingTimer > fryingRecipe.fryingTimeMax)
                {
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(output, this);
                    state = State.Fried;
                    fryingRecipe =  GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    output = GetOutputKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO());
                    fryingTimer = 0f;

                    if (OnStateChanged != null)
                    {
                        OnStateChanged(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                    }
                }
                if (OnProgress != null)
                {
                    OnProgress(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        cuttingProgressNormalized = fryingTimer / fryingRecipe.fryingTimeMax
                    });
                }
                break;
            case State.Fried:
                fryingTimer += Time.deltaTime;
                if (fryingTimer > fryingRecipe.fryingTimeMax)
                {
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(output, this);
                    state = State.Burned;
                    if (OnStateChanged != null)
                    {
                        OnStateChanged(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                    }
                    }
                if (OnProgress != null)
                {
                    OnProgress(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        cuttingProgressNormalized = fryingTimer / fryingRecipe.fryingTimeMax
                    });
                }

                break;
            case State.Burned:
                if (OnProgress != null)
                {
                    OnProgress(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        cuttingProgressNormalized = 0f
                    });
                }
                break;
        }

    }
    public override void Interact(IKitchenObjectParent player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    fryingRecipe = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    output = GetOutputKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO());
                    state = State.Frying;
                    fryingTimer = 0f;
                    if (OnStateChanged != null)
                    {
                        OnStateChanged(this, new OnStateChangedEventArgs
                        {
                            state = state
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
                ReturnToIdle();
            }
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                        ReturnToIdle();
                    }
                }
            }
            if (OnStateChanged != null)
            {
                OnStateChanged(this, new  OnStateChangedEventArgs{
                    state = state

                });
            }
        }

    }
    private void ReturnToIdle()
    {
        state = State.Idle;
        if (OnProgress != null)
        {
            OnProgress(this, new IHasProgress.OnProgressChangedEventArgs
            {
                cuttingProgressNormalized = 0f
            });
        }
    }
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        return fryingRecipesArray[0].Input == inputKitchenObjectSO;
    }
    private KitchenObjectSO GetOutputKitchenObjectSO(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.Output;
        }
        return null;
    }
    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    { 
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipesArray)
        {
            if (fryingRecipeSO.Input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }


}
