using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] CounterSelectedVisual;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (baseCounter == e.selectedCounter)
        {
            ShowSelectedCounterVisula();
        }
        else { HideSelectedCounterVisual(); }
    }
    private void ShowSelectedCounterVisula()
    {
        foreach(GameObject CounterSelectedVisual in CounterSelectedVisual)
        {
            CounterSelectedVisual.SetActive(true);
        }
 
    }
    private void HideSelectedCounterVisual()
    {
        foreach (GameObject CounterSelectedVisual in CounterSelectedVisual)
        {
            CounterSelectedVisual.SetActive(false);
        }
    }

}
