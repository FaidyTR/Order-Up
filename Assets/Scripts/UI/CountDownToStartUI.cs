using TMPro;
using UnityEngine;

public class CountDownToStartUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

    private void Awake()
    {
        Hide();
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }
    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GetStateIsCountdownToStart())
        {
            Show();
        }
    }
     private void Update()
    {
        if (!GameManager.Instance.GetStateIsCountdownToStart())
        {
            Hide();
        }
    }
    private void Hide()
    {
        countDownText.gameObject.SetActive(false);
    }
    private void Show()
    {
        countDownText.gameObject.SetActive(true);
        float timer = GameManager.Instance.GetCountDownToStartTimer();
        int timerCeil = Mathf.CeilToInt(timer);
        countDownText.text = timerCeil.ToString();
    }
}
