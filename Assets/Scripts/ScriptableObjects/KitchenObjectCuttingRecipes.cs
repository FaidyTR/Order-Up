using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipesSO: ScriptableObject
{
    public KitchenObjectSO Input;
    public KitchenObjectSO Output;
    public int CuttingProgressMax;

}
