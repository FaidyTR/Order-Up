using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string PlayerPref_SOUND_EFFECT_VOLUME = "SoundEffectVolume";

    [SerializeField] private SoundEffects soundEffects;
    public static SoundManager Instance { get; private set; }

    private float volume;

    private void Awake()
    {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PlayerPref_SOUND_EFFECT_VOLUME, 1f);
        StorveCounterSound.Instance.UpdateSoundVolume(volume);
    }

    private void Start()
    {
        RecipiesManager.Instance.OnRecipieDeliveredSuccess += RecipiesManager_OnRecipieDeliveredSuccess;
        RecipiesManager.Instance.OnRecipieDeliveredWrong += RecipiesManager_OnRecipieDeliveredWrong;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyTrashed;
        Player.Instance. OnPickSomething += Player_OnPickSomething;
        BaseCounter.OnAnyObjectDroped += BaseCounter_OnAnyObjectDroped;

    }
    private void BaseCounter_OnAnyObjectDroped(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySoundArray(soundEffects?.ObjectDrop, baseCounter.transform.position);
    }
    private void Player_OnPickSomething(object sender, System.EventArgs e)
    {
        Player player = Player.Instance;
        PlaySoundArray(soundEffects?.ObjectPieckup, player.transform.position);
    }
    private void TrashCounter_OnAnyTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySoundArray(soundEffects?.Trash, trashCounter.transform.position);
    }
    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySoundArray(soundEffects?.Chop, cuttingCounter.transform.position);
    }
    private void RecipiesManager_OnRecipieDeliveredWrong(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySoundArray(soundEffects?.DeliveryFail, deliveryCounter.transform.position);
    }
    private void RecipiesManager_OnRecipieDeliveredSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySoundArray(soundEffects?.DeliverySuccess, deliveryCounter.transform.position);
    }
    private void PlaySoundArray(AudioClip[] audioClipArray, Vector3 sourcePosition, float volume = 1)
    {
        if (audioClipArray == null || audioClipArray.Length == 0)
        {
            return;
        }
        AudioClip clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        if (clip == null) return;
        PlaySound(clip, sourcePosition, volume);
    }
    private void PlaySound(AudioClip audioClip, Vector3 sourceposition, float volume = 1)
    {
        if (audioClip == null) return;
        AudioSource.PlayClipAtPoint(audioClip, sourceposition, this.volume);
    }

    public void PlayFootstepsSound(Vector3 sourcePosition, float volume = 1)
    {
        PlaySoundArray(soundEffects.Footsteps, sourcePosition, this.volume);
    }

    public void UpdateSoundEffectVolume()
    {
        volume += .1f;
        if (volume > 1f) { volume = 0f; } 
        StorveCounterSound.Instance.UpdateSoundVolume(volume);

        PlayerPrefs.SetFloat(PlayerPref_SOUND_EFFECT_VOLUME, volume);
        PlayerPrefs.Save();
    }
    public float GetSoundEffectVolume()
    {
        return volume;
    }
}
