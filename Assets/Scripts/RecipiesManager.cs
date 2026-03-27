using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class RecipiesManager : MonoBehaviour
{
    public static RecipiesManager Instance { get; private set; }

    [SerializeField] private RecipiesListSO RecipiesListSO;
    private List<RecipieSO> waitingRecipies;
    private float timer;
    private float waitingTimer = 2f;
    private int maxWaitingRecipies = 4;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        waitingRecipies = new List<RecipieSO>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTimer)
        {
            timer = 0f;
            if (waitingRecipies.Count < maxWaitingRecipies)
            {
                waitingRecipies.Add(RecipiesListSO.recipiesSOList[Random.Range(0, RecipiesListSO.recipiesSOList.Count)]);
                Debug.Log("New Recipie Added! " + waitingRecipies[waitingRecipies.Count-1].Name);
            }
        }

    }
    public void DeliverRecipie(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipies.Count; i++)
        {
            if(PlateKitchenObjectMatchWaitingRecipie(plateKitchenObject, waitingRecipies[i]))
            {
                Debug.Log("Recipie Delivered! " + waitingRecipies[i].Name);
                waitingRecipies.RemoveAt(i);
                return;
            }
        }
            Debug.Log("Recipie Wrong!");
    }
    private bool PlateKitchenObjectMatchWaitingRecipie(PlateKitchenObject plateKitchenObject, RecipieSO recipieSO)
    {
        var plateList = plateKitchenObject.GetKitchenObjectSOList();
        var recipieList = recipieSO.kitchenObjectSOList;
        if (plateList == null || recipieList == null) return false;
        if (plateList.Count != recipieList.Count) return false;


        List<KitchenObjectSO> recipieCopy = new List<KitchenObjectSO>(recipieList);

        foreach (KitchenObjectSO plateObj in plateList)
        {
            if (recipieCopy.Contains(plateObj))
            {
                recipieCopy.Remove(plateObj);
            }
            else return false;
        }

        return recipieCopy.Count == 0;
    }

}
