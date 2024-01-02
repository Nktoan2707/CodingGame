using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionName
{
<<<<<<< HEAD
    TurnLeft, TurnRight, MoveForward, PickUp, Function, For
=======
    TurnLeft, TurnRight, MoveForward, PickUp, ToggleSwitch, Attack
>>>>>>> 422a1a5 (add creature die function + basic level 5)
}

public class ActionModel {
    public ActionName actionName;

    public ActionModel(ActionName actionName){
        this.actionName = actionName;
    }
}
