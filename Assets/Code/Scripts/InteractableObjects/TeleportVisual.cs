using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVisual : MonoBehaviour
{
    private const string IS_ENABLED = "IsEnabled";

    [SerializeField] private Teleport teleport;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator != null)
        {
            animator.SetBool(IS_ENABLED, teleport.IsEnabled);

        }
    }
}
