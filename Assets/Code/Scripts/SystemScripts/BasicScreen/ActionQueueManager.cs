using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueueManager : MonoBehaviour {
    [SerializeField] GameObject actionSlot;
    public void updateActionQueue() {
        List<ActionModel> actionList = ActionSceneManager.initActionList;
        foreach(ActionModel actionModel in actionList) {
            GameObject InstantiatedActionSlot= Instantiate(actionSlot);
            InstantiatedActionSlot.transform.SetParent(transform);
        }
    }

    public List<ActionModel> getActionList() {
        List<ActionModel> result = new List<ActionModel>();
        foreach(Transform actionSlotGameObject in transform) {
            foreach(Transform actionGameObject in actionSlotGameObject) {
                switch (actionGameObject.name.ToUpper()) {
                    case "ACTIONTURNLEFT(CLONE)": {
                        result.Add(new ActionModel(ActionName.TurnLeft));
                        break;
                    }
                    case "ACTIONTURNRIGHT(CLONE)": {
                        result.Add(new ActionModel(ActionName.TurnRight));
                        break;
                    }
                    case "ACTIONMOVEFORWARD(CLONE)": {
                        result.Add(new ActionModel(ActionName.MoveForward));
                        break;
                    }
                    case "ACTIONPICKUP(CLONE)": {
                        result.Add(new ActionModel(ActionName.PickUp)); 
                        break;
                    }

                }
            }
        }
        return result;
    }
}
