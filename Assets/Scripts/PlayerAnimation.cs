using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private const string Is_Walking = "IsWalking";
    [SerializeField] private Player player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (player == null)
        {
            animator.SetBool(Is_Walking, true);
            return;
        }
        animator.SetBool(Is_Walking, player.IsWalking());
    }


}
