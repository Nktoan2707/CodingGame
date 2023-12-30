using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {
    [SerializeField] GameObject actionQueueList;
    public void onRunClick() {
        List<ActionModel> actionQueue = actionQueueList.GetComponent<ActionQueueManager>().getActionList();
        Player.Instance.CatchEventQueue(actionQueue);
    }
}
