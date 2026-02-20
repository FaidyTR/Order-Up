using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator animator;
    private const string open_Close = "OpenClose";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenContainerAnimation()
    {
        animator.SetTrigger(open_Close);
    }
}
