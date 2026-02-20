using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject sizzilingParticales;
    [SerializeField] private GameObject stoveCounterOnVisual;
    [SerializeField] private StoveCounter stoveCounter;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        if (e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried)
        {
            ShowStoveCounterONEffects();
        }
        else
        {
            HideStoveCounterONEffects();
        }
    }
    private void ShowStoveCounterONEffects() 
    {
        sizzilingParticales.SetActive(true);
        stoveCounterOnVisual.SetActive(true);
    }
    private void HideStoveCounterONEffects()
    {
        sizzilingParticales.SetActive(false);
        stoveCounterOnVisual.SetActive(false);
    }

}
