using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGem : MonoBehaviour, IInteractable
{


    public void Interact()
    {
        GemCountingManager.Instance.CurrentNumberOfGems += 1;
        Destroy(gameObject);
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.AddInteractableObject(this);
        }
    }
}
