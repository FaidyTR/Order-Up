using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Transform PauseMenuUI;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button settingsBtn;
    [SerializeField] private Button pauseBtn;

    private void Awake()
    {
        continueBtn.onClick.AddListener(() => { 
            GameManager.Instance.PauseUnPauseGame();
            Hide();
        });
        mainMenuBtn.onClick.AddListener(() => { 
            Loader.Load(Loader.Scene.MainMenuScene);

        });
        settingsBtn.onClick.AddListener(() => { 
        
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
    }
    private void Show()
    {
        PauseMenuUI.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }
}
