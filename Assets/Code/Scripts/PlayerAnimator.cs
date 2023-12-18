using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string DIRECTION = "Direction";
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

    void Update()
    {
        Vector2 movingDirection = player.GetMovingDirection();
        if (movingDirection.y == -1)
        {
            animator.SetInteger(DIRECTION, SOUTH);

        } else if (movingDirection.y == 1)
        {
            animator.SetInteger(DIRECTION, NORTH);

        } else if (movingDirection.x == 1)
        {
            animator.SetInteger(DIRECTION, EAST);

        }
        else if (movingDirection.x == -1)
        {
            animator.SetInteger(DIRECTION, WEST);

        }


        animator.SetBool("IsMoving", movingDirection.magnitude > 0);
    }
}
