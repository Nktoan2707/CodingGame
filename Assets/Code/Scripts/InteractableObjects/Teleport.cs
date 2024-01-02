using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
    [SerializeField] Teleport linkedTeleport;
    public bool IsEnabled { get; set; }
    public bool IsOccupied { get; set; }

    private void Awake()
    {
        IsEnabled = false;
        IsOccupied = false;
    }

    public void Interact()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            if (linkedTeleport != null && IsEnabled && !IsOccupied)
            {
                player.transform.position = linkedTeleport.transform.position;
                player.MovingDestination = linkedTeleport.transform.position;
                linkedTeleport.IsOccupied = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        IsOccupied = false;
    }
}
