using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionListManager : MonoBehaviour {

    

    [SerializeField] GameObject actionSlot;
    [SerializeField] GameObject actionTurnLeft;
    [SerializeField] GameObject actionTurnRight;
    [SerializeField] GameObject actionMoveForward;
    [SerializeField] GameObject actionPickUp;

    public void updateActionList() {
        List<ActionModel> actionList = ActionSceneManager.initActionList;
        foreach(ActionModel actionModel in actionList) {
            switch (actionModel.actionName) {
                case ActionName.TurnLeft: {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionTurnLeft);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                case ActionName.TurnRight: {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionTurnRight);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                case ActionName.MoveForward: {
                    GameObject InstantiatedActionSlot= Instantiate(actionSlot);
                    InstantiatedActionSlot.transform.SetParent(transform);
                    GameObject InstantiatedActionUp= Instantiate(actionMoveForward);
                    InstantiatedActionUp.transform.SetParent(InstantiatedActionSlot.transform);
                    break;
                }
                
                case ActionName.PickUp: {
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
