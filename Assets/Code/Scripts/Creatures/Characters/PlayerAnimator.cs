using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string FLOAT_MOVING_DIRECTION_X = "MovingDirectionX";
    private const string FLOAT_MOVING_DIRECTION_Y = "MovingDirectionY";
    private const string TRIGGER_HIT = "Hit";
    private const string TRIGGER_ATTACK = "Attack";

    private const int SOUTH = 0;
    private const int NORTH = 1;
    private const int EAST = 2;
    private const int WEST = 3;

    [SerializeField] private Player player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player.OnHit += Player_OnHit;
        player.OnAttack += Player_OnAttack;
    }

    private void Player_OnAttack(object sender, System.EventArgs e)
    {
        animator.SetTrigger(TRIGGER_ATTACK);

    }

    private void Player_OnHit(object sender, System.EventArgs e)
    {
        animator.SetTrigger(TRIGGER_HIT);

    }

    void Update()
    {
        animator.SetBool("IsMoving", player.IsMoving);
        Vector2 movingDirection = player.GetMovingDirection();
        animator.SetFloat(FLOAT_MOVING_DIRECTION_X, movingDirection.x);
        animator.SetFloat(FLOAT_MOVING_DIRECTION_Y, movingDirection.y);
    }
}
