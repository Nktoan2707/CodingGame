using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {
    [SerializeField] GameObject actionQueueList;
    public void onRunClick() {
        List<ActionModel> actionQueue = actionQueueList.GetComponent<ActionQueueManager>().getActionList();
        string logString = "";
        foreach(ActionModel actionModel in actionQueue) {
            logString += $" > {actionModel.actionName}";
        }
        Debug.Log("Action Queue: " + logString);
    }
}
