using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RecipeDeliverdCountTxt;
    [SerializeField] private Transform GameoverScene;

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
