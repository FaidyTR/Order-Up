using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class RecipiesManager : MonoBehaviour
{
    [SerializeField] private RecipiesListSO RecipiesListSO;
    private List<RecipieSO> waitingRecipies;
    private float timer;
    private float waitingTimer = 2f;
    private int maxWaitingRecipies = 4;

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

}
