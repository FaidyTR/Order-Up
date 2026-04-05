using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayingUI : MonoBehaviour
{

    [SerializeField] private Image backGround;
    [SerializeField] private Image timerCount;

    private void Awake()
    {
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        timerCount.fillAmount = 0f;
        Hide();
    }
    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GetStateIsGamePlaying())
        {
            Show();
        }
    }
    private void Hide()
    {
        timerCount.gameObject.SetActive(false);
        backGround.gameObject.SetActive(true);
    }
    private void Show()
    {
        backGround.gameObject.SetActive(true);
        timerCount.gameObject.SetActive(true);
        float timer = GameManager.Instance.GetGamePlayingTimerNormiliezd();
        timerCount.fillAmount = timer;
    }

}
