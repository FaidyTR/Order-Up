using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    private KitchenObject kitchenObject;
    public static EventHandler OnAnyObjectDroped;
    [SerializeField] private Transform TopPointSpawn;
    public virtual void Interact(IKitchenObjectParent kitchenObjectParent)
    {
        Debug.LogError("BaseContainer Interact!");
    }
    public virtual void InteractAlternate(IKitchenObjectParent kitchenObjectParent)
    {
        Debug.LogError("BaseContainer InteractAlternate!");
    }
    public Transform GetTransformPosition()
    {
        return TopPointSpawn;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    { this.kitchenObject = kitchenObject; }
    public KitchenObject GetKitchenObject()
    { return kitchenObject; }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

}
