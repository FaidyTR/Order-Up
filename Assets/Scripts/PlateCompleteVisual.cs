using System;
using System.Collections.Generic;
using UnityEngine;
using static PlateKitchenObject;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    private struct IngredientKitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private List<IngredientKitchenObjectSO_GameObject> ingredientGameObjectList;
    [SerializeField] private PlateKitchenObject plateKitchenObject;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        HideAllIngredient();
    }
    private void PlateKitchenObject_OnIngredientAdded(object sender, OnIngredientAddedEventArgs e)
    {
        foreach (IngredientKitchenObjectSO_GameObject ingredientKitchenObjectSO_GameObject in ingredientGameObjectList)
        {
            if (ingredientKitchenObjectSO_GameObject.kitchenObjectSO == e.kitchenObjectSO)
            {
                ShowIngredient(ingredientKitchenObjectSO_GameObject);
            }
        }
    }
    private void ShowIngredient(IngredientKitchenObjectSO_GameObject ingredientKitchenObjectSO_GameObject)
    {
        ingredientKitchenObjectSO_GameObject.gameObject.SetActive(true);
    }
    private void HideAllIngredient()
    {
        foreach (IngredientKitchenObjectSO_GameObject ingredientKitchenObjectSO_GameObject in ingredientGameObjectList)
        {
            ingredientKitchenObjectSO_GameObject.gameObject.SetActive(false);
        }
    }
}
