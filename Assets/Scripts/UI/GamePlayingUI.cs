using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayingUI : MonoBehaviour
{

    [SerializeField] private Image backGround;
    [SerializeField] private Image timerCount;

    private void Awake()
    {
        Hide();
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        timerCount.fillAmount = 0f;
    }
    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GetStateIsGamePlaying())
        {
            Show();
        }
    }
    private void Update()
    {
        if (!GameManager.Instance.GetStateIsGamePlaying())
        {
            Hide();
        }
    }
    private void Hide()
    {
        backGround.gameObject.SetActive(false);
        timerCount.gameObject.SetActive(false);
    }
    private void Show()
    {
        backGround.gameObject.SetActive(true);
        timerCount.gameObject.SetActive(true);
        float timer = GameManager.Instance.GetGamePlayingTimer();
        timerCount.fillAmount = timer;
    }

}
