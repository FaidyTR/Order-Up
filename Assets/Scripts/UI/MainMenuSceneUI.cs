
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuSceneUI : MonoBehaviour
{
    [SerializeField] private Button playbutton;
    [SerializeField] private Button quitbutton;
    [SerializeField] private Button settingbutton;

    private void Awake()
    {
        playbutton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
            quitbutton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        settingbutton.onClick.AddListener(() => { 
            MainMenuSettingUI.Instance.Show();
        } );

        Time.timeScale = 1f;
    }
}
