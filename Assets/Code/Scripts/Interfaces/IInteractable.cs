using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();

    public void OnTriggerEnter2D(Collider2D collider);

    public void OnTriggerExit2D(Collider2D collider);
}