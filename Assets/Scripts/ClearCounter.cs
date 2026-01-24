using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform Prefab;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform TopPointSpawn;

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.transform);
        Transform kitchenObjectSpawned = Instantiate(Prefab, TopPointSpawn);
        kitchenObjectSpawned.localPosition = Vector3.zero;
        Debug.Log("Spawned " + kitchenObjectSpawned.GetComponent<KitchenObject>().GetKitchenObjectSO().ObjectName);
    }
}
