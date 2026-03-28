using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private Transform iconTemplate;
    [SerializeField] private Transform icon;
    [SerializeField] private TextMeshProUGUI nameRecipie;
    private void Awake()
    {
        icon.gameObject.SetActive(false);
    }
    public void GetRecipieSO(RecipieSO recipie)
    {
        nameRecipie.text = recipie.Name;
        foreach (Transform child in iconTemplate)
        {
            if (child == icon) continue;
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectSO kitchenObjectSO in recipie.kitchenObjectSOList)
        {
            Transform iconTransform = Instantiate(icon, iconTemplate);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<UnityEngine.UI.Image>().sprite = kitchenObjectSO.Sprite;
        }
    }
}
