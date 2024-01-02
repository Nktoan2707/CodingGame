using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Teleport> teleportList;


    public void Interact()
    {
        foreach (Teleport teleport in teleportList)
        {
            teleport.IsEnabled = !teleport.IsEnabled;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.AddInteractableObject(this);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.RemoveInteractableObject(this);
        }
    }
}
