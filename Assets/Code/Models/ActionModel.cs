using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionName
{
    TurnLeft, TurnRight, MoveForward, PickUp, ToggleSwitch
}

public class ActionModel {
    public ActionName actionName;

    public ActionModel(ActionName actionName){
        this.actionName = actionName;
    }
}
