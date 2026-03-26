using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplatePrefab;
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Start()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }
    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        kitchenObjectSOList = plateKitchenObject.GetKitchenObjectSOList();
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplatePrefab) continue;
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectSO kitchenObjectSO in kitchenObjectSOList)
        {
            Transform iconTemplate = Instantiate(iconTemplatePrefab, transform);
            iconTemplate.GetComponent<IconTemplate>().EditIconVisual(kitchenObjectSO);
        }
    }

}
