using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionForManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField inputField;
    void Start()
    {
        inputField.text = "1";
    }

    public List<ActionModel> getActionForLoop()
    {
        List<ActionModel> result = new List<ActionModel>();

        int loopTime = Int32.Parse(inputField.text);

        List<ActionModel> actionLoop = new List<ActionModel>();
        foreach (Transform element in transform)
        {
            switch (element.GetChild(0).name.ToUpper())
            {
                case "ACTIONTURNLEFT(CLONE)":
                    {
                        actionLoop.Add(new ActionModel(ActionName.TurnLeft));
                        break;
                    }
                case "ACTIONTURNRIGHT(CLONE)":
                    {
                        actionLoop.Add(new ActionModel(ActionName.TurnRight));
                        break;
                    }
                case "ACTIONMOVEFORWARD(CLONE)":
                    {
                        actionLoop.Add(new ActionModel(ActionName.MoveForward));
                        break;
                    }
                case "ACTIONPICKUP(CLONE)":
                    {
                        actionLoop.Add(new ActionModel(ActionName.PickUp));
                        break;
                    }
                case "ACTIONFUNCTION(CLONE)":
                    {
                        actionLoop.AddRange(FunctionActionQueue.Instance.getActionFunctionList());
                        break;
                    }
                case "ACTIONTOGGLESWITCH(CLONE)":
                    {
                        actionLoop.Add(new ActionModel(ActionName.ToggleSwitch));
                        break;
                    }
                case "ACTIONATTACK(CLONE)":
                    {
                        actionLoop.Add(new ActionModel(ActionName.Attack));
                        break;
                    }
            }
        }

        for (int i = 0; i < loopTime; i++)
        {
            result.AddRange(actionLoop);
        }

        return result;
    }
}
