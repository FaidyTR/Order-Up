using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private const string PlayerPrefs_Music_VolumeKey = "MusicVolume";

    public static MusicManager Instance;
    private AudioSource audioSource;
    private float volume;


    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        volume = PlayerPrefs.GetFloat(PlayerPrefs_Music_VolumeKey, .3f);
        audioSource.volume = volume;
    }
    public void UpdateMusicVolume()
    {
        volume += .1f;
        if (volume > 1f) { volume = 0; }
        audioSource.volume = volume;

        PlayerPrefs.SetFloat(PlayerPrefs_Music_VolumeKey, volume);
        PlayerPrefs.Save();
    }
    public float GetMusicVolume() { return volume; }
}
