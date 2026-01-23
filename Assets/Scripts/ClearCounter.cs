using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform TomatoPrefab;
    [SerializeField] private Transform TopPointSpawn;

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.transform);
        Transform tomaotoSpawned = Instantiate(TomatoPrefab, TopPointSpawn);
        tomaotoSpawned.localPosition = Vector3.zero;
        //hello 
    }
}
