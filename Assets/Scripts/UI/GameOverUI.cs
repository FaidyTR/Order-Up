using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RecipeDeliverdCountTxt;
    [SerializeField] private Transform GameoverScene;
    [SerializeField] private Button ReplayBtn;
    [SerializeField] private Button MainMenuBtn;

    private void Awake()
    {
        ReplayBtn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        MainMenuBtn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        Hide();
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }
    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.GetStateIsGameOver())
        {
            Show();
        }
    }
     private void Update()
    {
        if (!GameManager.Instance.GetStateIsGameOver())
        {
            Hide();
        }
    }
    private void Hide()
    {
        GameoverScene.gameObject.SetActive(false);
    }
    private void Show()
    {
        GameoverScene.gameObject.SetActive(true);
        int RecipeDeliverdCount = RecipiesManager.Instance.GetRecipeDeliveredSuccessCount();
        RecipeDeliverdCountTxt.text = RecipeDeliverdCount.ToString();

    }
}
