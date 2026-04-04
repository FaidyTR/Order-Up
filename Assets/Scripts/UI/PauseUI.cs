using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class PauseUI : MonoBehaviour
{
    public static PauseUI Instance;

    [SerializeField] private Transform PauseMenuUI;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button settingsBtn;
    [SerializeField] private Button pauseBtn;

    public EventHandler OnPausMenuOpenned;
    public EventHandler OnPausMenuClosed;

    private void Awake()
    {
        Instance = this;

        continueBtn.onClick.AddListener(() => { 
            GameManager.Instance.PauseUnPauseGame();
            Hide();
        });
        mainMenuBtn.onClick.AddListener(() => { 
            Loader.Load(Loader.Scene.MainMenuScene);

        });
        settingsBtn.onClick.AddListener(() => {
            GameSettingsUI.Instance.Show();
        
        });
        pauseBtn.onClick.AddListener(() => {
            GameManager.Instance.PauseUnPauseGame();
            if (GameManager.Instance.GetIsGamePaused())
            {
                Show();
            }
        } );
    }
    private void Start()
    {
        Hide();

        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }
    private void GameInput_OnPauseAction(object sender, System.EventArgs e)
    {
        GameManager.Instance.PauseUnPauseGame();
        if (GameManager.Instance.GetIsGamePaused())
        {
            Show();
        }
        else
            Hide();
    }

    private void Hide()
    {
        PauseMenuUI.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
        GameSettingsUI.Instance.Hide();
        OnPausMenuClosed?.Invoke(this, EventArgs.Empty);
    }
    private void Show()
    {
        PauseMenuUI.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
        OnPausMenuOpenned ?.Invoke(this, EventArgs.Empty);
    }
}
