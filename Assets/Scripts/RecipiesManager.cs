using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RecipiesManager : MonoBehaviour
{
    [SerializeField] private RecipiesListSO OriginalRecipiesList;
    private List<RecipieSO> WaitingRecipiesList;
    private float timer;
    private float timerMax = 4f;
    private int MaxWaitingRecipies = 4;
    private void Awake()
    {
        WaitingRecipiesList = new List<RecipieSO>();
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0f;
            if (WaitingRecipiesList.Count < MaxWaitingRecipies)
            {
                WaitingRecipiesList.Add(OriginalRecipiesList.ReciepiesList[Random.Range(0, OriginalRecipiesList.ReciepiesList.Count)]);
            }
        }

    }
    public void DeliverRecipie(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < WaitingRecipiesList.Count; i++)
        {
            if (WaitingRecipiesList[i].KitchenObjcetSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {



            }

        }

    }
}
