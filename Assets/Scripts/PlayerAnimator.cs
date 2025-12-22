using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private Player player;
    private Animator animator;
    private const string Is_Walking = "IsWalking";
    private void Awake()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();
        animator.SetBool(Is_Walking, false);
    }
    private void Update()
    {
        animator.SetBool(Is_Walking, player.IsMoving());
    }
}
