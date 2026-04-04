using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsUI : MonoBehaviour
{
    public static GameSettingsUI Instance;

    [SerializeField] private Transform gameSettingsMenuUI;
    [SerializeField] private Button musicVolumeBtn;
    [SerializeField] private Button soundEffectVolumeBtn;
    [SerializeField] private Button backBtn;

    [SerializeField] private TextMeshProUGUI musicVolumeTxt;
    [SerializeField] private TextMeshProUGUI soundEffectTxt;


    private void Awake()
    {
        Instance = this;

        musicVolumeBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.UpdateMusicVolume();
            UpdateVisual();
            
        });
        soundEffectVolumeBtn.onClick.AddListener(() =>
        {
            SoundManager.Instance.UpdateSoundEffectVolume();
            UpdateVisual();
        });
        backBtn.onClick.AddListener(() => {
            Hide();
        });
    }

    private void Start()
    {
        UpdateVisual();
        Hide();

    }

    public void Show()
    {
        gameSettingsMenuUI.gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameSettingsMenuUI.gameObject.SetActive(false);
    }
    private void UpdateVisual()
    {
        soundEffectTxt.text = "SoundEffect volume: " + Mathf.CeilToInt(SoundManager.Instance.GetSoundEffectVolume() * 10);
        musicVolumeTxt.text = "Music volume: " + Mathf.CeilToInt(MusicManager.Instance.GetMusicVolume() * 10);

    }
}
