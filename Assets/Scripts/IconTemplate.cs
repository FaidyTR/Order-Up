
using UnityEngine;
using UnityEngine.UI;

public class IconTemplate : MonoBehaviour
{
    [SerializeField] private Image image;

    public void EditIconVisual(KitchenObjectSO kitchenObjectSO)
    {
        image.sprite  = kitchenObjectSO.Sprite;
    }
}
