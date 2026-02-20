using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    [SerializeField] private GameObject IHasProgress;
    [SerializeField] private Image bar ;
    private IHasProgress hasProgress;


    private void Awake()
    {
        hasProgress = IHasProgress.GetComponent<IHasProgress>();
        if (hasProgress == null)
        {
            Debug.LogError("IHasProgress component not found on " + IHasProgress.name);
        }
    }   

    private void Start()
    {
        hasProgress.OnProgress += IHasProgress_OnProgressChanged;

        bar.fillAmount = 0f;
        Hide();
    }
    private void IHasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        bar.fillAmount = e.cuttingProgressNormalized;
        if (e.cuttingProgressNormalized == 0f || e.cuttingProgressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);

    }
    private void Show()
    {
        gameObject.SetActive(true);
    }



}
