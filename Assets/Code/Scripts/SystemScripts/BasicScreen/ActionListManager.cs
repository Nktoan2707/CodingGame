using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionListManager : MonoBehaviour {

    [SerializeField] GameObject actionSlot;
    [SerializeField] GameObject actionUp;
    [SerializeField] GameObject actionDown;
    [SerializeField] GameObject actionLeft;
    [SerializeField] GameObject actionRight;
    [SerializeField] GameObject actionPickUp;

    public void updateActionList() {
        List<ActionModel> actionList = ActionSceneManager.initActionList;
        foreach(ActionModel actionModel in actionList) {
            switch (actionModel.actionName.ToUpper()) {
                case "UP": {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionUp);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                case "DOWN": {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionDown);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                case "LEFT": {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionLeft);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                case "RIGHT": {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionRight);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                case "PICKUP": {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionPickUp);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
            }
        }
    }
}
