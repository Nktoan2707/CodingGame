using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string DIRECTION = "Direction";

    [SerializeField] private Player player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movingDirection = player.GetMovingDirection();
        animator.SetInteger(DIRECTION, 0);
        animator.SetBool("IsMoving", player.IsMoving);
    }
}
