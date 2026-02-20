
using UnityEngine;
using System.Collections.Generic;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private PlateCounter plateCounter;
    [SerializeField] private Transform CounterTopPoint;
    [SerializeField] private Transform PlatesVisual;

    private List <GameObject> Plates ;

    private void Awake()
    {
        Plates = new List<GameObject>();
    }
    private void Start()
    {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlateRemoved += PlateCounter_OnPlateRemoved;
    }
    private void PlateCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject PlateRemovedVisual = Plates[Plates.Count - 1];
        Plates.Remove(PlateRemovedVisual);
        Destroy(PlateRemovedVisual);

    }
    private void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform PlateSpawnedTransform = Instantiate(PlatesVisual, CounterTopPoint);
        float PlateOffsetY = 0.1f ;
        PlateSpawnedTransform.localPosition = new Vector3(0, PlateOffsetY * Plates.Count, 0);
        Plates.Add(PlateSpawnedTransform.gameObject);


    }
}
