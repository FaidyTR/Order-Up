using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;
    private const string CUT = "Cut";

    private void Start()
    {
        animator = GetComponent<Animator>();
        cuttingCounter.OnCutAnimation += CuttingCounter_OnCutAnimation;
    }
    private void CuttingCounter_OnCutAnimation(object sender, System.EventArgs e)
    {
        OpenContainerAnimation();
    }
    public void OpenContainerAnimation()
    {
        animator.SetTrigger(CUT);
    }
}
