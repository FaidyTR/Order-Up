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
        animator.SetBool(Is_Walking, player.IsWalking());
    }


}
