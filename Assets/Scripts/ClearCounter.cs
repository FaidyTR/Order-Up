using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private KitchenObject kitchenObject;
    [SerializeField] private Transform TopPointSpawn;


    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectSpawned = Instantiate(kitchenObjectSO.Prefab, TopPointSpawn);
            kitchenObjectSpawned.localPosition = Vector3.zero;

            kitchenObjectSpawned.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
        }

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
