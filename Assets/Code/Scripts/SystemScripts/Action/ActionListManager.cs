using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionListManager : MonoBehaviour
{



    [SerializeField] GameObject actionSlot;
    [SerializeField] GameObject actionTurnLeft;
    [SerializeField] GameObject actionTurnRight;
    [SerializeField] GameObject actionMoveForward;
    [SerializeField] GameObject actionPickUp;
    [SerializeField] GameObject actionFunction;
    [SerializeField] GameObject actionFor;
    [SerializeField] GameObject actionToggleSwitch;
    [SerializeField] GameObject actionAttack;

    private void addNewAction(GameObject actionPrefab)
    {
        GameObject InstantiatedActionSlot = Instantiate(actionSlot);
        InstantiatedActionSlot.transform.SetParent(transform);

        GameObject instantiatedAction = Instantiate(actionPrefab);
        instantiatedAction.transform.SetParent(InstantiatedActionSlot.transform);
    }
    public void updateActionList()
    {
        List<ActionModel> actionList = ActionSceneManager.initActionList;

        foreach (ActionModel actionModel in actionList)
        {
            switch (actionModel.actionName)
            {
                case ActionName.TurnLeft:
                    {
                        addNewAction(actionTurnLeft);
                        break;
                    }
                case ActionName.TurnRight:
                    {
                        addNewAction(actionTurnRight);
                        break;
                    }
                case ActionName.MoveForward:
                    {
                        addNewAction(actionMoveForward);
                        break;
                    }
                case ActionName.PickUp:
                    {
                        addNewAction(actionPickUp);
                        break;
                    }
                case ActionName.Function:
                    {
                        addNewAction(actionFunction);
                        break;
                    }
                case ActionName.For:
                    {
                        addNewAction(actionFor);
                        break;
                    }
                case ActionName.ToggleSwitch:
                    {
                        addNewAction(actionToggleSwitch);
                        break;
                    }
                case ActionName.Attack:
                    {
                        addNewAction(actionAttack);
                        break;
                    }
            }
        }
    }
}
