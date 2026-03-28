using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform RecipieItemTemplate;
    private void Awake()
    {
        RecipieItemTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        RecipiesManager.Instance.OnRecipiesChanged += RecipiesManager_OnRecipiesChanged;
    }
    private void RecipiesManager_OnRecipiesChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == RecipieItemTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach (RecipieSO recipieSO in RecipiesManager.Instance.GetWaitingRecipies())
        {
            Transform recipieItemTransform = Instantiate(RecipieItemTemplate, container);
            recipieItemTransform.gameObject.SetActive(true);
            recipieItemTransform.GetComponent<DeliveryManagerSingleUI>().GetRecipieSO(recipieSO);
        }
    }
}
