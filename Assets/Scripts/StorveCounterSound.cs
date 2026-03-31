using UnityEngine;

public class StorveCounterSound : MonoBehaviour
{ 
    private AudioSource audioSource;
    [SerializeField] private StoveCounter stoveCounter;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Start()
    {
        audioSource.Stop();
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
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
    }
}
