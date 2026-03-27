using UnityEngine;
using UnityEngine.UI;
public class PlateIconTemplate : MonoBehaviour
{
    [SerializeField] private Image icon;
    public void SetKitchenObjectSO(KitchenObjectSO kitchenObjectSO)
    {
        icon.sprite = kitchenObjectSO.Sprite;
    }
}
