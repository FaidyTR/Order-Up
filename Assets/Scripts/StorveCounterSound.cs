using UnityEngine;

public class StorveCounterSound : MonoBehaviour
{ 
    public static StorveCounterSound Instance;

    private AudioSource audioSource;
    [SerializeField] private StoveCounter stoveCounter;
    private float volume = 1f;
    private StoveCounter.State laststate;


    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        PauseUI.Instance.OnPausMenuOpenned += PauseUI_OnPausMenuOpenned;
        PauseUI.Instance.OnPausMenuClosed += PauseUI_OnPausMenuClosed;

        laststate = StoveCounter.State.Idle;
        audioSource.Stop();
    }
    private void PauseUI_OnPausMenuClosed(object sender, System.EventArgs e)
    {
        if (laststate == StoveCounter.State.Frying || laststate == StoveCounter.State.Fried)
        {
            audioSource.Play();
        }
    }   
    private void PauseUI_OnPausMenuOpenned(object sender, System.EventArgs e)
    {
        audioSource.Stop();
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        if (e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        laststate = e.state;
    }

    public void UpdateSoundVolume(float volume)
    {
        this.volume = volume / 2;
        if (this.volume < .2f && this.volume != 0)
        {
            this.volume = .1f;
        }
        audioSource.volume = this.volume;
    }
}
