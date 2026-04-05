using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettingUI : MonoBehaviour
{
    public static MainMenuSettingUI Instance { get; private set; }

    [SerializeField] private Transform SettingUIMenu;
    [SerializeField] private Button gameTimeBtn;
    [SerializeField] private Button backBtn;

    [SerializeField] private TextMeshProUGUI playingTimeTxt;

    private const string PLAYING_TIME = "Playing time";
    private float gamePlayingTimer;
    private void Awake()
    {
        Instance = this;

        gameTimeBtn.onClick.AddListener(() =>
        {
            UpdateGamePlayingTimer();
            UpdateVisual();

        });
        backBtn.onClick.AddListener(() =>
        {
            Hide();
        });

        gamePlayingTimer = PlayerPrefs.GetFloat(PLAYING_TIME, 30f);
    }
    private void Start()
    {
        UpdateVisual();
        Hide();
    }

    private void UpdateVisual()
    {
        playingTimeTxt.text = "Playing time: " + Mathf.CeilToInt(gamePlayingTimer) + "s";
    }
     public void UpdateGamePlayingTimer()
    {
        gamePlayingTimer += 15f;
        if (gamePlayingTimer > 120f)
        {
            gamePlayingTimer = 15f;
        }
        PlayerPrefs.SetFloat(PLAYING_TIME, gamePlayingTimer);
        PlayerPrefs.Save();
    }




    public void Hide()
    {
        SettingUIMenu.gameObject.SetActive(false);
    }
    public void Show()
    {
        SettingUIMenu.gameObject.SetActive(true);
    }
    public float GetGamePlayingTimer()
    {
        return gamePlayingTimer;
    }  

}
