using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform GetTransformPosition();
    public void SetKitchenObject(KitchenObject kitchenObject);
    public KitchenObject GetKitchenObject();
    public bool HasKitchenObject();

}
