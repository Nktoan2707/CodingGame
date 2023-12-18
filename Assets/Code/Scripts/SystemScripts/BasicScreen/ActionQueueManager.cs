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
                    case "ACTIONUP(CLONE)": {
                        result.Add(new ActionModel("UP"));
                        break;
                    }
                    case "ACTIONDOWN(CLONE)": {
                        result.Add(new ActionModel("DOWN"));
                        break;
                    }
                    case "ACTIONLEFT(CLONE)": {
                        result.Add(new ActionModel("LEFT"));
                        break;
                    }
                    case "ACTIONRIGHT(CLONE)": {
                        result.Add(new ActionModel("RIGHT")); 
                        break;
                    }
                    case "ACTIONPICKUP(CLONE)": {
                        result.Add(new ActionModel("PICKUP")); 
                        break;
                    }

                }
            }
        }
        return result;
    }
}
