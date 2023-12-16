using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionModel {
    public string actionName {
       get { return actionName; }
       set { actionName = value; }
    }

    public ActionModel(string actionName){
        this.actionName = actionName;
    }
}
